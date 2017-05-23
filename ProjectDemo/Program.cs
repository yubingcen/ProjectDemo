using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectDemo
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // 启动  
            SplashScreen.ShowSplashScreen();

            // 进行自己的操作：加载组件，加载文件等等  
            // 示例代码为休眠一会  
            System.Threading.Thread.Sleep(3000);

            // 关闭  
            if (SplashScreen.Instance != null)
            {
                SplashScreen.Instance.BeginInvoke(new MethodInvoker(SplashScreen.Instance.Dispose));
                SplashScreen.Instance = null;
            }
            Application.Run(new Form1());
        }
    }
}