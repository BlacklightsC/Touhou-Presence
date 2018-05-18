using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace Touhou_Presence
{
    public static class ProcessFinder
    {
        private static TouhouBase Instance = null;
        private static Timer ProcessTimer = null;
        public static Action<string> SetText { private get; set; }
        public static void ProcessOpen()
        {
            ProcessTimer.Stop();
        }

        public static void ProcessClose()
        {
            Instance.Dispose();
            Instance = null;
            SetText("Nothing found");
            ProcessTimer.Start();
        }

        public static void SearchProcess()
        {
            if (ProcessTimer != null) return;
            ProcessTimer = new Timer(3000);
            ProcessTimer.Elapsed += (sender, e) =>
            {
                if (Instance != null) return;
                foreach (var item in Process.GetProcesses())
                {
                    if (Instance is null
                     && item.ProcessName.IndexOf("th") == 0)
                    {
                        Type type = Type.GetType(string.Format("Touhou_Presence.Data.{0}",item.ProcessName));
                        if (type is null)
                        {
                            item.Dispose();
                        }
                        else
                        {
                            Instance = (TouhouBase)Activator.CreateInstance(type, item);
                            SetText(type.Name.ToUpper() + ": " + Instance.SubTitle);
                            ProcessOpen();
                        }
                        continue;
                    }
                    else
                    {
                        item.Dispose();
                    }
                }
            };
            ProcessTimer.Start();
        }
    }
}
