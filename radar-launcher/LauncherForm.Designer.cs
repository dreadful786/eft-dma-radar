using System.Diagnostics;
using System.Windows.Forms;

namespace radar_launcher
{
    partial class LauncherForm : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LauncherForm));
            lblTitle = new Label();
            btnEftRadar = new Button();
            btnArenaRadar = new Button();
            toolTip1 = new ToolTip(components);
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Padding = new Padding(0, 15, 0, 0);
            lblTitle.Size = new Size(350, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Select Radar Application";
            lblTitle.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnEftRadar
            // 
            btnEftRadar.Font = new Font("Segoe UI", 12F);
            btnEftRadar.Location = new Point(41, 76);
            btnEftRadar.Margin = new Padding(3, 2, 3, 2);
            btnEftRadar.Name = "btnEftRadar";
            btnEftRadar.Size = new Size(131, 60);
            btnEftRadar.TabIndex = 1;
            btnEftRadar.Text = "EFT Radar";
            btnEftRadar.UseVisualStyleBackColor = true;
            btnEftRadar.Click += btnEftRadar_Click;
            // 
            // btnArenaRadar
            // 
            btnArenaRadar.Font = new Font("Segoe UI", 12F);
            btnArenaRadar.Location = new Point(178, 76);
            btnArenaRadar.Margin = new Padding(3, 2, 3, 2);
            btnArenaRadar.Name = "btnArenaRadar";
            btnArenaRadar.Size = new Size(131, 60);
            btnArenaRadar.TabIndex = 2;
            btnArenaRadar.Text = "Arena Radar";
            btnArenaRadar.UseVisualStyleBackColor = true;
            btnArenaRadar.Click += btnArenaRadar_Click;
            // 
            // LauncherForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(350, 188);
            Controls.Add(btnArenaRadar);
            Controls.Add(btnEftRadar);
            Controls.Add(lblTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            Name = "LauncherForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EFT DMA Radar Launcher";
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private Button btnEftRadar;
        private Button btnArenaRadar;
        private ToolTip toolTip1;
    }
}
