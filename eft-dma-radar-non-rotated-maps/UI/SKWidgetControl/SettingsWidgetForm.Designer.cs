using SkiaSharp;
using System.Runtime;
using System;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Win32;

namespace LonesEFTRadar.UI.SKWidgetControl
{
    partial class SettingsWidgetForm : System.Windows.Forms.Form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            headerPanel = new Panel();
            minimizeButton = new Button();
            button_Restart_SettingsWidget = new Button();
            checkBox_MoveSpeed2_SettingsWidget = new CheckBox();
            checkBox_MoveSpeed_SettingsWidget = new CheckBox();
            button_GymHack_SettingsWidget = new Button();
            checkBox_FullBright_SettingsWidget = new CheckBox();
            button_AntiAfk_SettingsWidget = new Button();
            checkBox_InfStamina_SettingsWidget = new CheckBox();
            checkBox_LTW_SettingsWidget = new CheckBox();
            checkBox_FastLoadUnload_SettingsWidget = new CheckBox();
            checkBox_Chams_SettingsWidget = new CheckBox();
            tabControl1 = new TabControl();
            tabPage1 = new TabPage();
            checkBox_Loot_SettingsWidget = new CheckBox();
            checkBox_LootWishlist_SettingsWidget = new CheckBox();
            checkBox_ShowContainers_SettingsWidget = new CheckBox();
            flowLayoutPanel_Loot_Containers_SettingsWidget = new FlowLayoutPanel();
            label30 = new Label();
            checkBox_Containers_SelectAll_SettingsWidget = new CheckBox();
            label31 = new Label();
            checkBox_Containers_HideSearched_SettingsWidget = new CheckBox();
            checkedListBox_Containers_SettingsWidget = new CheckedListBox();
            checkBox_EnableMemWrite_SettingsWidget = new CheckBox();
            checkBox_AdvancedMemWrites_SettingsWidget = new CheckBox();
            button_StartESP_SettingsWidget = new Button();
            checkedListBox_QuestHelper_SettingsWidget = new CheckedListBox();
            tabPage2 = new TabPage();
            button_RandomBoneCfg_SettingsWidget = new Button();
            label10 = new Label();
            comboBox_AimbotTarget_SettingsWidget = new ComboBox();
            checkBox_AimRandomBone_SettingsWidget = new CheckBox();
            checkBox_AimHeadAI_SettingsWidget = new CheckBox();
            label_AimFOV_SettingsWidget = new Label();
            trackBar_AimFOV_SettingsWidget = new TrackBar();
            checkBox_AimbotDisableReLock_SettingsWidget = new CheckBox();
            radioButton_AimTarget_FOV_SettingsWidget = new RadioButton();
            radioButton_AimTarget_CQB_SettingsWidget = new RadioButton();
            checkBox_SA_AutoBone_SettingsWidget = new CheckBox();
            checkBox_SA_SafeLock_SettingsWidget = new CheckBox();
            checkBox_AimBotEnabled_SettingsWidget = new CheckBox();
            tabPage3 = new TabPage();
            label5 = new Label();
            label1 = new Label();
            label_EspLineScale = new Label();
            trackBar_EspLineScale = new TrackBar();
            label_EspLootDist = new Label();
            trackBar_EspLootDist = new TrackBar();
            label_EspImpLootDist = new Label();
            trackBar_EspImpLootDist = new TrackBar();
            label_ESPContainerDist = new Label();
            trackBar_ESPContainerDist = new TrackBar();
            label_EspQuestHelperDist = new Label();
            trackBar_EspQuestHelperDist = new TrackBar();
            label_EspExplosivesDist = new Label();
            trackBar_EspGrenadeDist = new TrackBar();
            label_EspFontScale = new Label();
            trackBar_EspFontScale = new TrackBar();
            flowLayoutPanel_ESP_AIRender = new FlowLayoutPanel();
            label19 = new Label();
            radioButton_ESPAIRender_None = new RadioButton();
            radioButton_ESPAIRender_Bones = new RadioButton();
            radioButton_ESPAIRender_Box = new RadioButton();
            radioButton_ESPAIRender_Presence = new RadioButton();
            checkBox_ESPAIRender_Labels = new CheckBox();
            checkBox_ESPAIRender_Weapons = new CheckBox();
            checkBox_ESPAIRender_Dist = new CheckBox();
            flowLayoutPanel_ESP_PlayerRender = new FlowLayoutPanel();
            label18 = new Label();
            radioButton_ESPRender_None = new RadioButton();
            radioButton_ESPRender_Bones = new RadioButton();
            radioButton_ESPRender_Box = new RadioButton();
            radioButton_ESPRender_Presence = new RadioButton();
            checkBox_ESPRender_Labels = new CheckBox();
            checkBox_ESPRender_Weapons = new CheckBox();
            checkBox_ESPRender_Dist = new CheckBox();
            checkBox_ESP_FPS = new CheckBox();
            checkBox_ESP_ShowMines = new CheckBox();
            checkBox_ESP_FireportAim = new CheckBox();
            checkBox_ESP_AimFov = new CheckBox();
            checkBox_ESP_AimLock = new CheckBox();
            checkBox_ESP_RaidStats = new CheckBox();
            checkBox_ESP_StatusText = new CheckBox();
            checkBox_ESP_Loot = new CheckBox();
            checkBox_ESP_Exfils = new CheckBox();
            checkBox_ESP_Explosives = new CheckBox();
            checkBox_ESP_ShowMag = new CheckBox();
            checkBox_ESP_Dist = new CheckBox();
            label11 = new Label();
            label_Width = new Label();
            textBox_ResWidth = new TextBox();
            label_Height = new Label();
            textBox_ResHeight = new TextBox();
            button_DetectRes = new Button();
            tabPage4 = new TabPage();
            label6 = new Label();
            label2 = new Label();
            radioButton_Chams_Basic = new RadioButton();
            radioButton_Chams_Visible = new RadioButton();
            radioButton_Chams_Vischeck = new RadioButton();
            label15 = new Label();
            textBox_VischeckVisColor = new TextBox();
            textBox_VischeckInvisColor = new TextBox();
            button_VischeckVisColorPick = new Button();
            label33 = new Label();
            button_VischeckInvisColorPick = new Button();
            tabPage5 = new TabPage();
            label7 = new Label();
            label3 = new Label();
            label_WebRadarPassword = new Label();
            textBox_WebRadarPassword = new TextBox();
            linkLabel_WebRadarLink = new LinkLabel();
            label_WebRadarTickRate = new Label();
            textBox_WebRadarTickRate = new TextBox();
            button_WebRadarStart = new Button();
            checkBox_WebRadarUPNP = new CheckBox();
            label_WebRadarHost = new Label();
            textBox_WebRadarBindIP = new TextBox();
            label_WebRadarPort = new Label();
            textBox_WebRadarPort = new TextBox();
            tabPage6 = new TabPage();
            label8 = new Label();
            label4 = new Label();
            flowLayoutPanel_NoRecoil = new FlowLayoutPanel();
            label16 = new Label();
            label_Recoil = new Label();
            trackBar_NoRecoil = new TrackBar();
            label_Sway = new Label();
            trackBar_NoSway = new TrackBar();
            flowLayoutPanel_LTW = new FlowLayoutPanel();
            label28 = new Label();
            label_LTWAmount = new Label();
            trackBar_LTWAmount = new TrackBar();
            flowLayoutPanel_WideLean = new FlowLayoutPanel();
            label_WideLean = new Label();
            label21 = new Label();
            comboBox_WideLeanMode = new ComboBox();
            label_WideLeanAmt = new Label();
            trackBar_WideLeanAmt = new TrackBar();
            checkBox_hideRaidcode = new CheckBox();
            checkBox_AntiPage = new CheckBox();
            checkBox_NoRecoilSway = new CheckBox();
            checkBox_WideLean = new CheckBox();
            checkBox_NoVisor = new CheckBox();
            checkBox_AlwaysDaySunny = new CheckBox();
            checkBox_NoWepMalf = new CheckBox();
            headerPanel.SuspendLayout();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            flowLayoutPanel_Loot_Containers_SettingsWidget.SuspendLayout();
            tabPage2.SuspendLayout();
            ((ISupportInitialize)trackBar_AimFOV_SettingsWidget).BeginInit();
            tabPage3.SuspendLayout();
            ((ISupportInitialize)trackBar_EspLineScale).BeginInit();
            ((ISupportInitialize)trackBar_EspLootDist).BeginInit();
            ((ISupportInitialize)trackBar_EspImpLootDist).BeginInit();
            ((ISupportInitialize)trackBar_ESPContainerDist).BeginInit();
            ((ISupportInitialize)trackBar_EspQuestHelperDist).BeginInit();
            ((ISupportInitialize)trackBar_EspGrenadeDist).BeginInit();
            ((ISupportInitialize)trackBar_EspFontScale).BeginInit();
            flowLayoutPanel_ESP_AIRender.SuspendLayout();
            flowLayoutPanel_ESP_PlayerRender.SuspendLayout();
            tabPage4.SuspendLayout();
            tabPage5.SuspendLayout();
            tabPage6.SuspendLayout();
            flowLayoutPanel_NoRecoil.SuspendLayout();
            ((ISupportInitialize)trackBar_NoRecoil).BeginInit();
            ((ISupportInitialize)trackBar_NoSway).BeginInit();
            flowLayoutPanel_LTW.SuspendLayout();
            ((ISupportInitialize)trackBar_LTWAmount).BeginInit();
            flowLayoutPanel_WideLean.SuspendLayout();
            ((ISupportInitialize)trackBar_WideLeanAmt).BeginInit();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.Controls.Add(minimizeButton);
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(600, 20);
            headerPanel.TabIndex = 0;
            headerPanel.MouseDown += headerPanel_MouseDown;
            headerPanel.MouseMove += headerPanel_MouseMove;
            // 
            // minimizeButton
            // 
            minimizeButton.Dock = DockStyle.Right;
            minimizeButton.Location = new Point(578, 0);
            minimizeButton.Name = "minimizeButton";
            minimizeButton.Size = new Size(22, 20);
            minimizeButton.TabIndex = 0;
            minimizeButton.Text = "-";
            minimizeButton.Click += minimizeButton_Click;
            // 
            // button_Restart_SettingsWidget
            // 
            button_Restart_SettingsWidget.FlatStyle = FlatStyle.Popup;
            button_Restart_SettingsWidget.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button_Restart_SettingsWidget.ForeColor = Color.Red;
            button_Restart_SettingsWidget.Location = new Point(4, 3);
            button_Restart_SettingsWidget.Name = "button_Restart_SettingsWidget";
            button_Restart_SettingsWidget.Size = new Size(88, 23);
            button_Restart_SettingsWidget.TabIndex = 19;
            button_Restart_SettingsWidget.Text = "Restart Radar";
            button_Restart_SettingsWidget.Click += button_Restart_SettingsWidget_Click;
            // 
            // checkBox_MoveSpeed2_SettingsWidget
            // 
            checkBox_MoveSpeed2_SettingsWidget.AutoSize = true;
            checkBox_MoveSpeed2_SettingsWidget.Location = new Point(4, 57);
            checkBox_MoveSpeed2_SettingsWidget.Name = "checkBox_MoveSpeed2_SettingsWidget";
            checkBox_MoveSpeed2_SettingsWidget.Size = new Size(152, 19);
            checkBox_MoveSpeed2_SettingsWidget.TabIndex = 81;
            checkBox_MoveSpeed2_SettingsWidget.Text = "1.4x Move Speed (Risky)";
            checkBox_MoveSpeed2_SettingsWidget.CheckedChanged += checkBox_MoveSpeed2_SettingsWidget_CheckedChanged;
            // 
            // checkBox_MoveSpeed_SettingsWidget
            // 
            checkBox_MoveSpeed_SettingsWidget.AutoSize = true;
            checkBox_MoveSpeed_SettingsWidget.Location = new Point(4, 32);
            checkBox_MoveSpeed_SettingsWidget.Name = "checkBox_MoveSpeed_SettingsWidget";
            checkBox_MoveSpeed_SettingsWidget.Size = new Size(152, 19);
            checkBox_MoveSpeed_SettingsWidget.TabIndex = 80;
            checkBox_MoveSpeed_SettingsWidget.Text = "1.2x Move Speed (Risky)";
            checkBox_MoveSpeed_SettingsWidget.CheckedChanged += checkBox_MoveSpeed_SettingsWidget_CheckedChanged;
            // 
            // button_GymHack_SettingsWidget
            // 
            button_GymHack_SettingsWidget.FlatStyle = FlatStyle.Popup;
            button_GymHack_SettingsWidget.Location = new Point(98, 3);
            button_GymHack_SettingsWidget.Name = "button_GymHack_SettingsWidget";
            button_GymHack_SettingsWidget.Size = new Size(96, 23);
            button_GymHack_SettingsWidget.TabIndex = 82;
            button_GymHack_SettingsWidget.Text = "Gym Hack";
            button_GymHack_SettingsWidget.Click += button_GymHack_SettingsWidget_Click;
            // 
            // checkBox_FullBright_SettingsWidget
            // 
            checkBox_FullBright_SettingsWidget.AutoSize = true;
            checkBox_FullBright_SettingsWidget.Location = new Point(158, 32);
            checkBox_FullBright_SettingsWidget.Name = "checkBox_FullBright_SettingsWidget";
            checkBox_FullBright_SettingsWidget.Size = new Size(80, 19);
            checkBox_FullBright_SettingsWidget.TabIndex = 83;
            checkBox_FullBright_SettingsWidget.Text = "Full Bright";
            checkBox_FullBright_SettingsWidget.CheckedChanged += checkBox_FullBright_SettingsWidget_CheckedChanged;
            // 
            // button_AntiAfk_SettingsWidget
            // 
            button_AntiAfk_SettingsWidget.FlatStyle = FlatStyle.Popup;
            button_AntiAfk_SettingsWidget.Location = new Point(200, 3);
            button_AntiAfk_SettingsWidget.Name = "button_AntiAfk_SettingsWidget";
            button_AntiAfk_SettingsWidget.Size = new Size(96, 23);
            button_AntiAfk_SettingsWidget.TabIndex = 84;
            button_AntiAfk_SettingsWidget.Text = "Anti-AFK";
            button_AntiAfk_SettingsWidget.Click += button_AntiAfk_SettingsWidget_Click;
            // 
            // checkBox_InfStamina_SettingsWidget
            // 
            checkBox_InfStamina_SettingsWidget.AutoSize = true;
            checkBox_InfStamina_SettingsWidget.Location = new Point(244, 32);
            checkBox_InfStamina_SettingsWidget.Name = "checkBox_InfStamina_SettingsWidget";
            checkBox_InfStamina_SettingsWidget.Size = new Size(147, 19);
            checkBox_InfStamina_SettingsWidget.TabIndex = 85;
            checkBox_InfStamina_SettingsWidget.Text = "Infinite Stamina (Risky)";
            checkBox_InfStamina_SettingsWidget.CheckedChanged += checkBox_InfStamina_SettingsWidget_CheckedChanged;
            // 
            // checkBox_LTW_SettingsWidget
            // 
            checkBox_LTW_SettingsWidget.AutoSize = true;
            checkBox_LTW_SettingsWidget.Location = new Point(283, 57);
            checkBox_LTW_SettingsWidget.Name = "checkBox_LTW_SettingsWidget";
            checkBox_LTW_SettingsWidget.Size = new Size(168, 19);
            checkBox_LTW_SettingsWidget.TabIndex = 86;
            checkBox_LTW_SettingsWidget.Text = "Loot Through Walls (Risky)";
            checkBox_LTW_SettingsWidget.CheckedChanged += checkBox_LTW_SettingsWidget_CheckedChanged;
            // 
            // checkBox_FastLoadUnload_SettingsWidget
            // 
            checkBox_FastLoadUnload_SettingsWidget.AutoSize = true;
            checkBox_FastLoadUnload_SettingsWidget.Location = new Point(158, 57);
            checkBox_FastLoadUnload_SettingsWidget.Name = "checkBox_FastLoadUnload_SettingsWidget";
            checkBox_FastLoadUnload_SettingsWidget.Size = new Size(119, 19);
            checkBox_FastLoadUnload_SettingsWidget.TabIndex = 87;
            checkBox_FastLoadUnload_SettingsWidget.Text = "Fast Load/Unload";
            checkBox_FastLoadUnload_SettingsWidget.CheckedChanged += checkBox_FastLoadUnload_SettingsWidget_CheckedChanged;
            // 
            // checkBox_Chams_SettingsWidget
            // 
            checkBox_Chams_SettingsWidget.AutoSize = true;
            checkBox_Chams_SettingsWidget.Location = new Point(397, 32);
            checkBox_Chams_SettingsWidget.Name = "checkBox_Chams_SettingsWidget";
            checkBox_Chams_SettingsWidget.Size = new Size(63, 19);
            checkBox_Chams_SettingsWidget.TabIndex = 88;
            checkBox_Chams_SettingsWidget.Text = "Chams";
            checkBox_Chams_SettingsWidget.CheckedChanged += checkBox_Chams_SettingsWidget_CheckedChanged;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage3);
            tabControl1.Controls.Add(tabPage4);
            tabControl1.Controls.Add(tabPage5);
            tabControl1.Controls.Add(tabPage6);
            tabControl1.ImeMode = ImeMode.NoControl;
            tabControl1.Location = new Point(0, 23);
            tabControl1.Margin = new Padding(0);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.Padding = new Point(0, 0);
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(600, 358);
            tabControl1.TabIndex = 89;
            // 
            // tabPage1
            // 
            tabPage1.BackgroundImageLayout = ImageLayout.None;
            tabPage1.Controls.Add(checkBox_Loot_SettingsWidget);
            tabPage1.Controls.Add(checkBox_LootWishlist_SettingsWidget);
            tabPage1.Controls.Add(checkBox_ShowContainers_SettingsWidget);
            tabPage1.Controls.Add(flowLayoutPanel_Loot_Containers_SettingsWidget);
            tabPage1.Controls.Add(checkBox_EnableMemWrite_SettingsWidget);
            tabPage1.Controls.Add(checkBox_AdvancedMemWrites_SettingsWidget);
            tabPage1.Controls.Add(button_StartESP_SettingsWidget);
            tabPage1.Controls.Add(button_Restart_SettingsWidget);
            tabPage1.Controls.Add(checkedListBox_QuestHelper_SettingsWidget);
            tabPage1.Controls.Add(button_GymHack_SettingsWidget);
            tabPage1.Controls.Add(checkBox_Chams_SettingsWidget);
            tabPage1.Controls.Add(button_AntiAfk_SettingsWidget);
            tabPage1.Controls.Add(checkBox_LTW_SettingsWidget);
            tabPage1.Controls.Add(checkBox_FastLoadUnload_SettingsWidget);
            tabPage1.Controls.Add(checkBox_MoveSpeed_SettingsWidget);
            tabPage1.Controls.Add(checkBox_FullBright_SettingsWidget);
            tabPage1.Controls.Add(checkBox_InfStamina_SettingsWidget);
            tabPage1.Controls.Add(checkBox_MoveSpeed2_SettingsWidget);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(0);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(592, 330);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Quick Settings";
            // 
            // checkBox_Loot_SettingsWidget
            // 
            checkBox_Loot_SettingsWidget.Anchor = AnchorStyles.Right;
            checkBox_Loot_SettingsWidget.AutoSize = true;
            checkBox_Loot_SettingsWidget.Location = new Point(4, 257);
            checkBox_Loot_SettingsWidget.Name = "checkBox_Loot_SettingsWidget";
            checkBox_Loot_SettingsWidget.Size = new Size(105, 19);
            checkBox_Loot_SettingsWidget.TabIndex = 93;
            checkBox_Loot_SettingsWidget.Text = "Show Loot (F3)";
            checkBox_Loot_SettingsWidget.UseVisualStyleBackColor = true;
            checkBox_Loot_SettingsWidget.CheckedChanged += checkBox_Loot_SettingsWidget_CheckedChanged;
            // 
            // checkBox_LootWishlist_SettingsWidget
            // 
            checkBox_LootWishlist_SettingsWidget.Anchor = AnchorStyles.Right;
            checkBox_LootWishlist_SettingsWidget.AutoSize = true;
            checkBox_LootWishlist_SettingsWidget.Location = new Point(115, 257);
            checkBox_LootWishlist_SettingsWidget.Name = "checkBox_LootWishlist_SettingsWidget";
            checkBox_LootWishlist_SettingsWidget.Size = new Size(126, 19);
            checkBox_LootWishlist_SettingsWidget.TabIndex = 95;
            checkBox_LootWishlist_SettingsWidget.Text = "Show Loot Wishlist";
            checkBox_LootWishlist_SettingsWidget.UseVisualStyleBackColor = true;
            checkBox_LootWishlist_SettingsWidget.CheckedChanged += checkBox_LootWishlist_SettingsWidget_CheckedChanged;
            // 
            // checkBox_ShowContainers_SettingsWidget
            // 
            checkBox_ShowContainers_SettingsWidget.Anchor = AnchorStyles.Right;
            checkBox_ShowContainers_SettingsWidget.AutoSize = true;
            checkBox_ShowContainers_SettingsWidget.Location = new Point(247, 257);
            checkBox_ShowContainers_SettingsWidget.Name = "checkBox_ShowContainers_SettingsWidget";
            checkBox_ShowContainers_SettingsWidget.Size = new Size(147, 19);
            checkBox_ShowContainers_SettingsWidget.TabIndex = 94;
            checkBox_ShowContainers_SettingsWidget.Text = "Show Static Containers";
            checkBox_ShowContainers_SettingsWidget.UseVisualStyleBackColor = true;
            checkBox_ShowContainers_SettingsWidget.CheckedChanged += checkBox_ShowContainers_SettingsWidget_CheckedChanged;
            // 
            // flowLayoutPanel_Loot_Containers_SettingsWidget
            // 
            flowLayoutPanel_Loot_Containers_SettingsWidget.AutoSize = true;
            flowLayoutPanel_Loot_Containers_SettingsWidget.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel_Loot_Containers_SettingsWidget.BackColor = SystemColors.Control;
            flowLayoutPanel_Loot_Containers_SettingsWidget.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel_Loot_Containers_SettingsWidget.Controls.Add(label30);
            flowLayoutPanel_Loot_Containers_SettingsWidget.Controls.Add(checkBox_Containers_SelectAll_SettingsWidget);
            flowLayoutPanel_Loot_Containers_SettingsWidget.Controls.Add(label31);
            flowLayoutPanel_Loot_Containers_SettingsWidget.Controls.Add(checkBox_Containers_HideSearched_SettingsWidget);
            flowLayoutPanel_Loot_Containers_SettingsWidget.Controls.Add(checkedListBox_Containers_SettingsWidget);
            flowLayoutPanel_Loot_Containers_SettingsWidget.Location = new Point(353, 82);
            flowLayoutPanel_Loot_Containers_SettingsWidget.Name = "flowLayoutPanel_Loot_Containers_SettingsWidget";
            flowLayoutPanel_Loot_Containers_SettingsWidget.Size = new Size(236, 152);
            flowLayoutPanel_Loot_Containers_SettingsWidget.TabIndex = 92;
            // 
            // label30
            // 
            label30.AutoSize = true;
            flowLayoutPanel_Loot_Containers_SettingsWidget.SetFlowBreak(label30, true);
            label30.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label30.Location = new Point(3, 0);
            label30.Name = "label30";
            label30.Size = new Size(96, 15);
            label30.TabIndex = 52;
            label30.Text = "Static Containers";
            // 
            // checkBox_Containers_SelectAll_SettingsWidget
            // 
            checkBox_Containers_SelectAll_SettingsWidget.AutoSize = true;
            checkBox_Containers_SelectAll_SettingsWidget.Checked = true;
            checkBox_Containers_SelectAll_SettingsWidget.CheckState = CheckState.Checked;
            checkBox_Containers_SelectAll_SettingsWidget.Location = new Point(3, 28);
            checkBox_Containers_SelectAll_SettingsWidget.Name = "checkBox_Containers_SelectAll_SettingsWidget";
            checkBox_Containers_SelectAll_SettingsWidget.Size = new Size(74, 19);
            checkBox_Containers_SelectAll_SettingsWidget.TabIndex = 61;
            checkBox_Containers_SelectAll_SettingsWidget.Text = "Select All";
            checkBox_Containers_SelectAll_SettingsWidget.UseVisualStyleBackColor = true;
            checkBox_Containers_SelectAll_SettingsWidget.CheckedChanged += checkBox_Containers_SelectAll_SettingsWidget_CheckedChanged;
            // 
            // label31
            // 
            label31.AutoSize = true;
            label31.Location = new Point(83, 25);
            label31.Name = "label31";
            label31.Size = new Size(0, 15);
            label31.TabIndex = 62;
            // 
            // checkBox_Containers_HideSearched_SettingsWidget
            // 
            checkBox_Containers_HideSearched_SettingsWidget.AutoSize = true;
            flowLayoutPanel_Loot_Containers_SettingsWidget.SetFlowBreak(checkBox_Containers_HideSearched_SettingsWidget, true);
            checkBox_Containers_HideSearched_SettingsWidget.Location = new Point(89, 28);
            checkBox_Containers_HideSearched_SettingsWidget.Name = "checkBox_Containers_HideSearched_SettingsWidget";
            checkBox_Containers_HideSearched_SettingsWidget.Size = new Size(102, 19);
            checkBox_Containers_HideSearched_SettingsWidget.TabIndex = 63;
            checkBox_Containers_HideSearched_SettingsWidget.Text = "Hide Searched";
            checkBox_Containers_HideSearched_SettingsWidget.UseVisualStyleBackColor = true;
            checkBox_Containers_HideSearched_SettingsWidget.CheckedChanged += checkBox_Containers_HideSearched_SettingsWidget_CheckedChanged;
            // 
            // checkedListBox_Containers_SettingsWidget
            // 
            checkedListBox_Containers_SettingsWidget.FormattingEnabled = true;
            checkedListBox_Containers_SettingsWidget.Location = new Point(3, 53);
            checkedListBox_Containers_SettingsWidget.Name = "checkedListBox_Containers_SettingsWidget";
            checkedListBox_Containers_SettingsWidget.Size = new Size(228, 94);
            checkedListBox_Containers_SettingsWidget.TabIndex = 60;
         //   checkedListBox_Containers_SettingsWidget.ItemCheck += checkedListBox_Containers_SettingsWidget_ItemCheck;
            // 
            // checkBox_EnableMemWrite_SettingsWidget
            // 
            checkBox_EnableMemWrite_SettingsWidget.AutoSize = true;
            checkBox_EnableMemWrite_SettingsWidget.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBox_EnableMemWrite_SettingsWidget.Location = new Point(4, 282);
            checkBox_EnableMemWrite_SettingsWidget.Name = "checkBox_EnableMemWrite_SettingsWidget";
            checkBox_EnableMemWrite_SettingsWidget.Size = new Size(184, 19);
            checkBox_EnableMemWrite_SettingsWidget.TabIndex = 90;
            checkBox_EnableMemWrite_SettingsWidget.Text = "Enable Memory Writes (Risky)";
            checkBox_EnableMemWrite_SettingsWidget.UseVisualStyleBackColor = true;
            // 
            // checkBox_AdvancedMemWrites_SettingsWidget
            // 
            checkBox_AdvancedMemWrites_SettingsWidget.AutoSize = true;
            checkBox_AdvancedMemWrites_SettingsWidget.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            checkBox_AdvancedMemWrites_SettingsWidget.Location = new Point(4, 307);
            checkBox_AdvancedMemWrites_SettingsWidget.Name = "checkBox_AdvancedMemWrites_SettingsWidget";
            checkBox_AdvancedMemWrites_SettingsWidget.Size = new Size(246, 19);
            checkBox_AdvancedMemWrites_SettingsWidget.TabIndex = 91;
            checkBox_AdvancedMemWrites_SettingsWidget.Text = "Enable Advanced MemWrites (Very Risky)";
            checkBox_AdvancedMemWrites_SettingsWidget.UseVisualStyleBackColor = true;
            // 
            // button_StartESP_SettingsWidget
            // 
            button_StartESP_SettingsWidget.Anchor = AnchorStyles.Right;
            button_StartESP_SettingsWidget.FlatStyle = FlatStyle.Popup;
            button_StartESP_SettingsWidget.ForeColor = SystemColors.ControlText;
            button_StartESP_SettingsWidget.Location = new Point(302, 3);
            button_StartESP_SettingsWidget.Name = "button_StartESP_SettingsWidget";
            button_StartESP_SettingsWidget.Size = new Size(107, 23);
            button_StartESP_SettingsWidget.TabIndex = 89;
            button_StartESP_SettingsWidget.Text = "Start ESP";
            button_StartESP_SettingsWidget.UseVisualStyleBackColor = true;
            button_StartESP_SettingsWidget.Click += button_StartESP_SettingsWidget_Click;
            // 
            // checkedListBox_QuestHelper_SettingsWidget
            // 
            checkedListBox_QuestHelper_SettingsWidget.BorderStyle = BorderStyle.FixedSingle;
            checkedListBox_QuestHelper_SettingsWidget.FormattingEnabled = true;
            checkedListBox_QuestHelper_SettingsWidget.Location = new Point(4, 82);
            checkedListBox_QuestHelper_SettingsWidget.Name = "checkedListBox_QuestHelper_SettingsWidget";
            checkedListBox_QuestHelper_SettingsWidget.Size = new Size(343, 128);
            checkedListBox_QuestHelper_SettingsWidget.TabIndex = 48;
            checkedListBox_QuestHelper_SettingsWidget.ItemCheck += checkedListBox_QuestHelper_SettingsWidget_ItemCheck;
            // 
            // tabPage2
            // 
            tabPage2.BackColor = Color.Transparent;
            tabPage2.BorderStyle = BorderStyle.FixedSingle;
            tabPage2.Controls.Add(button_RandomBoneCfg_SettingsWidget);
            tabPage2.Controls.Add(label10);
            tabPage2.Controls.Add(comboBox_AimbotTarget_SettingsWidget);
            tabPage2.Controls.Add(checkBox_AimRandomBone_SettingsWidget);
            tabPage2.Controls.Add(checkBox_AimHeadAI_SettingsWidget);
            tabPage2.Controls.Add(label_AimFOV_SettingsWidget);
            tabPage2.Controls.Add(trackBar_AimFOV_SettingsWidget);
            tabPage2.Controls.Add(checkBox_AimbotDisableReLock_SettingsWidget);
            tabPage2.Controls.Add(radioButton_AimTarget_FOV_SettingsWidget);
            tabPage2.Controls.Add(radioButton_AimTarget_CQB_SettingsWidget);
            tabPage2.Controls.Add(checkBox_SA_AutoBone_SettingsWidget);
            tabPage2.Controls.Add(checkBox_SA_SafeLock_SettingsWidget);
            tabPage2.Controls.Add(checkBox_AimBotEnabled_SettingsWidget);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(592, 330);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Aim Bot";
            // 
            // button_RandomBoneCfg_SettingsWidget
            // 
            button_RandomBoneCfg_SettingsWidget.BackColor = SystemColors.Control;
            button_RandomBoneCfg_SettingsWidget.Enabled = false;
            button_RandomBoneCfg_SettingsWidget.Location = new Point(276, 46);
            button_RandomBoneCfg_SettingsWidget.Name = "button_RandomBoneCfg_SettingsWidget";
            button_RandomBoneCfg_SettingsWidget.Size = new Size(57, 28);
            button_RandomBoneCfg_SettingsWidget.TabIndex = 73;
            button_RandomBoneCfg_SettingsWidget.Text = "Cfg";
            button_RandomBoneCfg_SettingsWidget.UseVisualStyleBackColor = false;
            button_RandomBoneCfg_SettingsWidget.Click += button_RandomBoneCfg_SettingsWidget_Click;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(166, 28);
            label10.Name = "label10";
            label10.Size = new Size(40, 15);
            label10.TabIndex = 72;
            label10.Text = "Target";
            // 
            // comboBox_AimbotTarget_SettingsWidget
            // 
            comboBox_AimbotTarget_SettingsWidget.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_AimbotTarget_SettingsWidget.FormattingEnabled = true;
            comboBox_AimbotTarget_SettingsWidget.Location = new Point(212, 23);
            comboBox_AimbotTarget_SettingsWidget.Name = "comboBox_AimbotTarget_SettingsWidget";
            comboBox_AimbotTarget_SettingsWidget.Size = new Size(121, 23);
            comboBox_AimbotTarget_SettingsWidget.TabIndex = 71;
            comboBox_AimbotTarget_SettingsWidget.SelectedIndexChanged += ComboBox_AimbotTarget_SettingsWidget_SelectedIndexChanged;
            // 
            // checkBox_AimRandomBone_SettingsWidget
            // 
            checkBox_AimRandomBone_SettingsWidget.AutoSize = true;
            checkBox_AimRandomBone_SettingsWidget.Location = new Point(166, 52);
            checkBox_AimRandomBone_SettingsWidget.Name = "checkBox_AimRandomBone_SettingsWidget";
            checkBox_AimRandomBone_SettingsWidget.Size = new Size(101, 19);
            checkBox_AimRandomBone_SettingsWidget.TabIndex = 70;
            checkBox_AimRandomBone_SettingsWidget.Text = "Random Bone";
            checkBox_AimRandomBone_SettingsWidget.UseVisualStyleBackColor = true;
            checkBox_AimRandomBone_SettingsWidget.CheckedChanged += checkBox_AimRandomBone_SettingsWidget_CheckedChanged;
            // 
            // checkBox_AimHeadAI_SettingsWidget
            // 
            checkBox_AimHeadAI_SettingsWidget.AutoSize = true;
            checkBox_AimHeadAI_SettingsWidget.Checked = true;
            checkBox_AimHeadAI_SettingsWidget.CheckState = CheckState.Checked;
            checkBox_AimHeadAI_SettingsWidget.Location = new Point(166, 2);
            checkBox_AimHeadAI_SettingsWidget.Name = "checkBox_AimHeadAI_SettingsWidget";
            checkBox_AimHeadAI_SettingsWidget.Size = new Size(91, 19);
            checkBox_AimHeadAI_SettingsWidget.TabIndex = 69;
            checkBox_AimHeadAI_SettingsWidget.Text = "Headshot AI";
            checkBox_AimHeadAI_SettingsWidget.UseVisualStyleBackColor = true;
            checkBox_AimHeadAI_SettingsWidget.CheckedChanged += checkBox_AimHeadAI_SettingsWidget_CheckedChanged;
            // 
            // label_AimFOV_SettingsWidget
            // 
            label_AimFOV_SettingsWidget.AutoSize = true;
            label_AimFOV_SettingsWidget.Location = new Point(3, 124);
            label_AimFOV_SettingsWidget.Name = "label_AimFOV_SettingsWidget";
            label_AimFOV_SettingsWidget.Size = new Size(50, 15);
            label_AimFOV_SettingsWidget.TabIndex = 68;
            label_AimFOV_SettingsWidget.Text = "FOV 150";
            // 
            // trackBar_AimFOV_SettingsWidget
            // 
            trackBar_AimFOV_SettingsWidget.BackColor = SystemColors.Window;
            trackBar_AimFOV_SettingsWidget.Location = new Point(59, 124);
            trackBar_AimFOV_SettingsWidget.Maximum = 500;
            trackBar_AimFOV_SettingsWidget.Minimum = 5;
            trackBar_AimFOV_SettingsWidget.Name = "trackBar_AimFOV_SettingsWidget";
            trackBar_AimFOV_SettingsWidget.Size = new Size(78, 45);
            trackBar_AimFOV_SettingsWidget.TabIndex = 67;
            trackBar_AimFOV_SettingsWidget.TickStyle = TickStyle.None;
            trackBar_AimFOV_SettingsWidget.Value = 150;
            trackBar_AimFOV_SettingsWidget.ValueChanged += TrackBar_AimFOV_SettingsWidget_ValueChanged;
            // 
            // checkBox_AimbotDisableReLock_SettingsWidget
            // 
            checkBox_AimbotDisableReLock_SettingsWidget.AutoSize = true;
            checkBox_AimbotDisableReLock_SettingsWidget.Location = new Point(2, 102);
            checkBox_AimbotDisableReLock_SettingsWidget.Name = "checkBox_AimbotDisableReLock_SettingsWidget";
            checkBox_AimbotDisableReLock_SettingsWidget.Size = new Size(110, 19);
            checkBox_AimbotDisableReLock_SettingsWidget.TabIndex = 66;
            checkBox_AimbotDisableReLock_SettingsWidget.Text = "Disable Re-Lock";
            checkBox_AimbotDisableReLock_SettingsWidget.UseVisualStyleBackColor = true;
            checkBox_AimbotDisableReLock_SettingsWidget.CheckedChanged += checkBox_AimbotDisableReLock_SettingsWidget_CheckedChanged;
            // 
            // radioButton_AimTarget_FOV_SettingsWidget
            // 
            radioButton_AimTarget_FOV_SettingsWidget.AutoSize = true;
            radioButton_AimTarget_FOV_SettingsWidget.Checked = true;
            radioButton_AimTarget_FOV_SettingsWidget.Location = new Point(2, 77);
            radioButton_AimTarget_FOV_SettingsWidget.Name = "radioButton_AimTarget_FOV_SettingsWidget";
            radioButton_AimTarget_FOV_SettingsWidget.Size = new Size(47, 19);
            radioButton_AimTarget_FOV_SettingsWidget.TabIndex = 64;
            radioButton_AimTarget_FOV_SettingsWidget.TabStop = true;
            radioButton_AimTarget_FOV_SettingsWidget.Text = "FOV";
            radioButton_AimTarget_FOV_SettingsWidget.UseVisualStyleBackColor = true;
            radioButton_AimTarget_FOV_SettingsWidget.CheckedChanged += radioButton_AimTarget_FOV_SettingsWidget_CheckedChanged;
            // 
            // radioButton_AimTarget_CQB_SettingsWidget
            // 
            radioButton_AimTarget_CQB_SettingsWidget.AutoSize = true;
            radioButton_AimTarget_CQB_SettingsWidget.Location = new Point(55, 77);
            radioButton_AimTarget_CQB_SettingsWidget.Name = "radioButton_AimTarget_CQB_SettingsWidget";
            radioButton_AimTarget_CQB_SettingsWidget.Size = new Size(49, 19);
            radioButton_AimTarget_CQB_SettingsWidget.TabIndex = 65;
            radioButton_AimTarget_CQB_SettingsWidget.Text = "CQB";
            radioButton_AimTarget_CQB_SettingsWidget.UseVisualStyleBackColor = true;
            radioButton_AimTarget_CQB_SettingsWidget.CheckedChanged += radioButton_AimTarget_CQB_SettingsWidget_CheckedChanged;
            // 
            // checkBox_SA_AutoBone_SettingsWidget
            // 
            checkBox_SA_AutoBone_SettingsWidget.AutoSize = true;
            checkBox_SA_AutoBone_SettingsWidget.Location = new Point(2, 52);
            checkBox_SA_AutoBone_SettingsWidget.Name = "checkBox_SA_AutoBone_SettingsWidget";
            checkBox_SA_AutoBone_SettingsWidget.Size = new Size(82, 19);
            checkBox_SA_AutoBone_SettingsWidget.TabIndex = 63;
            checkBox_SA_AutoBone_SettingsWidget.Text = "Auto Bone";
            checkBox_SA_AutoBone_SettingsWidget.UseVisualStyleBackColor = true;
            checkBox_SA_AutoBone_SettingsWidget.CheckedChanged += checkBox_SA_AutoBone_SettingsWidget_CheckedChanged;
            // 
            // checkBox_SA_SafeLock_SettingsWidget
            // 
            checkBox_SA_SafeLock_SettingsWidget.AutoSize = true;
            checkBox_SA_SafeLock_SettingsWidget.Location = new Point(2, 27);
            checkBox_SA_SafeLock_SettingsWidget.Name = "checkBox_SA_SafeLock_SettingsWidget";
            checkBox_SA_SafeLock_SettingsWidget.Size = new Size(76, 19);
            checkBox_SA_SafeLock_SettingsWidget.TabIndex = 62;
            checkBox_SA_SafeLock_SettingsWidget.Text = "Safe Lock";
            checkBox_SA_SafeLock_SettingsWidget.UseVisualStyleBackColor = true;
            checkBox_SA_SafeLock_SettingsWidget.CheckedChanged += checkBox_SA_SafeLock_SettingsWidget_CheckedChanged;
            // 
            // checkBox_AimBotEnabled_SettingsWidget
            // 
            checkBox_AimBotEnabled_SettingsWidget.AutoSize = true;
            checkBox_AimBotEnabled_SettingsWidget.Location = new Point(2, 2);
            checkBox_AimBotEnabled_SettingsWidget.Name = "checkBox_AimBotEnabled_SettingsWidget";
            checkBox_AimBotEnabled_SettingsWidget.Size = new Size(104, 19);
            checkBox_AimBotEnabled_SettingsWidget.TabIndex = 61;
            checkBox_AimBotEnabled_SettingsWidget.Text = "Aimbot (Risky)";
            checkBox_AimBotEnabled_SettingsWidget.UseVisualStyleBackColor = true;
            checkBox_AimBotEnabled_SettingsWidget.CheckedChanged += checkBox_AimBotEnabled_SettingsWidget_CheckedChanged;
            // 
            // tabPage3
            // 
            tabPage3.BackColor = SystemColors.Control;
            tabPage3.Controls.Add(label5);
            tabPage3.Controls.Add(label1);
            tabPage3.Controls.Add(label_EspLineScale);
            tabPage3.Controls.Add(trackBar_EspLineScale);
            tabPage3.Controls.Add(label_EspLootDist);
            tabPage3.Controls.Add(trackBar_EspLootDist);
            tabPage3.Controls.Add(label_EspImpLootDist);
            tabPage3.Controls.Add(trackBar_EspImpLootDist);
            tabPage3.Controls.Add(label_ESPContainerDist);
            tabPage3.Controls.Add(trackBar_ESPContainerDist);
            tabPage3.Controls.Add(label_EspQuestHelperDist);
            tabPage3.Controls.Add(trackBar_EspQuestHelperDist);
            tabPage3.Controls.Add(label_EspExplosivesDist);
            tabPage3.Controls.Add(trackBar_EspGrenadeDist);
            tabPage3.Controls.Add(label_EspFontScale);
            tabPage3.Controls.Add(trackBar_EspFontScale);
            tabPage3.Controls.Add(flowLayoutPanel_ESP_AIRender);
            tabPage3.Controls.Add(flowLayoutPanel_ESP_PlayerRender);
            tabPage3.Controls.Add(checkBox_ESP_FPS);
            tabPage3.Controls.Add(checkBox_ESP_ShowMines);
            tabPage3.Controls.Add(checkBox_ESP_FireportAim);
            tabPage3.Controls.Add(checkBox_ESP_AimFov);
            tabPage3.Controls.Add(checkBox_ESP_AimLock);
            tabPage3.Controls.Add(checkBox_ESP_RaidStats);
            tabPage3.Controls.Add(checkBox_ESP_StatusText);
            tabPage3.Controls.Add(checkBox_ESP_Loot);
            tabPage3.Controls.Add(checkBox_ESP_Exfils);
            tabPage3.Controls.Add(checkBox_ESP_Explosives);
            tabPage3.Controls.Add(checkBox_ESP_ShowMag);
            tabPage3.Controls.Add(checkBox_ESP_Dist);
            tabPage3.Controls.Add(label11);
            tabPage3.Controls.Add(label_Width);
            tabPage3.Controls.Add(textBox_ResWidth);
            tabPage3.Controls.Add(label_Height);
            tabPage3.Controls.Add(textBox_ResHeight);
            tabPage3.Controls.Add(button_DetectRes);
            tabPage3.Location = new Point(4, 24);
            tabPage3.Name = "tabPage3";
            tabPage3.Padding = new Padding(3);
            tabPage3.Size = new Size(592, 330);
            tabPage3.TabIndex = 2;
            tabPage3.Text = "ESP";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 34F, FontStyle.Bold);
            label5.ForeColor = Color.Red;
            label5.Location = new Point(7, 149);
            label5.Name = "label5";
            label5.Size = new Size(576, 62);
            label5.TabIndex = 98;
            label5.Text = "USE MAIN SETTINGS TAB";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(31, 38);
            label1.Name = "label1";
            label1.Size = new Size(359, 65);
            label1.TabIndex = 97;
            label1.Text = "NOT FINISHED";
            // 
            // label_EspLineScale
            // 
            label_EspLineScale.Anchor = AnchorStyles.Right;
            label_EspLineScale.AutoSize = true;
            label_EspLineScale.Location = new Point(3, 294);
            label_EspLineScale.Name = "label_EspLineScale";
            label_EspLineScale.Size = new Size(83, 15);
            label_EspLineScale.TabIndex = 95;
            label_EspLineScale.Text = "Line Scale 1.00";
            // 
            // trackBar_EspLineScale
            // 
            trackBar_EspLineScale.Anchor = AnchorStyles.Right;
            trackBar_EspLineScale.BackColor = SystemColors.Window;
            trackBar_EspLineScale.Location = new Point(92, 279);
            trackBar_EspLineScale.Maximum = 200;
            trackBar_EspLineScale.Minimum = 10;
            trackBar_EspLineScale.Name = "trackBar_EspLineScale";
            trackBar_EspLineScale.Size = new Size(77, 45);
            trackBar_EspLineScale.TabIndex = 96;
            trackBar_EspLineScale.TickStyle = TickStyle.None;
            trackBar_EspLineScale.Value = 100;
            // 
            // label_EspLootDist
            // 
            label_EspLootDist.Anchor = AnchorStyles.Right;
            label_EspLootDist.AutoSize = true;
            label_EspLootDist.Location = new Point(3, 194);
            label_EspLootDist.Name = "label_EspLootDist";
            label_EspLootDist.Size = new Size(69, 15);
            label_EspLootDist.TabIndex = 88;
            label_EspLootDist.Text = "Loot Dist 50";
            // 
            // trackBar_EspLootDist
            // 
            trackBar_EspLootDist.Anchor = AnchorStyles.Right;
            trackBar_EspLootDist.BackColor = SystemColors.Window;
            trackBar_EspLootDist.Location = new Point(78, 179);
            trackBar_EspLootDist.Maximum = 1000;
            trackBar_EspLootDist.Minimum = 5;
            trackBar_EspLootDist.Name = "trackBar_EspLootDist";
            trackBar_EspLootDist.Size = new Size(82, 45);
            trackBar_EspLootDist.TabIndex = 83;
            trackBar_EspLootDist.TickStyle = TickStyle.None;
            trackBar_EspLootDist.Value = 50;
            // 
            // label_EspImpLootDist
            // 
            label_EspImpLootDist.Anchor = AnchorStyles.Right;
            label_EspImpLootDist.AutoSize = true;
            label_EspImpLootDist.Location = new Point(166, 194);
            label_EspImpLootDist.Name = "label_EspImpLootDist";
            label_EspImpLootDist.Size = new Size(93, 15);
            label_EspImpLootDist.TabIndex = 89;
            label_EspImpLootDist.Text = "Imp Loot Dist 50";
            // 
            // trackBar_EspImpLootDist
            // 
            trackBar_EspImpLootDist.Anchor = AnchorStyles.Right;
            trackBar_EspImpLootDist.BackColor = SystemColors.Window;
            trackBar_EspImpLootDist.Location = new Point(265, 179);
            trackBar_EspImpLootDist.Maximum = 1000;
            trackBar_EspImpLootDist.Minimum = 5;
            trackBar_EspImpLootDist.Name = "trackBar_EspImpLootDist";
            trackBar_EspImpLootDist.Size = new Size(82, 45);
            trackBar_EspImpLootDist.TabIndex = 90;
            trackBar_EspImpLootDist.TickStyle = TickStyle.None;
            trackBar_EspImpLootDist.Value = 50;
            // 
            // label_ESPContainerDist
            // 
            label_ESPContainerDist.Anchor = AnchorStyles.Right;
            label_ESPContainerDist.AutoSize = true;
            label_ESPContainerDist.Location = new Point(353, 194);
            label_ESPContainerDist.Name = "label_ESPContainerDist";
            label_ESPContainerDist.Size = new Size(97, 15);
            label_ESPContainerDist.TabIndex = 94;
            label_ESPContainerDist.Text = "Container Dist 50";
            // 
            // trackBar_ESPContainerDist
            // 
            trackBar_ESPContainerDist.Anchor = AnchorStyles.Right;
            trackBar_ESPContainerDist.BackColor = SystemColors.Window;
            trackBar_ESPContainerDist.Location = new Point(456, 179);
            trackBar_ESPContainerDist.Maximum = 1000;
            trackBar_ESPContainerDist.Minimum = 5;
            trackBar_ESPContainerDist.Name = "trackBar_ESPContainerDist";
            trackBar_ESPContainerDist.Size = new Size(78, 45);
            trackBar_ESPContainerDist.TabIndex = 93;
            trackBar_ESPContainerDist.TickStyle = TickStyle.None;
            trackBar_ESPContainerDist.Value = 50;
            // 
            // label_EspQuestHelperDist
            // 
            label_EspQuestHelperDist.Anchor = AnchorStyles.Right;
            label_EspQuestHelperDist.AutoSize = true;
            label_EspQuestHelperDist.Location = new Point(3, 245);
            label_EspQuestHelperDist.Name = "label_EspQuestHelperDist";
            label_EspQuestHelperDist.Size = new Size(82, 15);
            label_EspQuestHelperDist.TabIndex = 91;
            label_EspQuestHelperDist.Text = "Quest Dist 100";
            // 
            // trackBar_EspQuestHelperDist
            // 
            trackBar_EspQuestHelperDist.Anchor = AnchorStyles.Right;
            trackBar_EspQuestHelperDist.BackColor = SystemColors.Window;
            trackBar_EspQuestHelperDist.Location = new Point(91, 230);
            trackBar_EspQuestHelperDist.Maximum = 1000;
            trackBar_EspQuestHelperDist.Minimum = 5;
            trackBar_EspQuestHelperDist.Name = "trackBar_EspQuestHelperDist";
            trackBar_EspQuestHelperDist.Size = new Size(82, 45);
            trackBar_EspQuestHelperDist.TabIndex = 92;
            trackBar_EspQuestHelperDist.TickStyle = TickStyle.None;
            trackBar_EspQuestHelperDist.Value = 100;
            // 
            // label_EspExplosivesDist
            // 
            label_EspExplosivesDist.Anchor = AnchorStyles.Right;
            label_EspExplosivesDist.AutoSize = true;
            label_EspExplosivesDist.Location = new Point(179, 245);
            label_EspExplosivesDist.Name = "label_EspExplosivesDist";
            label_EspExplosivesDist.Size = new Size(98, 15);
            label_EspExplosivesDist.TabIndex = 85;
            label_EspExplosivesDist.Text = "Explosives Dist 50";
            // 
            // trackBar_EspGrenadeDist
            // 
            trackBar_EspGrenadeDist.Anchor = AnchorStyles.Right;
            trackBar_EspGrenadeDist.BackColor = SystemColors.Window;
            trackBar_EspGrenadeDist.Location = new Point(283, 230);
            trackBar_EspGrenadeDist.Maximum = 1000;
            trackBar_EspGrenadeDist.Minimum = 15;
            trackBar_EspGrenadeDist.Name = "trackBar_EspGrenadeDist";
            trackBar_EspGrenadeDist.Size = new Size(82, 45);
            trackBar_EspGrenadeDist.TabIndex = 87;
            trackBar_EspGrenadeDist.TickStyle = TickStyle.None;
            trackBar_EspGrenadeDist.Value = 50;
            // 
            // label_EspFontScale
            // 
            label_EspFontScale.Anchor = AnchorStyles.Right;
            label_EspFontScale.AutoSize = true;
            label_EspFontScale.Location = new Point(371, 245);
            label_EspFontScale.Name = "label_EspFontScale";
            label_EspFontScale.Size = new Size(85, 15);
            label_EspFontScale.TabIndex = 84;
            label_EspFontScale.Text = "Font Scale 1.00";
            // 
            // trackBar_EspFontScale
            // 
            trackBar_EspFontScale.Anchor = AnchorStyles.Right;
            trackBar_EspFontScale.BackColor = SystemColors.Window;
            trackBar_EspFontScale.Location = new Point(462, 230);
            trackBar_EspFontScale.Maximum = 200;
            trackBar_EspFontScale.Minimum = 50;
            trackBar_EspFontScale.Name = "trackBar_EspFontScale";
            trackBar_EspFontScale.Size = new Size(77, 45);
            trackBar_EspFontScale.TabIndex = 86;
            trackBar_EspFontScale.TickStyle = TickStyle.None;
            trackBar_EspFontScale.Value = 100;
            // 
            // flowLayoutPanel_ESP_AIRender
            // 
            flowLayoutPanel_ESP_AIRender.AutoSize = true;
            flowLayoutPanel_ESP_AIRender.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel_ESP_AIRender.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel_ESP_AIRender.Controls.Add(label19);
            flowLayoutPanel_ESP_AIRender.Controls.Add(radioButton_ESPAIRender_None);
            flowLayoutPanel_ESP_AIRender.Controls.Add(radioButton_ESPAIRender_Bones);
            flowLayoutPanel_ESP_AIRender.Controls.Add(radioButton_ESPAIRender_Box);
            flowLayoutPanel_ESP_AIRender.Controls.Add(radioButton_ESPAIRender_Presence);
            flowLayoutPanel_ESP_AIRender.Controls.Add(checkBox_ESPAIRender_Labels);
            flowLayoutPanel_ESP_AIRender.Controls.Add(checkBox_ESPAIRender_Weapons);
            flowLayoutPanel_ESP_AIRender.Controls.Add(checkBox_ESPAIRender_Dist);
            flowLayoutPanel_ESP_AIRender.Location = new Point(262, 99);
            flowLayoutPanel_ESP_AIRender.Name = "flowLayoutPanel_ESP_AIRender";
            flowLayoutPanel_ESP_AIRender.Size = new Size(253, 77);
            flowLayoutPanel_ESP_AIRender.TabIndex = 82;
            // 
            // label19
            // 
            label19.AutoSize = true;
            flowLayoutPanel_ESP_AIRender.SetFlowBreak(label19, true);
            label19.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.Location = new Point(3, 0);
            label19.Name = "label19";
            label19.Size = new Size(93, 15);
            label19.TabIndex = 74;
            label19.Text = "AI Render Mode";
            // 
            // radioButton_ESPAIRender_None
            // 
            radioButton_ESPAIRender_None.AutoSize = true;
            radioButton_ESPAIRender_None.Location = new Point(3, 28);
            radioButton_ESPAIRender_None.Name = "radioButton_ESPAIRender_None";
            radioButton_ESPAIRender_None.Size = new Size(54, 19);
            radioButton_ESPAIRender_None.TabIndex = 63;
            radioButton_ESPAIRender_None.Text = "None";
            radioButton_ESPAIRender_None.UseVisualStyleBackColor = true;
            // 
            // radioButton_ESPAIRender_Bones
            // 
            radioButton_ESPAIRender_Bones.AutoSize = true;
            radioButton_ESPAIRender_Bones.Checked = true;
            radioButton_ESPAIRender_Bones.Location = new Point(63, 28);
            radioButton_ESPAIRender_Bones.Name = "radioButton_ESPAIRender_Bones";
            radioButton_ESPAIRender_Bones.Size = new Size(57, 19);
            radioButton_ESPAIRender_Bones.TabIndex = 64;
            radioButton_ESPAIRender_Bones.TabStop = true;
            radioButton_ESPAIRender_Bones.Text = "Bones";
            radioButton_ESPAIRender_Bones.UseVisualStyleBackColor = true;
            // 
            // radioButton_ESPAIRender_Box
            // 
            radioButton_ESPAIRender_Box.AutoSize = true;
            radioButton_ESPAIRender_Box.Location = new Point(126, 28);
            radioButton_ESPAIRender_Box.Name = "radioButton_ESPAIRender_Box";
            radioButton_ESPAIRender_Box.Size = new Size(44, 19);
            radioButton_ESPAIRender_Box.TabIndex = 65;
            radioButton_ESPAIRender_Box.Text = "Box";
            radioButton_ESPAIRender_Box.UseVisualStyleBackColor = true;
            // 
            // radioButton_ESPAIRender_Presence
            // 
            radioButton_ESPAIRender_Presence.AutoSize = true;
            flowLayoutPanel_ESP_AIRender.SetFlowBreak(radioButton_ESPAIRender_Presence, true);
            radioButton_ESPAIRender_Presence.Location = new Point(176, 28);
            radioButton_ESPAIRender_Presence.Name = "radioButton_ESPAIRender_Presence";
            radioButton_ESPAIRender_Presence.Size = new Size(72, 19);
            radioButton_ESPAIRender_Presence.TabIndex = 67;
            radioButton_ESPAIRender_Presence.Text = "Presence";
            radioButton_ESPAIRender_Presence.UseVisualStyleBackColor = true;
            // 
            // checkBox_ESPAIRender_Labels
            // 
            checkBox_ESPAIRender_Labels.AutoSize = true;
            checkBox_ESPAIRender_Labels.Location = new Point(3, 53);
            checkBox_ESPAIRender_Labels.Name = "checkBox_ESPAIRender_Labels";
            checkBox_ESPAIRender_Labels.Size = new Size(59, 19);
            checkBox_ESPAIRender_Labels.TabIndex = 71;
            checkBox_ESPAIRender_Labels.Text = "Labels";
            checkBox_ESPAIRender_Labels.UseVisualStyleBackColor = true;
            // 
            // checkBox_ESPAIRender_Weapons
            // 
            checkBox_ESPAIRender_Weapons.AutoSize = true;
            checkBox_ESPAIRender_Weapons.Location = new Point(68, 53);
            checkBox_ESPAIRender_Weapons.Name = "checkBox_ESPAIRender_Weapons";
            checkBox_ESPAIRender_Weapons.Size = new Size(75, 19);
            checkBox_ESPAIRender_Weapons.TabIndex = 72;
            checkBox_ESPAIRender_Weapons.Text = "Weapons";
            checkBox_ESPAIRender_Weapons.UseVisualStyleBackColor = true;
            // 
            // checkBox_ESPAIRender_Dist
            // 
            checkBox_ESPAIRender_Dist.AutoSize = true;
            checkBox_ESPAIRender_Dist.Location = new Point(149, 53);
            checkBox_ESPAIRender_Dist.Name = "checkBox_ESPAIRender_Dist";
            checkBox_ESPAIRender_Dist.Size = new Size(46, 19);
            checkBox_ESPAIRender_Dist.TabIndex = 73;
            checkBox_ESPAIRender_Dist.Text = "Dist";
            checkBox_ESPAIRender_Dist.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel_ESP_PlayerRender
            // 
            flowLayoutPanel_ESP_PlayerRender.AutoSize = true;
            flowLayoutPanel_ESP_PlayerRender.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel_ESP_PlayerRender.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel_ESP_PlayerRender.Controls.Add(label18);
            flowLayoutPanel_ESP_PlayerRender.Controls.Add(radioButton_ESPRender_None);
            flowLayoutPanel_ESP_PlayerRender.Controls.Add(radioButton_ESPRender_Bones);
            flowLayoutPanel_ESP_PlayerRender.Controls.Add(radioButton_ESPRender_Box);
            flowLayoutPanel_ESP_PlayerRender.Controls.Add(radioButton_ESPRender_Presence);
            flowLayoutPanel_ESP_PlayerRender.Controls.Add(checkBox_ESPRender_Labels);
            flowLayoutPanel_ESP_PlayerRender.Controls.Add(checkBox_ESPRender_Weapons);
            flowLayoutPanel_ESP_PlayerRender.Controls.Add(checkBox_ESPRender_Dist);
            flowLayoutPanel_ESP_PlayerRender.Location = new Point(3, 98);
            flowLayoutPanel_ESP_PlayerRender.Name = "flowLayoutPanel_ESP_PlayerRender";
            flowLayoutPanel_ESP_PlayerRender.Size = new Size(253, 77);
            flowLayoutPanel_ESP_PlayerRender.TabIndex = 81;
            // 
            // label18
            // 
            label18.AutoSize = true;
            flowLayoutPanel_ESP_PlayerRender.SetFlowBreak(label18, true);
            label18.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label18.Location = new Point(3, 0);
            label18.Name = "label18";
            label18.Size = new Size(113, 15);
            label18.TabIndex = 71;
            label18.Text = "Player Render Mode";
            // 
            // radioButton_ESPRender_None
            // 
            radioButton_ESPRender_None.AutoSize = true;
            radioButton_ESPRender_None.Location = new Point(3, 28);
            radioButton_ESPRender_None.Name = "radioButton_ESPRender_None";
            radioButton_ESPRender_None.Size = new Size(54, 19);
            radioButton_ESPRender_None.TabIndex = 63;
            radioButton_ESPRender_None.Text = "None";
            radioButton_ESPRender_None.UseVisualStyleBackColor = true;
            // 
            // radioButton_ESPRender_Bones
            // 
            radioButton_ESPRender_Bones.AutoSize = true;
            radioButton_ESPRender_Bones.Checked = true;
            radioButton_ESPRender_Bones.Location = new Point(63, 28);
            radioButton_ESPRender_Bones.Name = "radioButton_ESPRender_Bones";
            radioButton_ESPRender_Bones.Size = new Size(57, 19);
            radioButton_ESPRender_Bones.TabIndex = 64;
            radioButton_ESPRender_Bones.TabStop = true;
            radioButton_ESPRender_Bones.Text = "Bones";
            radioButton_ESPRender_Bones.UseVisualStyleBackColor = true;
            // 
            // radioButton_ESPRender_Box
            // 
            radioButton_ESPRender_Box.AutoSize = true;
            radioButton_ESPRender_Box.Location = new Point(126, 28);
            radioButton_ESPRender_Box.Name = "radioButton_ESPRender_Box";
            radioButton_ESPRender_Box.Size = new Size(44, 19);
            radioButton_ESPRender_Box.TabIndex = 65;
            radioButton_ESPRender_Box.Text = "Box";
            radioButton_ESPRender_Box.UseVisualStyleBackColor = true;
            // 
            // radioButton_ESPRender_Presence
            // 
            radioButton_ESPRender_Presence.AutoSize = true;
            flowLayoutPanel_ESP_PlayerRender.SetFlowBreak(radioButton_ESPRender_Presence, true);
            radioButton_ESPRender_Presence.Location = new Point(176, 28);
            radioButton_ESPRender_Presence.Name = "radioButton_ESPRender_Presence";
            radioButton_ESPRender_Presence.Size = new Size(72, 19);
            radioButton_ESPRender_Presence.TabIndex = 67;
            radioButton_ESPRender_Presence.TabStop = true;
            radioButton_ESPRender_Presence.Text = "Presence";
            radioButton_ESPRender_Presence.UseVisualStyleBackColor = true;
            // 
            // checkBox_ESPRender_Labels
            // 
            checkBox_ESPRender_Labels.AutoSize = true;
            checkBox_ESPRender_Labels.Location = new Point(3, 53);
            checkBox_ESPRender_Labels.Name = "checkBox_ESPRender_Labels";
            checkBox_ESPRender_Labels.Size = new Size(59, 19);
            checkBox_ESPRender_Labels.TabIndex = 68;
            checkBox_ESPRender_Labels.Text = "Labels";
            checkBox_ESPRender_Labels.UseVisualStyleBackColor = true;
            // 
            // checkBox_ESPRender_Weapons
            // 
            checkBox_ESPRender_Weapons.AutoSize = true;
            checkBox_ESPRender_Weapons.Location = new Point(68, 53);
            checkBox_ESPRender_Weapons.Name = "checkBox_ESPRender_Weapons";
            checkBox_ESPRender_Weapons.Size = new Size(75, 19);
            checkBox_ESPRender_Weapons.TabIndex = 69;
            checkBox_ESPRender_Weapons.Text = "Weapons";
            checkBox_ESPRender_Weapons.UseVisualStyleBackColor = true;
            // 
            // checkBox_ESPRender_Dist
            // 
            checkBox_ESPRender_Dist.AutoSize = true;
            checkBox_ESPRender_Dist.Location = new Point(149, 53);
            checkBox_ESPRender_Dist.Name = "checkBox_ESPRender_Dist";
            checkBox_ESPRender_Dist.Size = new Size(46, 19);
            checkBox_ESPRender_Dist.TabIndex = 70;
            checkBox_ESPRender_Dist.Text = "Dist";
            checkBox_ESPRender_Dist.UseVisualStyleBackColor = true;
            // 
            // checkBox_ESP_FPS
            // 
            checkBox_ESP_FPS.AutoSize = true;
            checkBox_ESP_FPS.Location = new Point(219, 77);
            checkBox_ESP_FPS.Name = "checkBox_ESP_FPS";
            checkBox_ESP_FPS.Size = new Size(86, 19);
            checkBox_ESP_FPS.TabIndex = 80;
            checkBox_ESP_FPS.Text = "Display FPS";
            checkBox_ESP_FPS.UseVisualStyleBackColor = true;
            // 
            // checkBox_ESP_ShowMines
            // 
            checkBox_ESP_ShowMines.AutoSize = true;
            checkBox_ESP_ShowMines.Location = new Point(3, 77);
            checkBox_ESP_ShowMines.Name = "checkBox_ESP_ShowMines";
            checkBox_ESP_ShowMines.Size = new Size(90, 19);
            checkBox_ESP_ShowMines.TabIndex = 76;
            checkBox_ESP_ShowMines.Text = "Show Mines";
            checkBox_ESP_ShowMines.UseVisualStyleBackColor = true;
            // 
            // checkBox_ESP_FireportAim
            // 
            checkBox_ESP_FireportAim.AutoSize = true;
            checkBox_ESP_FireportAim.Location = new Point(3, 52);
            checkBox_ESP_FireportAim.Name = "checkBox_ESP_FireportAim";
            checkBox_ESP_FireportAim.Size = new Size(124, 19);
            checkBox_ESP_FireportAim.TabIndex = 78;
            checkBox_ESP_FireportAim.Text = "Show Fireport Aim";
            checkBox_ESP_FireportAim.UseVisualStyleBackColor = true;
            // 
            // checkBox_ESP_AimFov
            // 
            checkBox_ESP_AimFov.AutoSize = true;
            checkBox_ESP_AimFov.Location = new Point(133, 52);
            checkBox_ESP_AimFov.Name = "checkBox_ESP_AimFov";
            checkBox_ESP_AimFov.Size = new Size(105, 19);
            checkBox_ESP_AimFov.TabIndex = 74;
            checkBox_ESP_AimFov.Text = "Show Aim FOV";
            checkBox_ESP_AimFov.UseVisualStyleBackColor = true;
            // 
            // checkBox_ESP_AimLock
            // 
            checkBox_ESP_AimLock.AutoSize = true;
            checkBox_ESP_AimLock.Location = new Point(244, 52);
            checkBox_ESP_AimLock.Name = "checkBox_ESP_AimLock";
            checkBox_ESP_AimLock.Size = new Size(126, 19);
            checkBox_ESP_AimLock.TabIndex = 75;
            checkBox_ESP_AimLock.Text = "Show Aimbot Lock";
            checkBox_ESP_AimLock.UseVisualStyleBackColor = true;
            // 
            // checkBox_ESP_RaidStats
            // 
            checkBox_ESP_RaidStats.AutoSize = true;
            checkBox_ESP_RaidStats.Location = new Point(376, 52);
            checkBox_ESP_RaidStats.Name = "checkBox_ESP_RaidStats";
            checkBox_ESP_RaidStats.Size = new Size(109, 19);
            checkBox_ESP_RaidStats.TabIndex = 77;
            checkBox_ESP_RaidStats.Text = "Show Raid Stats";
            checkBox_ESP_RaidStats.UseVisualStyleBackColor = true;
            // 
            // checkBox_ESP_StatusText
            // 
            checkBox_ESP_StatusText.AutoSize = true;
            checkBox_ESP_StatusText.Location = new Point(99, 77);
            checkBox_ESP_StatusText.Name = "checkBox_ESP_StatusText";
            checkBox_ESP_StatusText.Size = new Size(114, 19);
            checkBox_ESP_StatusText.TabIndex = 79;
            checkBox_ESP_StatusText.Text = "Show Status Text";
            checkBox_ESP_StatusText.UseVisualStyleBackColor = true;
            // 
            // checkBox_ESP_Loot
            // 
            checkBox_ESP_Loot.AutoSize = true;
            checkBox_ESP_Loot.Location = new Point(6, 27);
            checkBox_ESP_Loot.Name = "checkBox_ESP_Loot";
            checkBox_ESP_Loot.Size = new Size(82, 19);
            checkBox_ESP_Loot.TabIndex = 64;
            checkBox_ESP_Loot.Text = "Show Loot";
            checkBox_ESP_Loot.UseVisualStyleBackColor = true;
            // 
            // checkBox_ESP_Exfils
            // 
            checkBox_ESP_Exfils.AutoSize = true;
            checkBox_ESP_Exfils.Location = new Point(94, 27);
            checkBox_ESP_Exfils.Name = "checkBox_ESP_Exfils";
            checkBox_ESP_Exfils.Size = new Size(84, 19);
            checkBox_ESP_Exfils.TabIndex = 61;
            checkBox_ESP_Exfils.Text = "Show Exfils";
            checkBox_ESP_Exfils.UseVisualStyleBackColor = true;
            // 
            // checkBox_ESP_Explosives
            // 
            checkBox_ESP_Explosives.AutoSize = true;
            checkBox_ESP_Explosives.Location = new Point(184, 27);
            checkBox_ESP_Explosives.Name = "checkBox_ESP_Explosives";
            checkBox_ESP_Explosives.Size = new Size(111, 19);
            checkBox_ESP_Explosives.TabIndex = 62;
            checkBox_ESP_Explosives.Text = "Show Explosives";
            checkBox_ESP_Explosives.UseVisualStyleBackColor = true;
            // 
            // checkBox_ESP_ShowMag
            // 
            checkBox_ESP_ShowMag.AutoSize = true;
            checkBox_ESP_ShowMag.Location = new Point(301, 27);
            checkBox_ESP_ShowMag.Name = "checkBox_ESP_ShowMag";
            checkBox_ESP_ShowMag.Size = new Size(109, 19);
            checkBox_ESP_ShowMag.TabIndex = 65;
            checkBox_ESP_ShowMag.Text = "Show Magazine";
            checkBox_ESP_ShowMag.UseVisualStyleBackColor = true;
            // 
            // checkBox_ESP_Dist
            // 
            checkBox_ESP_Dist.AutoSize = true;
            checkBox_ESP_Dist.Location = new Point(416, 27);
            checkBox_ESP_Dist.Name = "checkBox_ESP_Dist";
            checkBox_ESP_Dist.Size = new Size(108, 19);
            checkBox_ESP_Dist.TabIndex = 63;
            checkBox_ESP_Dist.Text = "Show Distances";
            checkBox_ESP_Dist.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(6, 3);
            label11.Name = "label11";
            label11.Size = new Size(206, 21);
            label11.TabIndex = 52;
            label11.Text = "Monitor Info (Aimbot/ESP)";
            // 
            // label_Width
            // 
            label_Width.AutoSize = true;
            label_Width.Location = new Point(213, 9);
            label_Width.Name = "label_Width";
            label_Width.Size = new Size(39, 15);
            label_Width.TabIndex = 49;
            label_Width.Text = "Width";
            // 
            // textBox_ResWidth
            // 
            textBox_ResWidth.Location = new Point(258, 5);
            textBox_ResWidth.MaxLength = 5;
            textBox_ResWidth.Name = "textBox_ResWidth";
            textBox_ResWidth.Size = new Size(51, 23);
            textBox_ResWidth.TabIndex = 47;
            textBox_ResWidth.Text = "1920";
            textBox_ResWidth.TextAlign = HorizontalAlignment.Center;
            // 
            // label_Height
            // 
            label_Height.AutoSize = true;
            label_Height.Location = new Point(315, 9);
            label_Height.Name = "label_Height";
            label_Height.Size = new Size(43, 15);
            label_Height.TabIndex = 50;
            label_Height.Text = "Height";
            // 
            // textBox_ResHeight
            // 
            textBox_ResHeight.Location = new Point(364, 5);
            textBox_ResHeight.MaxLength = 5;
            textBox_ResHeight.Name = "textBox_ResHeight";
            textBox_ResHeight.Size = new Size(51, 23);
            textBox_ResHeight.TabIndex = 48;
            textBox_ResHeight.Text = "1080";
            textBox_ResHeight.TextAlign = HorizontalAlignment.Center;
            // 
            // button_DetectRes
            // 
            button_DetectRes.Location = new Point(421, 2);
            button_DetectRes.Name = "button_DetectRes";
            button_DetectRes.Size = new Size(107, 28);
            button_DetectRes.TabIndex = 51;
            button_DetectRes.Text = "Auto-Detect";
            button_DetectRes.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            tabPage4.BackColor = SystemColors.Control;
            tabPage4.Controls.Add(label6);
            tabPage4.Controls.Add(label2);
            tabPage4.Controls.Add(radioButton_Chams_Basic);
            tabPage4.Controls.Add(radioButton_Chams_Visible);
            tabPage4.Controls.Add(radioButton_Chams_Vischeck);
            tabPage4.Controls.Add(label15);
            tabPage4.Controls.Add(textBox_VischeckVisColor);
            tabPage4.Controls.Add(textBox_VischeckInvisColor);
            tabPage4.Controls.Add(button_VischeckVisColorPick);
            tabPage4.Controls.Add(label33);
            tabPage4.Controls.Add(button_VischeckInvisColorPick);
            tabPage4.Location = new Point(4, 24);
            tabPage4.Name = "tabPage4";
            tabPage4.Padding = new Padding(3);
            tabPage4.Size = new Size(592, 330);
            tabPage4.TabIndex = 3;
            tabPage4.Text = "Chams";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 34F, FontStyle.Bold);
            label6.ForeColor = Color.Red;
            label6.Location = new Point(6, 198);
            label6.Name = "label6";
            label6.Size = new Size(576, 62);
            label6.TabIndex = 99;
            label6.Text = "USE MAIN SETTINGS TAB";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Red;
            label2.Location = new Point(117, 133);
            label2.Name = "label2";
            label2.Size = new Size(359, 65);
            label2.TabIndex = 98;
            label2.Text = "NOT FINISHED";
            // 
            // radioButton_Chams_Basic
            // 
            radioButton_Chams_Basic.AutoSize = true;
            radioButton_Chams_Basic.Checked = true;
            radioButton_Chams_Basic.Location = new Point(6, 3);
            radioButton_Chams_Basic.Name = "radioButton_Chams_Basic";
            radioButton_Chams_Basic.Size = new Size(52, 19);
            radioButton_Chams_Basic.TabIndex = 19;
            radioButton_Chams_Basic.TabStop = true;
            radioButton_Chams_Basic.Text = "Basic";
            radioButton_Chams_Basic.UseVisualStyleBackColor = true;
            // 
            // radioButton_Chams_Visible
            // 
            radioButton_Chams_Visible.AutoSize = true;
            radioButton_Chams_Visible.Enabled = false;
            radioButton_Chams_Visible.Location = new Point(6, 28);
            radioButton_Chams_Visible.Name = "radioButton_Chams_Visible";
            radioButton_Chams_Visible.Size = new Size(59, 19);
            radioButton_Chams_Visible.TabIndex = 23;
            radioButton_Chams_Visible.Text = "Visible";
            radioButton_Chams_Visible.UseVisualStyleBackColor = true;
            // 
            // radioButton_Chams_Vischeck
            // 
            radioButton_Chams_Vischeck.AutoSize = true;
            radioButton_Chams_Vischeck.Enabled = false;
            radioButton_Chams_Vischeck.Location = new Point(6, 53);
            radioButton_Chams_Vischeck.Name = "radioButton_Chams_Vischeck";
            radioButton_Chams_Vischeck.Size = new Size(71, 19);
            radioButton_Chams_Vischeck.TabIndex = 20;
            radioButton_Chams_Vischeck.Text = "Vischeck";
            radioButton_Chams_Vischeck.UseVisualStyleBackColor = true;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(96, 30);
            label15.Name = "label15";
            label15.Size = new Size(73, 15);
            label15.TabIndex = 22;
            label15.Text = "Visible Color";
            // 
            // textBox_VischeckVisColor
            // 
            textBox_VischeckVisColor.Location = new Point(184, 27);
            textBox_VischeckVisColor.MaxLength = 9;
            textBox_VischeckVisColor.Name = "textBox_VischeckVisColor";
            textBox_VischeckVisColor.Size = new Size(72, 23);
            textBox_VischeckVisColor.TabIndex = 21;
            // 
            // textBox_VischeckInvisColor
            // 
            textBox_VischeckInvisColor.Location = new Point(184, 52);
            textBox_VischeckInvisColor.MaxLength = 9;
            textBox_VischeckInvisColor.Name = "textBox_VischeckInvisColor";
            textBox_VischeckInvisColor.Size = new Size(72, 23);
            textBox_VischeckInvisColor.TabIndex = 24;
            // 
            // button_VischeckVisColorPick
            // 
            button_VischeckVisColorPick.Location = new Point(262, 26);
            button_VischeckVisColorPick.Name = "button_VischeckVisColorPick";
            button_VischeckVisColorPick.Size = new Size(75, 23);
            button_VischeckVisColorPick.TabIndex = 26;
            button_VischeckVisColorPick.Text = "Color";
            button_VischeckVisColorPick.UseVisualStyleBackColor = true;
            // 
            // label33
            // 
            label33.AutoSize = true;
            label33.Location = new Point(96, 55);
            label33.Name = "label33";
            label33.Size = new Size(82, 15);
            label33.TabIndex = 25;
            label33.Text = "Invisible Color";
            // 
            // button_VischeckInvisColorPick
            // 
            button_VischeckInvisColorPick.Location = new Point(262, 51);
            button_VischeckInvisColorPick.Name = "button_VischeckInvisColorPick";
            button_VischeckInvisColorPick.Size = new Size(75, 23);
            button_VischeckInvisColorPick.TabIndex = 27;
            button_VischeckInvisColorPick.Text = "Color";
            button_VischeckInvisColorPick.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            tabPage5.BackColor = SystemColors.Control;
            tabPage5.Controls.Add(label7);
            tabPage5.Controls.Add(label3);
            tabPage5.Controls.Add(label_WebRadarPassword);
            tabPage5.Controls.Add(textBox_WebRadarPassword);
            tabPage5.Controls.Add(linkLabel_WebRadarLink);
            tabPage5.Controls.Add(label_WebRadarTickRate);
            tabPage5.Controls.Add(textBox_WebRadarTickRate);
            tabPage5.Controls.Add(button_WebRadarStart);
            tabPage5.Controls.Add(checkBox_WebRadarUPNP);
            tabPage5.Controls.Add(label_WebRadarHost);
            tabPage5.Controls.Add(textBox_WebRadarBindIP);
            tabPage5.Controls.Add(label_WebRadarPort);
            tabPage5.Controls.Add(textBox_WebRadarPort);
            tabPage5.Location = new Point(4, 24);
            tabPage5.Name = "tabPage5";
            tabPage5.Padding = new Padding(3);
            tabPage5.Size = new Size(592, 330);
            tabPage5.TabIndex = 4;
            tabPage5.Text = "Web Radar";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 34F, FontStyle.Bold);
            label7.ForeColor = Color.Red;
            label7.Location = new Point(0, 179);
            label7.Name = "label7";
            label7.Size = new Size(576, 62);
            label7.TabIndex = 99;
            label7.Text = "USE MAIN SETTINGS TAB";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Red;
            label3.Location = new Point(94, 114);
            label3.Name = "label3";
            label3.Size = new Size(359, 65);
            label3.TabIndex = 98;
            label3.Text = "NOT FINISHED";
            // 
            // label_WebRadarPassword
            // 
            label_WebRadarPassword.Anchor = AnchorStyles.Right;
            label_WebRadarPassword.AutoSize = true;
            label_WebRadarPassword.Location = new Point(143, 69);
            label_WebRadarPassword.Name = "label_WebRadarPassword";
            label_WebRadarPassword.Size = new Size(57, 15);
            label_WebRadarPassword.TabIndex = 67;
            label_WebRadarPassword.Text = "Password";
            // 
            // textBox_WebRadarPassword
            // 
            textBox_WebRadarPassword.Anchor = AnchorStyles.Right;
            textBox_WebRadarPassword.Location = new Point(206, 65);
            textBox_WebRadarPassword.MaxLength = 10;
            textBox_WebRadarPassword.Name = "textBox_WebRadarPassword";
            textBox_WebRadarPassword.ReadOnly = true;
            textBox_WebRadarPassword.Size = new Size(104, 23);
            textBox_WebRadarPassword.TabIndex = 66;
            // 
            // linkLabel_WebRadarLink
            // 
            linkLabel_WebRadarLink.Anchor = AnchorStyles.Right;
            linkLabel_WebRadarLink.AutoSize = true;
            linkLabel_WebRadarLink.Location = new Point(316, 69);
            linkLabel_WebRadarLink.Name = "linkLabel_WebRadarLink";
            linkLabel_WebRadarLink.Size = new Size(42, 15);
            linkLabel_WebRadarLink.TabIndex = 68;
            linkLabel_WebRadarLink.TabStop = true;
            linkLabel_WebRadarLink.Text = "http://";
            // 
            // label_WebRadarTickRate
            // 
            label_WebRadarTickRate.Anchor = AnchorStyles.Right;
            label_WebRadarTickRate.AutoSize = true;
            label_WebRadarTickRate.Location = new Point(8, 69);
            label_WebRadarTickRate.Name = "label_WebRadarTickRate";
            label_WebRadarTickRate.Size = new Size(80, 15);
            label_WebRadarTickRate.TabIndex = 65;
            label_WebRadarTickRate.Text = "Tick Rate (Hz)";
            // 
            // textBox_WebRadarTickRate
            // 
            textBox_WebRadarTickRate.Anchor = AnchorStyles.Right;
            textBox_WebRadarTickRate.Location = new Point(94, 65);
            textBox_WebRadarTickRate.MaxLength = 3;
            textBox_WebRadarTickRate.Name = "textBox_WebRadarTickRate";
            textBox_WebRadarTickRate.Size = new Size(43, 23);
            textBox_WebRadarTickRate.TabIndex = 64;
            textBox_WebRadarTickRate.Text = "60";
            // 
            // button_WebRadarStart
            // 
            button_WebRadarStart.Location = new Point(8, 16);
            button_WebRadarStart.Name = "button_WebRadarStart";
            button_WebRadarStart.Size = new Size(96, 31);
            button_WebRadarStart.TabIndex = 62;
            button_WebRadarStart.Text = "Start";
            button_WebRadarStart.UseVisualStyleBackColor = true;
            // 
            // checkBox_WebRadarUPNP
            // 
            checkBox_WebRadarUPNP.Anchor = AnchorStyles.Right;
            checkBox_WebRadarUPNP.AutoSize = true;
            checkBox_WebRadarUPNP.Checked = true;
            checkBox_WebRadarUPNP.CheckState = CheckState.Checked;
            checkBox_WebRadarUPNP.Location = new Point(110, 22);
            checkBox_WebRadarUPNP.Name = "checkBox_WebRadarUPNP";
            checkBox_WebRadarUPNP.Size = new Size(55, 19);
            checkBox_WebRadarUPNP.TabIndex = 63;
            checkBox_WebRadarUPNP.Text = "UPnP";
            checkBox_WebRadarUPNP.UseVisualStyleBackColor = true;
            // 
            // label_WebRadarHost
            // 
            label_WebRadarHost.Anchor = AnchorStyles.Right;
            label_WebRadarHost.AutoSize = true;
            label_WebRadarHost.Location = new Point(171, 24);
            label_WebRadarHost.Name = "label_WebRadarHost";
            label_WebRadarHost.Size = new Size(44, 15);
            label_WebRadarHost.TabIndex = 59;
            label_WebRadarHost.Text = "Bind IP";
            // 
            // textBox_WebRadarBindIP
            // 
            textBox_WebRadarBindIP.Anchor = AnchorStyles.Right;
            textBox_WebRadarBindIP.Location = new Point(221, 20);
            textBox_WebRadarBindIP.MaxLength = 128;
            textBox_WebRadarBindIP.Name = "textBox_WebRadarBindIP";
            textBox_WebRadarBindIP.Size = new Size(154, 23);
            textBox_WebRadarBindIP.TabIndex = 58;
            // 
            // label_WebRadarPort
            // 
            label_WebRadarPort.Anchor = AnchorStyles.Right;
            label_WebRadarPort.AutoSize = true;
            label_WebRadarPort.Location = new Point(381, 24);
            label_WebRadarPort.Name = "label_WebRadarPort";
            label_WebRadarPort.Size = new Size(29, 15);
            label_WebRadarPort.TabIndex = 61;
            label_WebRadarPort.Text = "Port";
            // 
            // textBox_WebRadarPort
            // 
            textBox_WebRadarPort.Anchor = AnchorStyles.Right;
            textBox_WebRadarPort.Location = new Point(416, 20);
            textBox_WebRadarPort.MaxLength = 5;
            textBox_WebRadarPort.Name = "textBox_WebRadarPort";
            textBox_WebRadarPort.Size = new Size(57, 23);
            textBox_WebRadarPort.TabIndex = 60;
            // 
            // tabPage6
            // 
            tabPage6.BackColor = SystemColors.Control;
            tabPage6.Controls.Add(label8);
            tabPage6.Controls.Add(label4);
            tabPage6.Controls.Add(flowLayoutPanel_NoRecoil);
            tabPage6.Controls.Add(flowLayoutPanel_LTW);
            tabPage6.Controls.Add(flowLayoutPanel_WideLean);
            tabPage6.Controls.Add(checkBox_hideRaidcode);
            tabPage6.Controls.Add(checkBox_AntiPage);
            tabPage6.Controls.Add(checkBox_NoRecoilSway);
            tabPage6.Controls.Add(checkBox_WideLean);
            tabPage6.Controls.Add(checkBox_NoVisor);
            tabPage6.Controls.Add(checkBox_AlwaysDaySunny);
            tabPage6.Controls.Add(checkBox_NoWepMalf);
            tabPage6.Location = new Point(4, 24);
            tabPage6.Name = "tabPage6";
            tabPage6.Padding = new Padding(3);
            tabPage6.Size = new Size(592, 330);
            tabPage6.TabIndex = 5;
            tabPage6.Text = "Misc";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 34F, FontStyle.Bold);
            label8.ForeColor = Color.Red;
            label8.Location = new Point(20, 139);
            label8.Name = "label8";
            label8.Size = new Size(576, 62);
            label8.TabIndex = 99;
            label8.Text = "USE MAIN SETTINGS TAB";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Red;
            label4.Location = new Point(118, 0);
            label4.Name = "label4";
            label4.Size = new Size(359, 65);
            label4.TabIndex = 98;
            label4.Text = "NOT FINISHED";
            // 
            // flowLayoutPanel_NoRecoil
            // 
            flowLayoutPanel_NoRecoil.AutoSize = true;
            flowLayoutPanel_NoRecoil.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel_NoRecoil.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel_NoRecoil.Controls.Add(label16);
            flowLayoutPanel_NoRecoil.Controls.Add(label_Recoil);
            flowLayoutPanel_NoRecoil.Controls.Add(trackBar_NoRecoil);
            flowLayoutPanel_NoRecoil.Controls.Add(label_Sway);
            flowLayoutPanel_NoRecoil.Controls.Add(trackBar_NoSway);
            flowLayoutPanel_NoRecoil.Enabled = false;
            flowLayoutPanel_NoRecoil.Location = new Point(88, 37);
            flowLayoutPanel_NoRecoil.Name = "flowLayoutPanel_NoRecoil";
            flowLayoutPanel_NoRecoil.Size = new Size(277, 68);
            flowLayoutPanel_NoRecoil.TabIndex = 86;
            // 
            // label16
            // 
            label16.AutoSize = true;
            flowLayoutPanel_NoRecoil.SetFlowBreak(label16, true);
            label16.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.Location = new Point(3, 0);
            label16.Name = "label16";
            label16.Size = new Size(58, 15);
            label16.TabIndex = 52;
            label16.Text = "No Recoil";
            // 
            // label_Recoil
            // 
            label_Recoil.Anchor = AnchorStyles.Right;
            label_Recoil.AutoSize = true;
            label_Recoil.Location = new Point(3, 33);
            label_Recoil.Name = "label_Recoil";
            label_Recoil.Size = new Size(48, 15);
            label_Recoil.TabIndex = 50;
            label_Recoil.Text = "Recoil 0";
            // 
            // trackBar_NoRecoil
            // 
            trackBar_NoRecoil.Anchor = AnchorStyles.Right;
            trackBar_NoRecoil.BackColor = SystemColors.Window;
            trackBar_NoRecoil.Location = new Point(57, 18);
            trackBar_NoRecoil.Maximum = 100;
            trackBar_NoRecoil.Name = "trackBar_NoRecoil";
            trackBar_NoRecoil.Size = new Size(80, 45);
            trackBar_NoRecoil.TabIndex = 48;
            trackBar_NoRecoil.TickStyle = TickStyle.None;
            // 
            // label_Sway
            // 
            label_Sway.Anchor = AnchorStyles.Right;
            label_Sway.AutoSize = true;
            label_Sway.Location = new Point(143, 33);
            label_Sway.Name = "label_Sway";
            label_Sway.Size = new Size(43, 15);
            label_Sway.TabIndex = 51;
            label_Sway.Text = "Sway 0";
            // 
            // trackBar_NoSway
            // 
            trackBar_NoSway.Anchor = AnchorStyles.Right;
            trackBar_NoSway.BackColor = SystemColors.Window;
            trackBar_NoSway.Location = new Point(192, 18);
            trackBar_NoSway.Maximum = 100;
            trackBar_NoSway.Name = "trackBar_NoSway";
            trackBar_NoSway.Size = new Size(80, 45);
            trackBar_NoSway.TabIndex = 49;
            trackBar_NoSway.TickStyle = TickStyle.None;
            // 
            // flowLayoutPanel_LTW
            // 
            flowLayoutPanel_LTW.AutoSize = true;
            flowLayoutPanel_LTW.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel_LTW.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel_LTW.Controls.Add(label28);
            flowLayoutPanel_LTW.Controls.Add(label_LTWAmount);
            flowLayoutPanel_LTW.Controls.Add(trackBar_LTWAmount);
            flowLayoutPanel_LTW.Enabled = false;
            flowLayoutPanel_LTW.Location = new Point(8, 185);
            flowLayoutPanel_LTW.Name = "flowLayoutPanel_LTW";
            flowLayoutPanel_LTW.Size = new Size(236, 68);
            flowLayoutPanel_LTW.TabIndex = 87;
            // 
            // label28
            // 
            label28.AutoSize = true;
            flowLayoutPanel_LTW.SetFlowBreak(label28, true);
            label28.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label28.Location = new Point(3, 0);
            label28.Name = "label28";
            label28.Size = new Size(112, 15);
            label28.TabIndex = 3;
            label28.Text = "Loot Through Walls";
            // 
            // label_LTWAmount
            // 
            label_LTWAmount.Anchor = AnchorStyles.Right;
            label_LTWAmount.AutoSize = true;
            label_LTWAmount.Location = new Point(3, 33);
            label_LTWAmount.Name = "label_LTWAmount";
            label_LTWAmount.Size = new Size(110, 15);
            label_LTWAmount.TabIndex = 59;
            label_LTWAmount.Text = "Zoom Amount 2.00";
            // 
            // trackBar_LTWAmount
            // 
            trackBar_LTWAmount.Anchor = AnchorStyles.Right;
            trackBar_LTWAmount.BackColor = SystemColors.Window;
            flowLayoutPanel_LTW.SetFlowBreak(trackBar_LTWAmount, true);
            trackBar_LTWAmount.LargeChange = 10;
            trackBar_LTWAmount.Location = new Point(119, 18);
            trackBar_LTWAmount.Maximum = 300;
            trackBar_LTWAmount.Minimum = 100;
            trackBar_LTWAmount.Name = "trackBar_LTWAmount";
            trackBar_LTWAmount.Size = new Size(78, 45);
            trackBar_LTWAmount.TabIndex = 58;
            trackBar_LTWAmount.TickStyle = TickStyle.None;
            trackBar_LTWAmount.Value = 200;
            // 
            // flowLayoutPanel_WideLean
            // 
            flowLayoutPanel_WideLean.AutoSize = true;
            flowLayoutPanel_WideLean.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanel_WideLean.BorderStyle = BorderStyle.FixedSingle;
            flowLayoutPanel_WideLean.Controls.Add(label_WideLean);
            flowLayoutPanel_WideLean.Controls.Add(label21);
            flowLayoutPanel_WideLean.Controls.Add(comboBox_WideLeanMode);
            flowLayoutPanel_WideLean.Controls.Add(label_WideLeanAmt);
            flowLayoutPanel_WideLean.Controls.Add(trackBar_WideLeanAmt);
            flowLayoutPanel_WideLean.Enabled = false;
            flowLayoutPanel_WideLean.Location = new Point(252, 111);
            flowLayoutPanel_WideLean.Name = "flowLayoutPanel_WideLean";
            flowLayoutPanel_WideLean.Size = new Size(340, 68);
            flowLayoutPanel_WideLean.TabIndex = 88;
            // 
            // label_WideLean
            // 
            label_WideLean.AutoSize = true;
            flowLayoutPanel_WideLean.SetFlowBreak(label_WideLean, true);
            label_WideLean.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label_WideLean.Location = new Point(3, 0);
            label_WideLean.Name = "label_WideLean";
            label_WideLean.Size = new Size(63, 15);
            label_WideLean.TabIndex = 3;
            label_WideLean.Text = "Wide Lean";
            // 
            // label21
            // 
            label21.Anchor = AnchorStyles.Right;
            label21.AutoSize = true;
            label21.Location = new Point(3, 33);
            label21.Name = "label21";
            label21.Size = new Size(38, 15);
            label21.TabIndex = 63;
            label21.Text = "Mode";
            // 
            // comboBox_WideLeanMode
            // 
            comboBox_WideLeanMode.Anchor = AnchorStyles.Right;
            comboBox_WideLeanMode.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox_WideLeanMode.FormattingEnabled = true;
            comboBox_WideLeanMode.Location = new Point(47, 29);
            comboBox_WideLeanMode.Name = "comboBox_WideLeanMode";
            comboBox_WideLeanMode.Size = new Size(121, 23);
            comboBox_WideLeanMode.TabIndex = 62;
            // 
            // label_WideLeanAmt
            // 
            label_WideLeanAmt.Anchor = AnchorStyles.Right;
            label_WideLeanAmt.AutoSize = true;
            label_WideLeanAmt.Location = new Point(174, 33);
            label_WideLeanAmt.Name = "label_WideLeanAmt";
            label_WideLeanAmt.Size = new Size(75, 15);
            label_WideLeanAmt.TabIndex = 65;
            label_WideLeanAmt.Text = "Amount 0.50";
            // 
            // trackBar_WideLeanAmt
            // 
            trackBar_WideLeanAmt.Anchor = AnchorStyles.Right;
            trackBar_WideLeanAmt.BackColor = SystemColors.Window;
            trackBar_WideLeanAmt.Location = new Point(255, 18);
            trackBar_WideLeanAmt.Maximum = 100;
            trackBar_WideLeanAmt.Minimum = 1;
            trackBar_WideLeanAmt.Name = "trackBar_WideLeanAmt";
            trackBar_WideLeanAmt.Size = new Size(80, 45);
            trackBar_WideLeanAmt.TabIndex = 64;
            trackBar_WideLeanAmt.TickStyle = TickStyle.None;
            trackBar_WideLeanAmt.Value = 50;
            // 
            // checkBox_hideRaidcode
            // 
            checkBox_hideRaidcode.AutoSize = true;
            checkBox_hideRaidcode.Location = new Point(260, 256);
            checkBox_hideRaidcode.Name = "checkBox_hideRaidcode";
            checkBox_hideRaidcode.Size = new Size(105, 19);
            checkBox_hideRaidcode.TabIndex = 85;
            checkBox_hideRaidcode.Text = "Hide RaidCode";
            checkBox_hideRaidcode.UseVisualStyleBackColor = true;
            // 
            // checkBox_AntiPage
            // 
            checkBox_AntiPage.AutoSize = true;
            checkBox_AntiPage.Enabled = false;
            checkBox_AntiPage.Location = new Point(371, 256);
            checkBox_AntiPage.Name = "checkBox_AntiPage";
            checkBox_AntiPage.Size = new Size(79, 19);
            checkBox_AntiPage.TabIndex = 84;
            checkBox_AntiPage.Text = "Anti-Page";
            checkBox_AntiPage.UseVisualStyleBackColor = true;
            // 
            // checkBox_NoRecoilSway
            // 
            checkBox_NoRecoilSway.Anchor = AnchorStyles.Right;
            checkBox_NoRecoilSway.AutoSize = true;
            checkBox_NoRecoilSway.Location = new Point(118, 281);
            checkBox_NoRecoilSway.Name = "checkBox_NoRecoilSway";
            checkBox_NoRecoilSway.Size = new Size(147, 19);
            checkBox_NoRecoilSway.TabIndex = 79;
            checkBox_NoRecoilSway.Text = "No Recoil/Sway (Risky)";
            checkBox_NoRecoilSway.UseVisualStyleBackColor = true;
            // 
            // checkBox_WideLean
            // 
            checkBox_WideLean.Anchor = AnchorStyles.Right;
            checkBox_WideLean.AutoSize = true;
            checkBox_WideLean.Location = new Point(8, 308);
            checkBox_WideLean.Name = "checkBox_WideLean";
            checkBox_WideLean.Size = new Size(119, 19);
            checkBox_WideLean.TabIndex = 83;
            checkBox_WideLean.Text = "Wide Lean (Risky)";
            checkBox_WideLean.UseVisualStyleBackColor = true;
            // 
            // checkBox_NoVisor
            // 
            checkBox_NoVisor.Anchor = AnchorStyles.Right;
            checkBox_NoVisor.AutoSize = true;
            checkBox_NoVisor.Location = new Point(133, 308);
            checkBox_NoVisor.Name = "checkBox_NoVisor";
            checkBox_NoVisor.Size = new Size(71, 19);
            checkBox_NoVisor.TabIndex = 80;
            checkBox_NoVisor.Text = "No Visor";
            checkBox_NoVisor.UseVisualStyleBackColor = true;
            // 
            // checkBox_AlwaysDaySunny
            // 
            checkBox_AlwaysDaySunny.Anchor = AnchorStyles.Right;
            checkBox_AlwaysDaySunny.AutoSize = true;
            checkBox_AlwaysDaySunny.Location = new Point(210, 308);
            checkBox_AlwaysDaySunny.Name = "checkBox_AlwaysDaySunny";
            checkBox_AlwaysDaySunny.Size = new Size(124, 19);
            checkBox_AlwaysDaySunny.TabIndex = 81;
            checkBox_AlwaysDaySunny.Text = "Always Day/Sunny";
            checkBox_AlwaysDaySunny.UseVisualStyleBackColor = true;
            // 
            // checkBox_NoWepMalf
            // 
            checkBox_NoWepMalf.Anchor = AnchorStyles.Right;
            checkBox_NoWepMalf.AutoSize = true;
            checkBox_NoWepMalf.Location = new Point(340, 308);
            checkBox_NoWepMalf.Name = "checkBox_NoWepMalf";
            checkBox_NoWepMalf.Size = new Size(142, 19);
            checkBox_NoWepMalf.TabIndex = 82;
            checkBox_NoWepMalf.Text = "No Wep Malfunctions";
            checkBox_NoWepMalf.UseVisualStyleBackColor = true;
            // 
            // SettingsWidgetForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Black;
            ClientSize = new Size(601, 390);
            Controls.Add(tabControl1);
            Controls.Add(headerPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SettingsWidgetForm";
            Text = "SettingsWidgetForm";
            TopMost = true;
            headerPanel.ResumeLayout(false);
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            flowLayoutPanel_Loot_Containers_SettingsWidget.ResumeLayout(false);
            flowLayoutPanel_Loot_Containers_SettingsWidget.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((ISupportInitialize)trackBar_AimFOV_SettingsWidget).EndInit();
            tabPage3.ResumeLayout(false);
            tabPage3.PerformLayout();
            ((ISupportInitialize)trackBar_EspLineScale).EndInit();
            ((ISupportInitialize)trackBar_EspLootDist).EndInit();
            ((ISupportInitialize)trackBar_EspImpLootDist).EndInit();
            ((ISupportInitialize)trackBar_ESPContainerDist).EndInit();
            ((ISupportInitialize)trackBar_EspQuestHelperDist).EndInit();
            ((ISupportInitialize)trackBar_EspGrenadeDist).EndInit();
            ((ISupportInitialize)trackBar_EspFontScale).EndInit();
            flowLayoutPanel_ESP_AIRender.ResumeLayout(false);
            flowLayoutPanel_ESP_AIRender.PerformLayout();
            flowLayoutPanel_ESP_PlayerRender.ResumeLayout(false);
            flowLayoutPanel_ESP_PlayerRender.PerformLayout();
            tabPage4.ResumeLayout(false);
            tabPage4.PerformLayout();
            tabPage5.ResumeLayout(false);
            tabPage5.PerformLayout();
            tabPage6.ResumeLayout(false);
            tabPage6.PerformLayout();
            flowLayoutPanel_NoRecoil.ResumeLayout(false);
            flowLayoutPanel_NoRecoil.PerformLayout();
            ((ISupportInitialize)trackBar_NoRecoil).EndInit();
            ((ISupportInitialize)trackBar_NoSway).EndInit();
            flowLayoutPanel_LTW.ResumeLayout(false);
            flowLayoutPanel_LTW.PerformLayout();
            ((ISupportInitialize)trackBar_LTWAmount).EndInit();
            flowLayoutPanel_WideLean.ResumeLayout(false);
            flowLayoutPanel_WideLean.PerformLayout();
            ((ISupportInitialize)trackBar_WideLeanAmt).EndInit();
            ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Button minimizeButton;
        private Button button_Restart_SettingsWidget;
        private CheckBox checkBox_MoveSpeed2_SettingsWidget;
        private CheckBox checkBox_MoveSpeed_SettingsWidget;
        private Button button_GymHack_SettingsWidget;
        private CheckBox checkBox_FullBright_SettingsWidget;
        private Button button_AntiAfk_SettingsWidget;
        private CheckBox checkBox_InfStamina_SettingsWidget;
        private CheckBox checkBox_LTW_SettingsWidget;
        private CheckBox checkBox_FastLoadUnload_SettingsWidget;
        private CheckBox checkBox_Chams_SettingsWidget;
        private CheckedListBox checkedListBox_QuestHelper_SettingsWidget;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TabPage tabPage3;
        private TabPage tabPage4;
        private CheckBox checkBox_AimBotEnabled_SettingsWidget;
        private CheckBox checkBox_SA_SafeLock_SettingsWidget;
        private CheckBox checkBox_SA_AutoBone_SettingsWidget;
        private RadioButton radioButton_AimTarget_FOV_SettingsWidget;
        private RadioButton radioButton_AimTarget_CQB_SettingsWidget;
        private CheckBox checkBox_AimbotDisableReLock_SettingsWidget;
        private Label label_AimFOV_SettingsWidget;
        private TrackBar trackBar_AimFOV_SettingsWidget;
        private CheckBox checkBox_AimHeadAI_SettingsWidget;
        private CheckBox checkBox_AimRandomBone_SettingsWidget;
        private TabPage tabPage5;
        private Label label10;
        private ComboBox comboBox_AimbotTarget_SettingsWidget;
        private Button button_RandomBoneCfg_SettingsWidget;
        private RadioButton radioButton_Chams_Basic;
        private RadioButton radioButton_Chams_Visible;
        private RadioButton radioButton_Chams_Vischeck;
        private Label label15;
        private TextBox textBox_VischeckVisColor;
        private TextBox textBox_VischeckInvisColor;
        private Button button_VischeckVisColorPick;
        private Label label33;
        private Button button_VischeckInvisColorPick;
        private Label label11;
        private Label label_Width;
        private TextBox textBox_ResWidth;
        private Label label_Height;
        private TextBox textBox_ResHeight;
        private Button button_DetectRes;
        private CheckBox checkBox_ESP_Loot;
        private CheckBox checkBox_ESP_Exfils;
        private CheckBox checkBox_ESP_Explosives;
        private CheckBox checkBox_ESP_ShowMag;
        private CheckBox checkBox_ESP_Dist;
        private CheckBox checkBox_ESP_ShowMines;
        private CheckBox checkBox_ESP_FireportAim;
        private CheckBox checkBox_ESP_AimFov;
        private CheckBox checkBox_ESP_AimLock;
        private CheckBox checkBox_ESP_RaidStats;
        private CheckBox checkBox_ESP_StatusText;
        private CheckBox checkBox_ESP_FPS;
        private FlowLayoutPanel flowLayoutPanel_ESP_PlayerRender;
        private Label label18;
        private RadioButton radioButton_ESPRender_None;
        private RadioButton radioButton_ESPRender_Bones;
        private RadioButton radioButton_ESPRender_Box;
        private RadioButton radioButton_ESPRender_Presence;
        private CheckBox checkBox_ESPRender_Labels;
        private CheckBox checkBox_ESPRender_Weapons;
        private CheckBox checkBox_ESPRender_Dist;
        private FlowLayoutPanel flowLayoutPanel_ESP_AIRender;
        private Label label19;
        private RadioButton radioButton_ESPAIRender_None;
        private RadioButton radioButton_ESPAIRender_Bones;
        private RadioButton radioButton_ESPAIRender_Box;
        private RadioButton radioButton_ESPAIRender_Presence;
        private CheckBox checkBox_ESPAIRender_Labels;
        private CheckBox checkBox_ESPAIRender_Weapons;
        private CheckBox checkBox_ESPAIRender_Dist;
        private Label label_EspLootDist;
        private TrackBar trackBar_EspLootDist;
        private Label label_EspImpLootDist;
        private TrackBar trackBar_EspImpLootDist;
        private Label label_ESPContainerDist;
        private TrackBar trackBar_ESPContainerDist;
        private Label label_EspQuestHelperDist;
        private TrackBar trackBar_EspQuestHelperDist;
        private Label label_EspExplosivesDist;
        private TrackBar trackBar_EspGrenadeDist;
        private Label label_EspFontScale;
        private TrackBar trackBar_EspFontScale;
        private Label label_EspLineScale;
        private TrackBar trackBar_EspLineScale;
        public Button button_StartESP_SettingsWidget;
        private Button button_WebRadarStart;
        private CheckBox checkBox_WebRadarUPNP;
        private Label label_WebRadarHost;
        private TextBox textBox_WebRadarBindIP;
        private Label label_WebRadarPort;
        private TextBox textBox_WebRadarPort;
        private Label label_WebRadarTickRate;
        private TextBox textBox_WebRadarTickRate;
        private Label label_WebRadarPassword;
        private TextBox textBox_WebRadarPassword;
        private LinkLabel linkLabel_WebRadarLink;
        private CheckBox checkBox_EnableMemWrite_SettingsWidget;
        private CheckBox checkBox_AdvancedMemWrites_SettingsWidget;
        private FlowLayoutPanel flowLayoutPanel_Loot_Containers_SettingsWidget;
        private Label label30;
        public CheckBox checkBox_Containers_SelectAll_SettingsWidget;
        private Label label31;
        private CheckBox checkBox_Containers_HideSearched_SettingsWidget;
        private CheckedListBox checkedListBox_Containers_SettingsWidget;
        private TabPage tabPage6;
        private CheckBox checkBox_Loot_SettingsWidget;
        private CheckBox checkBox_LootWishlist_SettingsWidget;
        private CheckBox checkBox_ShowContainers_SettingsWidget;
        private CheckBox checkBox_hideRaidcode;
        private CheckBox checkBox_AntiPage;
        private CheckBox checkBox_NoRecoilSway;
        private CheckBox checkBox_WideLean;
        private CheckBox checkBox_NoVisor;
        private CheckBox checkBox_AlwaysDaySunny;
        private CheckBox checkBox_NoWepMalf;
        private FlowLayoutPanel flowLayoutPanel_NoRecoil;
        private Label label16;
        private Label label_Recoil;
        private TrackBar trackBar_NoRecoil;
        private Label label_Sway;
        private TrackBar trackBar_NoSway;
        private FlowLayoutPanel flowLayoutPanel_LTW;
        private Label label28;
        private Label label_LTWAmount;
        private TrackBar trackBar_LTWAmount;
        private FlowLayoutPanel flowLayoutPanel_WideLean;
        private Label label_WideLean;
        private Label label21;
        private ComboBox comboBox_WideLeanMode;
        private Label label_WideLeanAmt;
        private TrackBar trackBar_WideLeanAmt;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
    }
}