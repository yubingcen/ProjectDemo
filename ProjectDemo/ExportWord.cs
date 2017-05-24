using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;


namespace ProjectDemo
{
    class ExportWord
    {
        public void ExportDataTableToWord(System.Data.DataTable srcDgv, string filePath)
        {
            killWinWordProcess();
            if (srcDgv.Rows.Count == 0)
            {
                MessageBox.Show("没有数据可供导出！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            else
            {
                if (filePath != null)
                {
                    object path = filePath;
                    Object none = System.Reflection.Missing.Value;
                    Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
                    Microsoft.Office.Interop.Word.Document document = wordApp.Documents.Add(ref none, ref none, ref none, ref none);

                    //搜索书签
                    foreach (Microsoft.Office.Interop.Word.Bookmark bm in document.Bookmarks)
                    {
                        if (bm.Name == "BookMark_Date")
                        {
                            bm.Select();

                            bm.Range.Text = "2008";//ViewState["FK_ProdurcePlanID"].ToString();  
                        }
                    }

                        //建立表格
                        Microsoft.Office.Interop.Word.Table table = document.Tables.Add(document.Paragraphs.Last.Range, srcDgv.Rows.Count+1, srcDgv.Columns.Count, ref none, ref none);
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

                        MessageBox.Show("数据已经成功导出到：" + filePath, "导出完成", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (System.Exception e)
                    {
                        MessageBox.Show(e.Message, "提示", MessageBoxButtons.OK);
                    }

                }
            }
        }

        //杀死word
        public void killWinWordProcess()
        {
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("WINWORD");
            foreach (System.Diagnostics.Process process in processes)
            {
                bool b = process.MainWindowTitle == "";
                if (process.MainWindowTitle == "")
                {
                    process.Kill();
                }
            }
        }

    }
}
