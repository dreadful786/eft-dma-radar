using eft_dma_shared.Common.Features;
using eft_dma_shared.Common.Misc;
using eft_dma_shared.Common.Unity.LowLevel.Hooks;
using eft_dma_shared.Common.DMA.ScatterAPI;
using eft_dma_shared.Common.Unity;
using eft_dma_radar_non_rotated_maps;
using eft_dma_radar_non_rotated_maps.Tarkov.Features;
using System;
using System.Text;
using eft_dma_radar_non_rotated_maps.Tarkov.EFTPlayer;
using Reloaded.Assembler;
using eft_dma_shared.Common.Unity.LowLevel;
using static eft_dma_shared.Common.Unity.MonoLib;

namespace eft_dma_shared.Common.Features.MemoryWrites
{
    public sealed class StreamerMode : MemPatchFeature<StreamerMode>
    {
        private bool _set;
        private bool _rightSideDisabled = false;
        private bool _notifierDisabled = false;
        private bool _nameSpoofed = false;
        private bool _levelSpoofed = false;

        public override bool Enabled
        {
            get => MemWrites.Config.StreamerMode;
            set
            {
                if (MemWrites.Config.StreamerMode == value) return; 

                MemWrites.Config.StreamerMode = value;

                if (value)
                {
                    TryApply();
                }
            }
        }
        public override bool TryApply()
        {
            if (_set) return true;

            try
            {
                if (!Enabled) return false;

                LoneLogging.WriteLine("StreamerMode: Applying patches...");
                SpoofName();
                PatchIsLocalStreamer();
                //PatchDogtagNicknameP1();
                //PatchDogtagNicknameP2();
                GloballySpoofLevel();
                DisableRightSide();
                DisableNotifier();

                LoneLogging.WriteLine("StreamerMode: Applied Successfully!");
                _set = true;
            }
            catch (Exception ex)
            {
                LoneLogging.WriteLine($"ERROR configuring StreamerMode: {ex}");
                return false;
            }
            return true;
        }
        private void DisableRightSide()
        {
            LoneLogging.WriteLine("Disabling RightSide Panel...");
            ulong rightSide = NativeMethods.FindGameObjectS("Common UI/Common UI/InventoryScreen/Overall Panel/RightSide");
            if (rightSide != 0x0)
            {
                NativeMethods.GameObjectSetActive(rightSide, false);
                LoneLogging.WriteLine("RightSide Panel disabled!");
                _rightSideDisabled = true;
            }
            else
            {
                LoneLogging.WriteLine("Failed to find RightSide Panel.");
            }
        }
        private void DisableNotifier()
        {
            LoneLogging.WriteLine("Disabling Notifier...");
            ulong notifier = NativeMethods.FindGameObjectS("Preloader UI/Preloader UI/BottomPanel/Content/UpperPart/Notifier/Content");
            if (notifier != 0x0)
            {
                NativeMethods.GameObjectSetActive(notifier, false);
                LoneLogging.WriteLine("Notifier disabled!");
                _notifierDisabled = true;
            }
            else
            {
                LoneLogging.WriteLine("Failed to find Notifier.");
            }
        }          
        private void SpoofName()
        {
            if (!(Memory.LocalPlayer is LocalPlayer localPlayer))
                return;

            var profile = Memory.ReadPtr(localPlayer + Offsets.Player.Profile);
            var profileInfo = Memory.ReadPtr(profile + Offsets.Profile.Info);

            ulong usernameAddr = Memory.ReadPtr(profileInfo + Offsets.PlayerInfo.Nickname); // Username
            int originalUsernameLength = Memory.ReadValue<int>(usernameAddr + UnityOffsets.UnityString.Length);

            LoneLogging.WriteLine($"Original Username Length: {originalUsernameLength}, Username Address: {usernameAddr}");

            using (var scatterWrite = new ScatterWriteHandle())
            {
                string spoofedName = new string(' ', originalUsernameLength);
                scatterWrite.AddBufferEntry<byte>(usernameAddr + UnityOffsets.UnityString.Value, Encoding.Unicode.GetBytes(spoofedName));        
                scatterWrite.AddValueEntry(profileInfo + Offsets.PlayerInfo.MemberCategory, (int)Enums.EMemberCategory.Sherpa);
                scatterWrite.Execute(() => true);
            }
        }
        private bool IsLocalStreamerMethodPatched = false;
        /// <summary>
        /// Force "<Streamer>" text for names.
        /// </summary>
        private void PatchIsLocalStreamer()
        {
            if (IsLocalStreamerMethodPatched) return;

            SignatureInfo sigInfo = new(null, ShellKeeper.PatchTrue);

            PatchMethodE(ClassNames.StreamerMode.ClassName, ClassNames.StreamerMode.MethodName, sigInfo, compileClass: true);

            IsLocalStreamerMethodPatched = true;
        }
        private bool DogtagNicknamePatchedP1 = false;
        private static readonly byte[] DogtagNicknameP1Signature = new byte[]
        {
            0x48, 0x8B, 0x40, 0x30
        };
        /// <summary>
        /// Makes the function return null instead of the nickname field.
        /// </summary>
        private static readonly byte[] DogtagNicknameP1Patch = new byte[]
        {
            0x48, 0x31, 0xC0, 0x90 // xor rax, rax
        };
        private void PatchDogtagNicknameP1()
        {
            if (DogtagNicknamePatchedP1) return;

            // Confirm method exists
            //DebugDogtagMethods();

            var mClass = MonoClass.Find("Assembly-CSharp", "EFT.InventoryLogic.DogtagComponent", out ulong classAddress);
            if (classAddress == 0x0)
            {
                LoneLogging.WriteLine($"[ERROR] Class 'EFT.InventoryLogic.DogtagComponent' not found!");
                return;
            }

            // Compile the class to ensure the method address is valid
            ulong compiledClass = NativeMethods.CompileClass(classAddress);
            if (compiledClass == 0x0)
            {
                LoneLogging.WriteLine($"[ERROR] Unable to compile class 'EFT.InventoryLogic.DogtagComponent'!");
                return;
            }

            // Re-check the method after compilation
            var methodPtr = mClass.FindMethod("\uE000"); 
            if (methodPtr == 0x0)
            {
                LoneLogging.WriteLine($"[ERROR] Unable to find method '\uE000' in 'EFT.InventoryLogic.DogtagComponent' after compilation!");
                return;
            }

            LoneLogging.WriteLine($"[INFO] Found method '\uE000' at 0x{methodPtr:X}");

            // Patch the method
            SignatureInfo sigInfo = new(DogtagNicknameP1Signature, DogtagNicknameP1Patch, 200);
            PatchMethodE("EFT.InventoryLogic.DogtagComponent", "\uE000", sigInfo, compileClass: true);

            DogtagNicknamePatchedP1 = true;
        }
        private bool DogtagNicknamePatchedP2 = false;
        private const string DogtagNicknameP2SignatureMask = "xx????xxx";
        private static readonly byte[] DogtagNicknameP2Signature = new byte[]
        {
            0x0F, 0x84, 0x0, 0x0, 0x0, 0x0,
            0x4D, 0x8B, 0x66
        };
        /// <summary>
        /// Basically tring to make it so this if statement's contents are not ran:
        /// if (itemComponent3 != null && !string.IsNullOrEmpty(itemComponent3.Nickname))
        /// {
        ///	    text = (examined? itemComponent3.Nickname.SubstringIfNecessary(20) : \uEF86.\uE000(295345));
        /// }
        /// </summary>
        private static readonly byte[] DogtagNicknameP2Patch = new byte[]
        {
            0x90, 0xE9
        };
        /// <summary>
        /// Patches game code to hide the player nickname on all dogtag item grids.
        /// </summary>
        private void PatchDogtagNicknameP2()
        {
            if (DogtagNicknamePatchedP2) 
            return;

            SignatureInfo sigInfo = new(DogtagNicknameP2Signature, DogtagNicknameP2Signature.Patch(DogtagNicknameP2Patch), 0x1000, DogtagNicknameP2SignatureMask, DogtagNicknameP2SignatureMask, 0, DogtagNicknameP2Patch);

            PatchMethodE("EFT.UI.DragAndDrop.GridItemView", ClassNames.GridItemView.MethodName, sigInfo, compileClass: true);

            DogtagNicknamePatchedP2 = true;
        }
        private void DebugDogtagMethods()
        {
            var mClass = MonoClass.Find("Assembly-CSharp", "EFT.InventoryLogic.DogtagComponent", out ulong classAddress);
            if (classAddress == 0x0)
            {
                LoneLogging.WriteLine($"[DEBUG] Class 'EFT.InventoryLogic.DogtagComponent' not found!");
                return;
            }

            int methodCount = mClass.GetNumMethods();
            LoneLogging.WriteLine($"[DEBUG] Methods of 'EFT.InventoryLogic.DogtagComponent': {methodCount} methods found.");

            for (int i = 0; i < methodCount; i++)
            {
                var method = mClass.GetMethod(i);
                if (method == 0x0) continue;

                string methodName = method.Value.GetName();
                string unicodeEscaped = string.Join("", methodName.Select(c => $"\\u{(int)c:X4}"));
                ulong methodPtr = method;

                LoneLogging.WriteLine($"[DEBUG] Method[{i}]: {methodName} (Unicode: {unicodeEscaped}) at 0x{methodPtr:X}");
            }
        }
        private bool LevelGloballySpoofed = false;
        private static readonly byte[] GloballySpoofLevelSignature = new byte[]
        {
            0x45, 0x85, 0xF6,
            0x0F, 0x84,
        };
        private void GloballySpoofLevel()
        {
            if (LevelGloballySpoofed) return;

            Assembler assembler = new();

            string[] mnemonicsA = new[]
            {
                "use64",
                "mov rdi, 79",
                "nop",
                "nop",
            };
            byte[] shellcodeA = assembler.Assemble(mnemonicsA);
            SignatureInfo sigInfoA = new(GloballySpoofLevelSignature, shellcodeA, 100);
            PatchMethodE("EFT.UI.PlayerLevelPanel", "Set", sigInfoA, compileClass: true);

            SignatureInfo sigInfoB = new(null, ShellKeeper.ReturnInt(79));
            PatchMethodE("EFT.Profile+TraderInfo", "get_ProfileLevel", sigInfoB, compileClass: true);

            // EFT.UI.Chat.ChatMember:Show

            LevelGloballySpoofed = true;
        }
    }
}
