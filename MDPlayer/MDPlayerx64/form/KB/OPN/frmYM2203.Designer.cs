﻿#if X64
using MDPlayerx64.Properties;
#else
using MDPlayer.Properties;
#endif
namespace MDPlayer.form
{
    partial class frmYM2203
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYM2203));
            this.pbScreen = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbScreen)).BeginInit();
            this.SuspendLayout();
            // 
            // pbScreen
            // 
            //this.pbScreen.Image = Resources.planeYM2203;
            this.pbScreen.Location = new System.Drawing.Point(0, 0);
            this.pbScreen.Name = "pbScreen";
            this.pbScreen.Size = new System.Drawing.Size(320, 136);
            this.pbScreen.TabIndex = 1;
            this.pbScreen.TabStop = false;
            this.pbScreen.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pbScreen_MouseClick);
            // 
            // frmYM2203
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(320, 136);
            this.Controls.Add(this.pbScreen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmYM2203";
            this.Text = "YM2203";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmYM2203_FormClosed);
            this.Load += new System.EventHandler(this.frmYM2203_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbScreen)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.PictureBox pbScreen;
    }
}