using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;

namespace ProjectDemo
{
    class ImportExcel
    {
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
