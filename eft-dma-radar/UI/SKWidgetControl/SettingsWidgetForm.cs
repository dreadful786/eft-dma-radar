using DarkModeForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using eft_dma_radar.UI.Radar;
using eft_dma_shared.Common.Misc;
using eft_dma_radar.UI.Misc;
using eft_dma_radar.Tarkov.Features.MemoryWrites;
using eft_dma_radar.Features.MemoryWrites.UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using static eft_dma_radar.UI.Radar.MainForm;

namespace LonesEFTRadar.UI.SKWidgetControl
{
    public partial class SettingsWidgetForm : Form
    {
        #region Fields
        private readonly DarkModeCS _darkmode;
        private bool isMinimized = false;
        private Point lastMousePosition;
        private MainForm _mainForm;
        #endregion

        #region Constructor
        public SettingsWidgetForm(MainForm mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            _mainForm.RefreshQuestHelper();
            _mainForm.UpdateSettingsWidgetContainersList();
            SetDarkMode(ref _darkmode);
            UpdateCheckboxStates();
            InitializeHeaderText();
            PopulateQuestHelperList();
            PopulateContainersList();
            PopulateComboBoxAimbotTarget();
            trackBar_AimFOV_SettingsWidget.ValueChanged += TrackBar_AimFOV_SettingsWidget_ValueChanged;
            comboBox_AimbotTarget_SettingsWidget.SelectedIndexChanged += ComboBox_AimbotTarget_SettingsWidget_SelectedIndexChanged;
            checkBox_AimRandomBone_SettingsWidget.CheckedChanged += checkBox_AimRandomBone_SettingsWidget_CheckedChanged;
            UpdateComboBoxAimbotTarget(_mainForm.comboBox_AimbotTarget.SelectedIndex);
            button_StartESP_SettingsWidget.Text = _mainForm.button_StartESP.Text;
            button_StartESP_SettingsWidget.Enabled = button_StartESP_SettingsWidget.Text != "Running...";
            checkedListBox_Containers_SettingsWidget.ItemCheck += checkedListBox_Containers_SettingsWidget_ItemCheck;
            checkBox_Containers_SelectAll_SettingsWidget.CheckedChanged += checkBox_Containers_SelectAll_SettingsWidget_CheckedChanged;
        }
        #endregion

        #region Initialization
        private void InitializeHeaderText()
        {
            Label headerLabel = new Label();
            headerLabel.Text = "EFT DMA RADAR Settings";
            headerLabel.Font = new Font("Arial", 9, FontStyle.Bold);
            headerLabel.ForeColor = Color.Purple;
            headerLabel.AutoSize = true;
            headerLabel.Location = new Point(10, 3);
            headerPanel.Controls.Add(headerLabel);
        }

        private void PopulateQuestHelperList()
        {
            checkedListBox_QuestHelper_SettingsWidget.Items.Clear();
            foreach (var item in _mainForm.checkedListBox_QuestHelper.Items)
            {
                checkedListBox_QuestHelper_SettingsWidget.Items.Add(item, _mainForm.checkedListBox_QuestHelper.GetItemChecked(_mainForm.checkedListBox_QuestHelper.Items.IndexOf(item)));
            }
        }
        public void PopulateContainersList()
        {
            checkedListBox_Containers_SettingsWidget.Items.Clear();
            foreach (var item in _mainForm.checkedListBox_Containers.Items)
            {
                checkedListBox_Containers_SettingsWidget.Items.Add(item, _mainForm.checkedListBox_Containers.GetItemChecked(_mainForm.checkedListBox_Containers.Items.IndexOf(item)));
            }
        }
        #endregion

        #region Event Handlers
        private void minimizeButton_Click(object sender, EventArgs e)
        {
            if (isMinimized)
            {
                this.Size = new System.Drawing.Size(600, 390);
                // this.contentPanel.Visible = true;
                this.minimizeButton.Text = "-";
            }
            else
            {
                this.Size = new System.Drawing.Size(600, 20);
                //this.contentPanel.Visible = false;
                this.minimizeButton.Text = "+";
            }
            isMinimized = !isMinimized;
        }

