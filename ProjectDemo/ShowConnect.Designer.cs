﻿using System;
using System.Windows.Forms;

namespace ProjectDemo
{
    partial class ShowConnect
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
            this.show1 = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // show1
            // 
            this.show1.Location = new System.Drawing.Point(24, 24);
            this.show1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.show1.Name = "show1";
            this.show1.Size = new System.Drawing.Size(150, 46);
            this.show1.TabIndex = 2;
            this.show1.Text = "加载线缆头";
            this.show1.UseVisualStyleBackColor = true;
            this.show1.Click += new System.EventHandler(this.show1_Click);
            // 
            // ShowConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2052, 1250);
            this.Controls.Add(this.show1);
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "ShowConnect";
            this.Text = "ShowConnect";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CloseRender);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            this.ResumeLayout(false);

        }


        #endregion
        private System.Windows.Forms.Button show1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
    }
}