using System;
using System.Threading;
using System.Windows.Forms;

namespace Touhou_Presence
{
    static class Program
    {
        /// <summary>
        /// 해당 응용 프로그램의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Mutex mtx = new Mutex(true, "Touhou-Presence", out bool cNew);
            if (!cNew) return;
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            mtx.ReleaseMutex();
        }
    }
}
