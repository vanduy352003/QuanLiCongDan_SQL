﻿namespace QuanLiCongDanThanhPho
{
    partial class btnResetInformationControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnResetInformation = new Button();
            pnlReset = new Panel();
            pnlReset.SuspendLayout();
            SuspendLayout();
            // 
            // btnResetInformation
            // 
            btnResetInformation.BackColor = Color.Transparent;
            btnResetInformation.FlatStyle = FlatStyle.Flat;
            btnResetInformation.Image = Properties.Resources.reset;
            btnResetInformation.Location = new Point(0, 0);
            btnResetInformation.Name = "btnResetInformation";
            btnResetInformation.Size = new Size(32, 32);
            btnResetInformation.TabIndex = 0;
            btnResetInformation.UseVisualStyleBackColor = false;
            btnResetInformation.Click += btnResetInformation_Click;
            // 
            // pnlReset
            // 
            pnlReset.Controls.Add(btnResetInformation);
            pnlReset.Dock = DockStyle.Top;
            pnlReset.Location = new Point(0, 0);
            pnlReset.Name = "pnlReset";
            pnlReset.Size = new Size(41, 43);
            pnlReset.TabIndex = 1;
            // 
            // btnResetInformationControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(pnlReset);
            Name = "btnResetInformationControl";
            Size = new Size(41, 69);
            pnlReset.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Button btnResetInformation;
        private Panel pnlReset;
    }
}
