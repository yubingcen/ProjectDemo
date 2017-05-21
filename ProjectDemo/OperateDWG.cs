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
using System.IO;
using Teigha.DatabaseServices;
using Teigha.Runtime;
using Microsoft.Office.Interop.Word;
using Teigha.Geometry;
using Autodesk.AutoCAD.Interop;
using System.Runtime.InteropServices;

namespace ProjectDemo
{
   
    class OperateDWG
    {
        static object miss = System.Reflection.Missing.Value;
        public void exprotCAD()
        {
            object filepath = "c:\\test\\1.docx";

            string o_cadFile = "c:\\test\\test.dwg";
            // object o_cadFile = (object)filepath;
            Teigha.Runtime.Services trs = new Services();

            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            wordApp = new Microsoft.Office.Interop.Word.Application();
            wordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;

            //wordApp.ActiveDocument.Bookmarks.get_Item(ref bkObj).Select();
            Document doc = null;
            doc = wordApp.Documents.Open(ref filepath, ref miss, ref miss, ref miss
                                                                   , ref miss, ref miss, ref miss, ref miss, ref miss
                                                                   , ref miss, ref miss, ref miss, ref miss);
            if (!File.Exists(o_cadFile))
                return;
            Database db = new Database(false, true);//CAD Database,CAD数据库

            db.ReadDwgFile((string)o_cadFile, FileOpenMode.OpenForReadAndAllShare, false, "");//读取文件
            if (db == null)
                return;
            double x0 = 0, x1 = 0, y0 = 0, y1 = 0;
            bool isIni = false;
            using (Transaction ts = db.TransactionManager.StartTransaction())//打开事务
            {
                BlockTableRecord btr = (BlockTableRecord)db.CurrentSpaceId.GetObject(OpenMode.ForRead);//块表记录
                foreach (var id in btr)//遍历所有Entity
                {

                    Entity ent = (Entity)id.GetObject(OpenMode.ForRead);
                    if (isIni == false)
                    {
                        x0 = ent.GeometricExtents.MinPoint.X;
                        x1 = ent.GeometricExtents.MaxPoint.X;
                        y0 = ent.GeometricExtents.MinPoint.Y;
                        y1 = ent.GeometricExtents.MaxPoint.Y;
                        isIni = true;
                    }
                    else
                    {
                        try
                        {
                            if (x0 > ent.GeometricExtents.MinPoint.X)
                                x0 = ent.GeometricExtents.MinPoint.X;
                            if (x1 < ent.GeometricExtents.MaxPoint.X)
                                x1 = ent.GeometricExtents.MaxPoint.X;
                            if (y0 > ent.GeometricExtents.MinPoint.Y)
                                y0 = ent.GeometricExtents.MinPoint.Y;
                            if (y1 < ent.GeometricExtents.MaxPoint.Y)
                                y1 = ent.GeometricExtents.MaxPoint.Y;
                        }
                        catch { }
                    }

                }
                ViewportTableRecord vp = (ViewportTableRecord)Aux.active_viewport_id(db).GetObject(OpenMode.ForWrite);//视口表记录
                vp.CenterPoint = new Point2d((x0 + x1) / 2, (y0 + y1) / 2);

                vp.Width = x1 - x0;
                vp.Height = y1 - y0;//稍微增大，以免地下有线没有被完全显示，到时候最好用比例
                ts.Commit();
            }
            db.SaveAs((string)o_cadFile, DwgVersion.Current);
            const string progID = "AutoCAD.Application.18.0";
            AcadApplication acApp = null;
            try
            {
                acApp = (AcadApplication)Marshal.GetActiveObject(progID);
            }
            catch
            {
                try
                {
                    Type acType = Type.GetTypeFromProgID(progID);
                    acApp = (AcadApplication)Activator.CreateInstance(acType, true);
                }
                catch
                {

                }
            }
            if (acApp != null)
            {
                //acApp.Visible = false;
                acApp.Height = 500 + 55;
                acApp.Width = (int)(500 * (x1 - x0) / (y1 - y0));
                acApp.Quit();
            }
            //object Nothing = System.Reflection.Missing.Value;
            object link = false;
            object cadFile = (object)o_cadFile;
            wordApp.Selection.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            object oStart = "ccc";
            object range = (object)doc.Bookmarks.get_Item(ref oStart).Range;

            try
            {
                InlineShape cadShape = wordApp.Selection.InlineShapes.AddOLEObject(ref miss, ref cadFile, ref link, ref link, ref miss
                                                    , ref miss, ref miss, ref range);

                cadShape.Width = (float)(200 * (x1 - x0) / (y1 - y0));
                cadShape.Height = 200f;
            }
            catch { }

            doc.Save();
            doc.Close();
            wordApp.Quit();
            trs.Dispose();

        }

        //public static void openDWG(string dwgpath)
        //{
        //    const string progID = "AutoCAD.Application.18.2";
        //    AcadApplication acApp = null;
        //    try
        //    {
        //        acApp = (AcadApplication)Marshal.GetActiveObject(progID);
        //    }
        //    catch
        //    {
        //        try
        //        {
        //            Type acType = Type.GetTypeFromProgID(progID);
        //            acApp = (AcadApplication)Activator.CreateInstance(acType, true);
        //        }
        //        catch
        //        {

        //        }
        //    }
        //    if (acApp != null)
        //    {
        //        acApp.Documents.Open(dwgpath,null,null);
        //        acApp.Visible = true;
        //    }
        //}
    }
}
