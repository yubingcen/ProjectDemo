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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFile = new System.Windows.Forms.ToolStripMenuItem();
            this.exportCAD = new System.Windows.Forms.ToolStripMenuItem();
            this.readExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.exportWord = new System.Windows.Forms.ToolStripMenuItem();
            this.线缆连接ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openConnectView = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.ShowThumb = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.线缆连接ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(509, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openFile,
            this.readExcel,
            this.exportCAD,
            this.exportWord});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // openFile
            // 
            this.openFile.Name = "openFile";
            this.openFile.Size = new System.Drawing.Size(152, 22);
            this.openFile.Text = "打开";
            this.openFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // exportCAD
            // 
            this.exportCAD.Name = "exportCAD";
            this.exportCAD.Size = new System.Drawing.Size(152, 22);
            this.exportCAD.Text = "导出CAD";
            this.exportCAD.Click += new System.EventHandler(this.ExportCAD_Click);
            // 
            // readExcel
            // 
            this.readExcel.Name = "readExcel";
            this.readExcel.Size = new System.Drawing.Size(152, 22);
            this.readExcel.Text = "读取Excel";
            this.readExcel.Click += new System.EventHandler(this.readExcel_Click);
            // 
            // exportWord
            // 
            this.exportWord.Name = "exportWord";
            this.exportWord.Size = new System.Drawing.Size(152, 22);
            this.exportWord.Text = "导出Word";
            this.exportWord.Click += new System.EventHandler(this.exportWord_Click);
            // 
            // 线缆连接ToolStripMenuItem
            // 
            this.线缆连接ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openConnectView});
            this.线缆连接ToolStripMenuItem.Name = "线缆连接ToolStripMenuItem";
            this.线缆连接ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.线缆连接ToolStripMenuItem.Text = "线缆连接";
            // 
            // openConnectView
            // 
            this.openConnectView.Name = "openConnectView";
            this.openConnectView.Size = new System.Drawing.Size(152, 22);
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
            this.dataGridView1.Location = new System.Drawing.Point(12, 39);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(483, 150);
            this.dataGridView1.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 196);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(294, 174);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // ShowThumb
            // 
            this.ShowThumb.Location = new System.Drawing.Point(312, 196);
            this.ShowThumb.Name = "ShowThumb";
            this.ShowThumb.Size = new System.Drawing.Size(75, 23);
            this.ShowThumb.TabIndex = 4;
            this.ShowThumb.Text = "显示缩略图";
            this.ShowThumb.UseVisualStyleBackColor = true;
            this.ShowThumb.Click += new System.EventHandler(this.ShowThumb_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 404);
            this.Controls.Add(this.ShowThumb);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
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
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFile;
        private System.Windows.Forms.ToolStripMenuItem readExcel;
        private System.Windows.Forms.ToolStripMenuItem exportWord;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripMenuItem 线缆连接ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openConnectView;
        private System.Windows.Forms.ToolStripMenuItem exportCAD;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button ShowThumb;
    }
}

