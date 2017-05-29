using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace ProjectDemo
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        //新建表
        System.Data.DataTable cabledt = new System.Data.DataTable();
        //保存文件名
        string excelFile=null;
        string wordFile;
        string dwgFile=null;

        // form1加载时给表格加载数据
        private void Form1_Load(object sender, EventArgs e)
        {
            //定义表结构
            cabledt.Columns.Add("序号", typeof(System.Int32));//列名  列所在数据类型
            cabledt.Columns.Add("电缆名称", typeof(System.String));
            cabledt.Columns.Add("电缆图号", typeof(System.String));
            cabledt.Columns.Add("单套数量", typeof(System.String));
            cabledt.Columns.Add("连接器型号", typeof(System.String));
            cabledt.Columns.Add("厂家", typeof(System.String));
            cabledt.Columns.Add("备注", typeof(System.String));
            DataRow dr = cabledt.NewRow();   //行
            ////添加新行
            //for (int i = 0; i <= 3; i++)
            //{
            //    DataRow dr = cabledt.NewRow();   //行
            //    dr[0] = i;
            //    dr[1] = "wang" + i;
            //    dr[2] = "5" + i;
            //    cabledt.Rows.Add(dr);    //将行添加到DataTabl 格中```
            //}
            dataGridView1.DataSource = cabledt;   //控件.DataSource = ……（该控件可以直接绑定一个DataTable这样的表）
        }

        // 读取CAD文件
        private void openFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                string exName = Path.GetExtension(file.FileName);
                if (string.Equals(exName, ".dwg"))
                {
                    dwgFile = file.FileName;
                    MessageBox.Show("CAD文件读取成功");
                    if (dwgFile != null)
                    {
                        ViewDWG viewDwg = new ViewDWG();
                        pictureBox1.Image = viewDwg.ShowDWG(400, 450, dwgFile);
                    }
                    else
                    {
                        MessageBox.Show("请先读取CAD文件");
                    }
                }
                else
                {
                    MessageBox.Show("请选择.dwg文件");
                }
            }
        }

        // 导出数据表数据到word
        private void exportWord_Click(object sender, EventArgs e)
        {
            if (wordFile != null)
            {
                ExportWord export = new ExportWord();
                export.ExportDataTableToWord(cabledt, wordFile);
            }
            else
            {
                MessageBox.Show("请先导入模板文件");
            }
           
        }

        // 打开电缆头连接
        private void openConnectView_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() => { System.Windows.Forms.Application.Run(new ShowConnect()); });
            th.Start();
        }

        // 导出CAD文件到word
        private void ExportCAD_Click(object sender, EventArgs e)
        {
            if (wordFile != null)
            {
                OperateDWG operate = new OperateDWG();
                operate.exprotCAD(dwgFile,wordFile);
            }
            else
            {
                MessageBox.Show("请先导入模板文件");
            }
                
        }

        // 显示缩略图
        private void ShowThumb_Click(object sender, EventArgs e)
        {
            if (dwgFile != null)
            {
                ViewDWG viewDwg = new ViewDWG();
                // string path = "d:\\毕设资料\\CAD二次开发\\XXXXDCW04-3000-00.dwg";
                pictureBox1.Image = viewDwg.ShowDWG(100,200,dwgFile);
            }
            else
            {
                MessageBox.Show("请先读取CAD文件");
            }
        }

        // 读取Excel文件数据
        private void readExcel_Click(object sender, EventArgs e)
        {
            OpenFileDialog excelfile = new OpenFileDialog();
            if (excelfile.ShowDialog() == DialogResult.OK)
            {
                string exName = Path.GetExtension(excelfile.FileName);
                if (string.Equals(exName, ".xlsx") || string.Equals(exName, ".xls"))
                {
                    excelFile = excelfile.FileName;
                    cabledt = ImportExcel.GetExcelData(excelFile);
                    dataGridView1.DataSource = ImportExcel.GetExcelData(excelFile);
                }
                else
                {
                    MessageBox.Show("请选择Excel文件");
                }
            }
        }

        // 读取word模板
        private void ReadWordModel_Click(object sender, EventArgs e)
        {
            OpenFileDialog excelfile = new OpenFileDialog();
            if (excelfile.ShowDialog() == DialogResult.OK)
            {
                string exName = Path.GetExtension(excelfile.FileName);
                if (string.Equals(exName, ".docx") || string.Equals(exName, ".doc"))
                {
                    wordFile = excelfile.FileName;
                    MessageBox.Show("模板导入成功");
                }
                else
                {
                    MessageBox.Show("请选择Word文件");
                }
            }
        }

        // 在CAD中打开文件
        private void openInCAD_Click(object sender, EventArgs e)
        {
                OperateDWG operate = new OperateDWG();
                operate.openDWG(dwgFile);
        }

        // 程序退出
        private void Exit(object sender, FormClosingEventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("确定退出程序吗？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Application.ExitThread();
            }
            else
            {
                e.Cancel = true;
            }
        }

        // 菜单退出
        private void MenuExit_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("确定退出程序吗？", "退出", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Application.ExitThread();
            }
            else
            {
                // e.Cancel = true;
            }
        }

    }
}

