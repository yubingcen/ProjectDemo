using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Teigha;
using Teigha.GraphicsSystem;
using Teigha.Runtime;
using Teigha.GraphicsInterface;
using Teigha.DatabaseServices;
using Teigha.Export_Import;

namespace ProjectDemo
{
    class Aux
    {
        public static ObjectId active_viewport_id(Database database)
        {
            if (database.TileMode)
            {
                return database.CurrentViewportTableRecordId;
            }
            else
            {
                using (BlockTableRecord paperBTR = (BlockTableRecord)database.CurrentSpaceId.GetObject(OpenMode.ForRead))
                {
                    Layout l = (Layout)paperBTR.LayoutId.GetObject(OpenMode.ForRead);
                    return l.CurrentViewportId;
                }
            }
        }

        //public static void preparePlotstyles(Database database, ContextForDbDatabase ctx)
        //{
        //    using (BlockTableRecord paperBTR = (BlockTableRecord)database.CurrentSpaceId.GetObject(OpenMode.ForRead))
        //    {
        //        using (Layout pLayout = (Layout)paperBTR.LayoutId.GetObject(OpenMode.ForRead))
        //        {
        //            if (ctx.IsPlotGeneration ? pLayout.PlotPlotStyles : pLayout.ShowPlotStyles)
        //            {
        //                String pssFile = pLayout.CurrentStyleSheet;
        //                if (pssFile.Length > 0)
        //                {
        //                    String testpath = ((HostAppServ)HostApplicationServices.Current).FindFile(pssFile, database, FindFileHint.Default);
        //                    if (testpath.Length > 0)
        //                    {
        //                        using (FileStreamBuf pFileBuf = new FileStreamBuf(testpath))
        //                        {
        //                            ctx.LoadPlotStyleTable(pFileBuf);
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}
    }
}