        private void headerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lastMousePosition = e.Location;
            }
        }

        private void headerPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(
                    this.Location.X + e.X - lastMousePosition.X,
                    this.Location.Y + e.Y - lastMousePosition.Y);
            }
        }
        #region Clicks and CheckChanged
        private void button_Restart_SettingsWidget_Click(object sender, EventArgs e)
        {
            MainForm.button_Restart_Click(sender, e);
        }

        private void button_GymHack_SettingsWidget_Click(object sender, EventArgs e)
        {
            _mainForm.button_GymHack_Click(sender, e);
        }

        private void button_AntiAfk_SettingsWidget_Click(object sender, EventArgs e)
        {
            _mainForm.button_AntiAfk_Click(sender, e);
        }
        private void button_StartESP_SettingsWidget_Click(object sender, EventArgs e)
        {
            _mainForm.button_StartESP_Click(sender, e);
        }

        private void button_RandomBoneCfg_SettingsWidget_Click(object sender, EventArgs e)
        {
            using var form = new AimbotRandomBoneForm();
            var dlg = form.ShowDialog();
            if (!Aimbot.Config.RandomBone.Is100Percent)
                Aimbot.Config.RandomBone.ResetDefaults();
        }
        private void checkBox_MoveSpeed_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_MoveSpeed.Checked = checkBox_MoveSpeed_SettingsWidget.Checked;
        }

        private void checkBox_MoveSpeed2_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_MoveSpeed2.Checked = checkBox_MoveSpeed2_SettingsWidget.Checked;
        }

        private void checkBox_FullBright_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_FullBright.Checked = checkBox_FullBright_SettingsWidget.Checked;
        }

        private void checkBox_InfStamina_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_InfStamina.Checked = checkBox_InfStamina_SettingsWidget.Checked;
        }

        private void checkBox_LTW_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_LTW.Checked = checkBox_LTW_SettingsWidget.Checked;
        }

        private void checkBox_FastLoadUnload_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_FastLoadUnload.Checked = checkBox_FastLoadUnload_SettingsWidget.Checked;
        }

        private void checkBox_Chams_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_Chams.Checked = checkBox_Chams_SettingsWidget.Checked;
        }
        private void checkBox_AimBotEnabled_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_AimBotEnabled.Checked = checkBox_AimBotEnabled_SettingsWidget.Checked;
        }
        private void checkBox_SA_SafeLock_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_SA_SafeLock.Checked = checkBox_SA_SafeLock_SettingsWidget.Checked;
        }
        private void checkBox_SA_AutoBone_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_SA_AutoBone.Checked = checkBox_SA_AutoBone_SettingsWidget.Checked;
        }
        private void radioButton_AimTarget_FOV_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.radioButton_AimTarget_FOV.Checked = radioButton_AimTarget_FOV_SettingsWidget.Checked;
        }
        private void radioButton_AimTarget_CQB_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.radioButton_AimTarget_CQB.Checked = radioButton_AimTarget_CQB_SettingsWidget.Checked;
        }
        private void checkBox_AimbotDisableReLock_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_AimbotDisableReLock.Checked = checkBox_AimbotDisableReLock_SettingsWidget.Checked;
        }
        public void checkBox_Containers_SelectAll_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            bool isChecked = checkBox_Containers_SelectAll_SettingsWidget.Checked;

            // Update all items in checkedListBox_Containers_SettingsWidget
            for (int i = 0; i < checkedListBox_Containers_SettingsWidget.Items.Count; i++)
            {
                checkedListBox_Containers_SettingsWidget.ItemCheck -= checkedListBox_Containers_SettingsWidget_ItemCheck;
                checkedListBox_Containers_SettingsWidget.SetItemChecked(i, isChecked);
                checkedListBox_Containers_SettingsWidget.ItemCheck += checkedListBox_Containers_SettingsWidget_ItemCheck;
            }

            // Propagate the state to MainForm
            if (_mainForm != null)
            {
                _mainForm.checkBox_Containers_SelectAll.CheckedChanged -= _mainForm.checkBox_Containers_SelectAll_CheckedChanged;
                _mainForm.checkBox_Containers_SelectAll.Checked = isChecked;
                _mainForm.checkBox_Containers_SelectAll.CheckedChanged += _mainForm.checkBox_Containers_SelectAll_CheckedChanged;

                // Update all items in checkedListBox_Containers on MainForm
                for (int i = 0; i < _mainForm.checkedListBox_Containers.Items.Count; i++)
                {
                    _mainForm.checkedListBox_Containers.ItemCheck -= _mainForm.CheckedListBox_Containers_ItemCheck;
                    _mainForm.checkedListBox_Containers.SetItemChecked(i, isChecked);
                    _mainForm.checkedListBox_Containers.ItemCheck += _mainForm.CheckedListBox_Containers_ItemCheck;
                }
            }
        }
        private void checkBox_Loot_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_Loot.Checked = checkBox_Loot_SettingsWidget.Checked;
        }
        private void checkBox_LootWishlist_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_LootWishlist.Checked = checkBox_LootWishlist_SettingsWidget.Checked;
        }
        private void checkBox_ShowContainers_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_ShowContainers.Checked = checkBox_ShowContainers_SettingsWidget.Checked;
        }
        private void TrackBar_AimFOV_SettingsWidget_ValueChanged(object sender, EventArgs e)
        {
            int value = trackBar_AimFOV_SettingsWidget.Value;
            label_AimFOV_SettingsWidget.Text = $"FOV {value}";
            _mainForm.UpdateTrackBarAimFOV(value);
            _mainForm.UpdateLabelAimFOV(value);
        }
        private void checkBox_AimHeadAI_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_AimHeadAI.Checked = checkBox_AimHeadAI_SettingsWidget.Checked;
        }
        private void checkBox_AimRandomBone_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_AimRandomBone.Checked = checkBox_AimRandomBone_SettingsWidget.Checked;
            comboBox_AimbotTarget_SettingsWidget.Enabled = !checkBox_AimRandomBone_SettingsWidget.Checked;
            button_RandomBoneCfg_SettingsWidget.Enabled = checkBox_AimRandomBone_SettingsWidget.Checked;
        }
        private void checkBox_Containers_HideSearched_SettingsWidget_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_Containers_HideSearched.Checked = checkBox_Containers_HideSearched_SettingsWidget.Checked;
        }
        private void ComboBox_AimbotTarget_SettingsWidget_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox_AimbotTarget_SettingsWidget.SelectedItem is BonesListItem entry)
            {
                Aimbot.Config.Bone = entry.Bone;
            }

            if (_mainForm != null)
            {
                _mainForm.UpdateComboBoxAimbotTarget(comboBox_AimbotTarget_SettingsWidget.SelectedIndex);
            }

        }
        private void checkedListBox_QuestHelper_SettingsWidget_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Update the corresponding item in the main form's checkedListBox_QuestHelper
            _mainForm.QuestHelperListBox.ItemCheck -= _mainForm.CheckedListBox_QuestHelper_ItemCheck;
            _mainForm.QuestHelperListBox.SetItemChecked(e.Index, e.NewValue == CheckState.Checked);
            _mainForm.QuestHelperListBox.ItemCheck += _mainForm.CheckedListBox_QuestHelper_ItemCheck;
        }
        private void checkedListBox_Containers_SettingsWidget_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Update the corresponding item in the main form's checkedListBox_Containers
            _mainForm.checkedListBox_Containers.ItemCheck -= _mainForm.CheckedListBox_Containers_ItemCheck;
            _mainForm.checkedListBox_Containers.SetItemChecked(e.Index, e.NewValue == CheckState.Checked);
            _mainForm.checkedListBox_Containers.ItemCheck += _mainForm.CheckedListBox_Containers_ItemCheck;
        }
        #endregion
        #endregion

        #region Methods
        public void UpdateCheckboxStates()
        {
            checkBox_MoveSpeed_SettingsWidget.Checked = _mainForm.checkBox_MoveSpeed.Checked;
            checkBox_MoveSpeed2_SettingsWidget.Checked = _mainForm.checkBox_MoveSpeed2.Checked;
            checkBox_FullBright_SettingsWidget.Checked = _mainForm.checkBox_FullBright.Checked;
            checkBox_InfStamina_SettingsWidget.Checked = _mainForm.checkBox_InfStamina.Checked;
            checkBox_FastLoadUnload_SettingsWidget.Checked = _mainForm.checkBox_FastLoadUnload.Checked;
            checkBox_LTW_SettingsWidget.Checked = _mainForm.checkBox_LTW.Checked;
            checkBox_AimBotEnabled_SettingsWidget.Checked = _mainForm.checkBox_AimBotEnabled.Checked;
            checkBox_SA_SafeLock_SettingsWidget.Checked = _mainForm.checkBox_SA_SafeLock.Checked;
            checkBox_SA_AutoBone_SettingsWidget.Checked = _mainForm.checkBox_SA_AutoBone.Checked;
            radioButton_AimTarget_FOV_SettingsWidget.Checked = _mainForm.radioButton_AimTarget_FOV.Checked;
            radioButton_AimTarget_CQB_SettingsWidget.Checked = _mainForm.radioButton_AimTarget_CQB.Checked;
            checkBox_AimbotDisableReLock_SettingsWidget.Checked = _mainForm.checkBox_AimbotDisableReLock.Checked;
            checkBox_AimHeadAI_SettingsWidget.Checked = _mainForm.checkBox_AimHeadAI.Checked;
            checkBox_AimRandomBone_SettingsWidget.Checked = _mainForm.checkBox_AimRandomBone.Checked;
            checkBox_Containers_SelectAll_SettingsWidget.Checked = _mainForm.checkBox_Containers_SelectAll.Checked;
            checkBox_Containers_HideSearched_SettingsWidget.Checked = _mainForm.checkBox_Containers_HideSearched.Checked;
            checkBox_Loot_SettingsWidget.Checked = _mainForm.checkBox_Loot.Checked;
            checkBox_LootWishlist_SettingsWidget.Checked = _mainForm.checkBox_LootWishlist.Checked;
            checkBox_ShowContainers_SettingsWidget.Checked = _mainForm.checkBox_ShowContainers.Checked;
            checkBox_Chams_SettingsWidget.Checked = _mainForm.checkBox_Chams.Checked;   
        }
        public void UpdateMoveSpeedCheckbox(bool isChecked)
        {
            checkBox_MoveSpeed_SettingsWidget.Checked = isChecked;
        }

        public void UpdateMoveSpeed2Checkbox(bool isChecked)
        {
            checkBox_MoveSpeed2_SettingsWidget.Checked = isChecked;
        }

        public void UpdateFullBrightCheckbox(bool isChecked)
        {
            checkBox_FullBright_SettingsWidget.Checked = isChecked;
        }

        public void UpdateInfStaminaCheckbox(bool isChecked)
        {
            checkBox_InfStamina_SettingsWidget.Checked = isChecked;
        }

        public void UpdateLTWCheckbox(bool isChecked)
        {
            checkBox_LTW_SettingsWidget.Checked = isChecked;
        }

        public void UpdateFastLoadUnloadCheckbox(bool isChecked)
        {
            checkBox_FastLoadUnload_SettingsWidget.Checked = isChecked;
        }

        public void UpdateChamsCheckbox(bool isChecked)
        {
            checkBox_Chams_SettingsWidget.Checked = isChecked;
        }

        public void UpdateAimBotEnabledCheckbox(bool isChecked)
        {
            checkBox_AimBotEnabled_SettingsWidget.Checked = isChecked;
        }
        public void UpdateSA_SafeLockCheckbox(bool isChecked)
        {
            checkBox_SA_SafeLock_SettingsWidget.Checked = isChecked;
        }
        public void UpdateSA_AutoBoneCheckbox(bool isChecked)
        {
            checkBox_SA_AutoBone_SettingsWidget.Checked = isChecked;
        }
        public void UpdateAimTarget_FOVCheckbox(bool isChecked)
        {
            radioButton_AimTarget_FOV_SettingsWidget.Checked = isChecked;
        }
        public void UpdateAimTarget_CQBCheckbox(bool isChecked)
        {
            radioButton_AimTarget_CQB_SettingsWidget.Checked = isChecked;
        }
        public void UpdateAimbotDisableReLockCheckbox(bool isChecked)
        {
            checkBox_AimbotDisableReLock_SettingsWidget.Checked = isChecked;
        }
        public void UpdateAimHeadAICheckbox(bool isChecked)
        {
            checkBox_AimHeadAI_SettingsWidget.Checked = isChecked;
        }
        public void UpdateAimRandomBoneCheckbox(bool isChecked)
        {
            checkBox_AimRandomBone_SettingsWidget.Checked = isChecked;
        }
        public void UpdateContainers_SelectAllCheckbox(bool isChecked)
        {
            checkBox_Containers_SelectAll_SettingsWidget.Checked = isChecked;
        }
        public void UpdateContainersContainersHideSearchedCheckbox(bool isChecked)
        {
            checkBox_Containers_HideSearched_SettingsWidget.Checked = isChecked;
        }
        public void UpdateLootWishlistCheckbox(bool isChecked)
        {
            checkBox_LootWishlist_SettingsWidget.Checked = isChecked;
        }
        public void UpdateLootCheckbox(bool isChecked)
        {
            checkBox_Loot_SettingsWidget.Checked = isChecked;
        }
        public void UpdateShowContainersCheckbox(bool isChecked)
        {
            checkBox_ShowContainers_SettingsWidget.Checked = isChecked;
        }
        public void UpdateQuestHelperList(int index, bool isChecked)
        {
            checkedListBox_QuestHelper_SettingsWidget.ItemCheck -= checkedListBox_QuestHelper_SettingsWidget_ItemCheck;
            checkedListBox_QuestHelper_SettingsWidget.SetItemChecked(index, isChecked);
            checkedListBox_QuestHelper_SettingsWidget.ItemCheck += checkedListBox_QuestHelper_SettingsWidget_ItemCheck;
        }
        public void UpdateContainersList(int index, bool isChecked)
        {
            checkedListBox_Containers_SettingsWidget.ItemCheck -= checkedListBox_Containers_SettingsWidget_ItemCheck;
            checkedListBox_Containers_SettingsWidget.SetItemChecked(index, isChecked);
            checkedListBox_Containers_SettingsWidget.ItemCheck += checkedListBox_Containers_SettingsWidget_ItemCheck;
        }
        public void UpdateContainersCheckedState()
        {
            checkedListBox_Containers_SettingsWidget.ItemCheck -= checkedListBox_Containers_SettingsWidget_ItemCheck;
            checkedListBox_Containers_SettingsWidget.Items.Clear();
            foreach (var item in _mainForm.checkedListBox_Containers.Items)
            {
                bool isChecked = _mainForm.checkedListBox_Containers.GetItemChecked(_mainForm.checkedListBox_Containers.Items.IndexOf(item));
                checkedListBox_Containers_SettingsWidget.Items.Add(item, isChecked);
            }
            checkedListBox_Containers_SettingsWidget.ItemCheck += checkedListBox_Containers_SettingsWidget_ItemCheck;
        }
        public void SetCheckedItems(List<string> checkedItems)
        {
            for (int i = 0; i < checkedListBox_Containers_SettingsWidget.Items.Count; i++)
            {
                if (checkedItems.Contains(checkedListBox_Containers_SettingsWidget.Items[i].ToString()))
                {
                    checkedListBox_Containers_SettingsWidget.SetItemChecked(i, true);
                }
                else
                {
                    checkedListBox_Containers_SettingsWidget.SetItemChecked(i, false);
                }
            }
        }
        public void UpdateTrackBarAimFOV(int value)
        {
            if (trackBar_AimFOV_SettingsWidget.Value != value)
            {
                trackBar_AimFOV_SettingsWidget.Value = value;
            }
        }
        public void UpdateLabelAimFOV(int value)
        {
            label_AimFOV_SettingsWidget.Text = $"FOV {value}";
        }
        public void UpdateComboBoxAimbotTarget(int selectedIndex)
        {
            if (comboBox_AimbotTarget_SettingsWidget.SelectedIndex != selectedIndex)
            {
                comboBox_AimbotTarget_SettingsWidget.SelectedIndex = selectedIndex;
            }
        }
        private void PopulateComboBoxAimbotTarget()
        {
            comboBox_AimbotTarget_SettingsWidget.Items.Clear();
            foreach (var item in _mainForm.comboBox_AimbotTarget.Items)
            {
                comboBox_AimbotTarget_SettingsWidget.Items.Add(item);
            }
        }
        public void UpdateStartESPButtonText(string text)
        {
            button_StartESP_SettingsWidget.Text = text;
            button_StartESP_SettingsWidget.Enabled = button_StartESP_SettingsWidget.Text != "Running...";
        }
        #endregion

        /// <summary>
        /// Set Dark Mode on startup.
        /// </summary>
        /// <param name="darkmode"></param>
        private void SetDarkMode(ref DarkModeCS darkmode)
        {
            darkmode = new DarkModeCS(this);
            if (darkmode.IsDarkMode)
            {
                SharedPaints.PaintBitmap.ColorFilter = SharedPaints.GetDarkModeColorFilter(0.7f);
                SharedPaints.PaintBitmapAlpha.ColorFilter = SharedPaints.GetDarkModeColorFilter(0.7f);
            }
        }
    }
}
