using System;
using System.Timers;
using System.Diagnostics;

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
                foreach (Process proc in Process.GetProcesses())
                {
                    if (Instance is null
                     && proc.ProcessName.IndexOf("th") == 0)
                    {
                        Type type = Type.GetType(string.Format("Touhou_Presence.Data.{0}",proc.ProcessName));
                        if (type is null)
                        {
                            proc.Dispose();
                        }
                        else
                        {
                            bool IsIncomplete = false;
                            foreach (Attribute attr in Attribute.GetCustomAttributes(type))
                            {
                                if (attr is Incomplete)
                                {
                                    IsIncomplete = true;
                                }
                            }
                            if (IsIncomplete) continue;
                            Instance = (TouhouBase)Activator.CreateInstance(type, proc);
                            SetText(type.Name.ToUpper() + ": " + Instance.SubTitle);
                            ProcessOpen();
                        }
                        continue;
                    }
                    else
                    {
                        proc.Dispose();
                    }
                }
            };
            ProcessTimer.Start();
        }
    }
}
