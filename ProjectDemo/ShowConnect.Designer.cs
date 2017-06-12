using System;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShowConnect));
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.操作ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connect_click = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.加载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadingModel = new System.Windows.Forms.ToolStripMenuItem();
            this.ResetPerspective = new System.Windows.Forms.ToolStripMenuItem();
            this.autoModel = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.操作ToolStripMenuItem,
            this.加载ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(681, 25);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 操作ToolStripMenuItem
            // 
            this.操作ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connect_click,
            this.Exit});
            this.操作ToolStripMenuItem.Name = "操作ToolStripMenuItem";
            this.操作ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.操作ToolStripMenuItem.Text = "操作";
            // 
            // connect_click
            // 
            this.connect_click.Name = "connect_click";
            this.connect_click.Size = new System.Drawing.Size(141, 22);
            this.connect_click.Text = "连接/下一组";
            this.connect_click.Click += new System.EventHandler(this.connect_click_Click);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(141, 22);
            this.Exit.Text = "退出";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // 加载ToolStripMenuItem
            // 
            this.加载ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.LoadingModel,
            this.ResetPerspective,
            this.autoModel});
            this.加载ToolStripMenuItem.Name = "加载ToolStripMenuItem";
            this.加载ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.加载ToolStripMenuItem.Text = "加载";
            // 
            // LoadingModel
            // 
            this.LoadingModel.Name = "LoadingModel";
            this.LoadingModel.Size = new System.Drawing.Size(124, 22);
            this.LoadingModel.Text = "加载模型";
            this.LoadingModel.Click += new System.EventHandler(this.LoadingModel_Click);
            // 
            // ResetPerspective
            // 
            this.ResetPerspective.Name = "ResetPerspective";
            this.ResetPerspective.Size = new System.Drawing.Size(124, 22);
            this.ResetPerspective.Text = "重置视角";
            this.ResetPerspective.Click += new System.EventHandler(this.ResetPerspective_Click);
            // 
            // autoModel
            // 
            this.autoModel.Name = "autoModel";
            this.autoModel.Size = new System.Drawing.Size(124, 22);
            this.autoModel.Text = "自动模式";
            this.autoModel.Click += new System.EventHandler(this.autoModel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Highlight;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(512, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 19);
            this.label1.TabIndex = 4;
            this.label1.Text = "连接测试未开始";
            // 
            // ShowConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(681, 370);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ShowConnect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "电缆头连接显示";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CloseRender);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.OnMouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.OnMouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.OnMouseUp);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem 操作ToolStripMenuItem;
        private ToolStripMenuItem connect_click;
        private ToolStripMenuItem Exit;
        private ToolStripMenuItem 加载ToolStripMenuItem;
        private ToolStripMenuItem LoadingModel;
        private ToolStripMenuItem ResetPerspective;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem autoModel;
        private Label label1;
    }
}