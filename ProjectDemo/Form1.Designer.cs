namespace ProjectDemo
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFile = new System.Windows.Forms.ToolStripMenuItem();
            this.ReadWordModel = new System.Windows.Forms.ToolStripMenuItem();
            this.readExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportWord = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCAD = new System.Windows.Forms.ToolStripMenuItem();
            this.线缆连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openConnectView = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ShowThumb = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenuItem,
            this.toolStripMenuItem2,
            this.线缆连接ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(12, 4, 0, 4);
            this.menuStrip1.Size = new System.Drawing.Size(1018, 43);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileMenuItem
            // 
            this.fileMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFile,
            this.ReadWordModel,
            this.readExcel,
            this.MenuExit});
            this.fileMenuItem.Name = "fileMenuItem";
            this.fileMenuItem.Size = new System.Drawing.Size(74, 35);
            this.fileMenuItem.Text = "文件";
            // 
            // openFile
            // 
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(320, 38);
            this.openFile.Text = "读取CAD文件";
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // ReadWordModel
            // 
            this.ReadWordModel.Name = "ReadWordModel";
            this.ReadWordModel.Size = new System.Drawing.Size(320, 38);
            this.ReadWordModel.Text = "读取Word模板文件";
            this.ReadWordModel.Click += new System.EventHandler(this.ReadWordModel_Click);
            // 
            // readExcel
            // 
            this.readExcel.Name = "readExcel";
            this.readExcel.Size = new System.Drawing.Size(320, 38);
            this.readExcel.Text = "读取Excel文件数据";
            this.readExcel.Click += new System.EventHandler(this.readExcel_Click);
            // 
            // MenuExit
            // 
            this.MenuExit.Name = "MenuExit";
            this.MenuExit.Size = new System.Drawing.Size(320, 38);
            this.MenuExit.Text = "退出";
            this.MenuExit.Click += new System.EventHandler(this.MenuExit_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exportWord,
            this.exportCAD});
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(74, 35);
            this.toolStripMenuItem2.Text = "导出";
            // 
            // exportWord
            // 
            this.exportWord.Name = "exportWord";
            this.exportWord.Size = new System.Drawing.Size(269, 38);
            this.exportWord.Text = "导出表格数据";
            this.exportWord.Click += new System.EventHandler(this.exportWord_Click);
            // 
            // exportCAD
            // 
            this.exportCAD.Name = "exportCAD";
            this.exportCAD.Size = new System.Drawing.Size(269, 38);
            this.exportCAD.Text = "导出CAD图纸";
            this.exportCAD.Click += new System.EventHandler(this.ExportCAD_Click);
            // 
            // 线缆连接ToolStripMenuItem
            // 
            this.线缆连接ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openConnectView});
            this.线缆连接ToolStripMenuItem.Name = "线缆连接ToolStripMenuItem";
            this.线缆连接ToolStripMenuItem.Size = new System.Drawing.Size(122, 35);
            this.线缆连接ToolStripMenuItem.Text = "线缆连接";
            // 
            // openConnectView
            // 
            this.openConnectView.Name = "openConnectView";
            this.openConnectView.Size = new System.Drawing.Size(269, 38);
            this.openConnectView.Text = "打开连接预览";
            this.openConnectView.Click += new System.EventHandler(this.openConnectView_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(24, 78);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(966, 300);
            this.dataGridView1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(24, 392);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(588, 333);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // ShowThumb
            // 
            this.ShowThumb.Location = new System.Drawing.Point(840, 392);
            this.ShowThumb.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ShowThumb.Name = "ShowThumb";
            this.ShowThumb.Size = new System.Drawing.Size(150, 46);
            this.ShowThumb.TabIndex = 4;
            this.ShowThumb.Text = "显示缩略图";
            this.ShowThumb.UseVisualStyleBackColor = true;
            this.ShowThumb.Click += new System.EventHandler(this.ShowThumb_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(840, 458);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(150, 50);
            this.button1.TabIndex = 5;
            this.button1.Text = "在CAD中打开";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.openInCAD_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1018, 740);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ShowThumb);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "电缆设计管理软件";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Exit);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFile;
        private System.Windows.Forms.ToolStripMenuItem readExcel;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem 线缆连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openConnectView;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ShowThumb;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem MenuExit;
        private System.Windows.Forms.ToolStripMenuItem ReadWordModel;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exportWord;
        private System.Windows.Forms.ToolStripMenuItem exportCAD;
    }
}

