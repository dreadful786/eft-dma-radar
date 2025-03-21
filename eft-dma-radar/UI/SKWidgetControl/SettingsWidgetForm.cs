﻿using DarkModeForms;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

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
            SetDarkMode(ref _darkmode);
            UpdateCheckboxStates();
            InitializeHeaderText();
            PopulateQuestHelperList();
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

        #endregion

        #region Event Handlers
        private void minimizeButton_Click(object sender, EventArgs e)
        {
            if (isMinimized)
            {
                this.Size = new System.Drawing.Size(600, 273);
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
        private void checkBox_AimBotEnabled_CheckedChanged(object sender, EventArgs e)
        {
            _mainForm.checkBox_AimBotEnabled.Checked = checkBox_AimBotEnabled_SettingsWidget.Checked;
        }

        private void checkedListBox_QuestHelper_SettingsWidget_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // Update the corresponding item in the main form's checkedListBox_QuestHelper
            _mainForm.QuestHelperListBox.ItemCheck -= _mainForm.CheckedListBox_QuestHelper_ItemCheck;
            _mainForm.QuestHelperListBox.SetItemChecked(e.Index, e.NewValue == CheckState.Checked);
            _mainForm.QuestHelperListBox.ItemCheck += _mainForm.CheckedListBox_QuestHelper_ItemCheck;
        }
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

        public void UpdateQuestHelperList(int index, bool isChecked)
        {
            checkedListBox_QuestHelper_SettingsWidget.ItemCheck -= checkedListBox_QuestHelper_SettingsWidget_ItemCheck;
            checkedListBox_QuestHelper_SettingsWidget.SetItemChecked(index, isChecked);
            checkedListBox_QuestHelper_SettingsWidget.ItemCheck += checkedListBox_QuestHelper_SettingsWidget_ItemCheck;
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
