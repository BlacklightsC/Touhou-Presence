using System;
using System.Timers;
using DiscordRPC;

namespace Touhou_Presence
{
    public abstract class TouhouBasePresence : AccessMemory, IDisposable
    {
        private DiscordRpcClient client;
        protected RichPresence Presence;
        protected string ClientID;
        protected Timer WorkerTimer = new Timer(3000);

        protected virtual void Init()
        {
            client = new DiscordRpcClient(ClientID, false, -1);
            Presence = new RichPresence()
            {
                Assets = new Assets { LargeImageKey = "cover" },
                Party = new Party(),
                Timestamps = new Timestamps { End = null }
            };
            client.Initialize();
        }

        protected void UpdatePresence()
        {
            client.SetPresence(Presence);
        }

        #region [    IDisposable Implemention    ]
        private bool disposed = false;
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                disposed = true;
                if (disposing)
                {
                    if (WorkerTimer != null)
                    {
                        using (WorkerTimer)
                        {
                            WorkerTimer.Stop();
                            WorkerTimer.Close();
                        }
                    }
                    if (client != null)
                    {
                        using (client)
                        {
                            try
                            {
                                client.ClearPresence();
                            }
                            catch (NullReferenceException)
                            {

                            }
                        }
                    }
                    if (Game != null)
                        Game.Dispose();
                }
            }
        }
        ~TouhouBasePresence()
        {
            Dispose(false);
        }
        #endregion
    }
}