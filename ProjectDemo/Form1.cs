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
using Word = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;
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
        // form1加载时给表格加载数据
        private void Form1_Load(object sender, EventArgs e)
        {
            //定义表结构
            cabledt.Columns.Add("Id", typeof(System.Int32));//列名  列所在数据类型
            cabledt.Columns.Add("Name", typeof(System.String));
            cabledt.Columns.Add("age", typeof(System.String));
            //添加新行
            for (int i = 0; i <= 3; i++)
            {
                DataRow dr = cabledt.NewRow();   //行
                dr[0] = i;
                dr[1] = "wang" + i;
                dr[2] = "5" + i;
                cabledt.Rows.Add(dr);    //将行添加到DataTabl 格中```
            }
            dataGridView1.DataSource = cabledt;   //控件.DataSource = ……（该控件可以直接绑定一个DataTable这样的表）
        }


        private void openFile_Click(object sender, EventArgs e)
        {
            //OpenFileDialog file = new OpenFileDialog();
            //if (file.ShowDialog() == DialogResult.OK)
            //{
            //    MessageBox.Show("打开成功");
            //}
            string path = "d:\\test.dwg";
           // OperateDWG.openDWG(path);
        }

        public void ExportDataGridViewToWord(System.Data.DataTable srcDgv, SaveFileDialog sfile)
        {
            if (srcDgv.Rows.Count == 0)
            {
                MessageBox.Show("没有数据可供导出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                sfile.AddExtension = true;
                sfile.DefaultExt = ".doc";
                sfile.Filter = "(*.doc)|*.doc";
                if (sfile.ShowDialog() == DialogResult.OK)
                {
                    object path = sfile.FileName;
                    Object none = System.Reflection.Missing.Value;
                    Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                    Microsoft.Office.Interop.Word.Document document = wordApp.Documents.Add(ref none, ref none, ref none, ref none);

                    //建立表格
                    Microsoft.Office.Interop.Word.Table table = document.Tables.Add(document.Paragraphs.Last.Range, srcDgv.Rows.Count, srcDgv.Columns.Count, ref none, ref none);
                    try
                    {
                        for (int i = 0; i < srcDgv.Columns.Count; i++)//输出标题
                        {
                            table.Cell(1, i + 1).Range.InsertAfter(srcDgv.Columns[i].ColumnName);
                        }
                        //输出控件中的记录
                        for (int i = 0; i < srcDgv.Rows.Count; i++)
                        {
                            for (int j = 0; j < srcDgv.Columns.Count; j++)
                            {
                                table.Cell(i + 2, j + 1).Range.InsertAfter(srcDgv.Rows[i][j].ToString());
                            }
                        }
                        table.Borders.OutsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                        table.Borders.InsideLineStyle = Microsoft.Office.Interop.Word.WdLineStyle.wdLineStyleSingle;
                        document.SaveAs(ref path, ref none, ref none, ref none, ref none, ref none, ref none, ref none, ref none, ref none, ref none, ref none, ref none, ref none, ref none, ref none);

                        MessageBox.Show("数据已经成功导出到：" + sfile.FileName.ToString(), "导出完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (System.Exception e)
                    {
                        MessageBox.Show(e.Message, "提示", MessageBoxButtons.OK);
                    }

                }
            }

        }
        
        private void exportWord_Click(object sender, EventArgs e)
        {
            ExportDataGridViewToWord(cabledt, saveFileDialog);
        }


        private void openConnectView_Click(object sender, EventArgs e)
        {
            Thread th = new Thread(() => { System.Windows.Forms.Application.Run(new ShowConnect()); });
            th.Start();
        }


        private void ExportCAD_Click(object sender, EventArgs e)
        {
            OperateDWG operate = new OperateDWG();
            operate.exprotCAD();

        }

        private void ShowThumb_Click(object sender, EventArgs e)
        {
            ViewDWG viewDwg = new ViewDWG();
            string path = "D:\\毕设资料\\CAD二次开发\\XXXXDCW04-3000-00.dwg";
            pictureBox1.Image = viewDwg.ShowDWG(1000,2000, path);

        }

        private void readExcel_Click(object sender, EventArgs e)
        {
            string test = "d:\\test.xlsx";
            cabledt = GetExcelData(test);
            dataGridView1.DataSource = GetExcelData(test);
        }

        public static System.Data.DataTable GetExcelData(string excelFilePath)
        {
            Excel.Application app = new Excel.Application();
            Excel.Sheets sheets;
            Excel.Workbook workbook = null;
            object oMissiong = System.Reflection.Missing.Value;
            System.Data.DataTable dt = new System.Data.DataTable();
            try
            {
                if (app == null)
                {
                    return null;
                }
                workbook = app.Workbooks.Open(excelFilePath, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong,
                    oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong, oMissiong);
                //将数据读入到DataTable中——Start     
                sheets = workbook.Worksheets;
                Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);//读取第一张表  
                if (worksheet == null)
                    return null;
                string cellContent;
                int iRowCount = worksheet.UsedRange.Rows.Count;
                int iColCount = worksheet.UsedRange.Columns.Count;
                Excel.Range range;
                //负责列头Start  
                DataColumn dc;
                int ColumnID = 1;
                range = (Excel.Range)worksheet.Cells[1, 1];
                while (range.Text.ToString().Trim() != "")
                {
                    dc = new DataColumn();
                    dc.DataType = System.Type.GetType("System.String");
                    dc.ColumnName = range.Text.ToString().Trim();
                    dt.Columns.Add(dc);

                    range = (Excel.Range)worksheet.Cells[1, ++ColumnID];
                }
                //End  
                for (int iRow = 2; iRow <= iRowCount; iRow++)
                {
                    DataRow dr = dt.NewRow();
                    for (int iCol = 1; iCol <= iColCount; iCol++)
                    {
                        range = (Excel.Range)worksheet.Cells[iRow, iCol];
                        cellContent = (range.Value2 == null) ? "" : range.Text.ToString();
                        dr[iCol - 1] = cellContent;
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
            }
            catch
            {
                return null;
            }
            finally
            {
                workbook.Close(false, oMissiong, oMissiong);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                workbook = null;
                app.Workbooks.Close();
                app.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(app);
                app = null;
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

    }
}

