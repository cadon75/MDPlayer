﻿#if X64
using MDPlayerx64.Properties;
#else
using MDPlayer.Properties;
#endif
namespace MDPlayer.form
{
    partial class frmSegaPCM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSegaPCM));
            pbScreen = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pbScreen).BeginInit();
            SuspendLayout();
            // 
            // pbScreen
            // 
            pbScreen.Location = new Point(0, 0);
            pbScreen.Margin = new Padding(4, 4, 4, 4);
            pbScreen.Name = "pbScreen";
            pbScreen.Size = new Size(373, 170);
            pbScreen.TabIndex = 1;
            pbScreen.TabStop = false;
            pbScreen.MouseClick += pbScreen_MouseClick;
            // 
            // frmSegaPCM
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(373, 170);
            Controls.Add(pbScreen);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(5, 5, 5, 5);
            MaximizeBox = false;
            Name = "frmSegaPCM";
            Text = "SegaPCM";
            FormClosed += frmSegaPCM_FormClosed;
            Load += frmSegaPCM_Load;
            ((System.ComponentModel.ISupportInitialize)pbScreen).EndInit();
            ResumeLayout(false);
        }

        #endregion

        public System.Windows.Forms.PictureBox pbScreen;
    }
}