using System;
using DiscordRPC;

namespace Touhou_Presence
{
    public abstract class TouhouBasePresence : AccessMemory, IDisposable
    {
        private DiscordRpcClient client;
        protected RichPresence Presence;
        protected string ClientID;

        protected virtual void Init()
        {
            client = new DiscordRpcClient(ClientID, false, -1);
            Presence = new RichPresence()
            {
                Assets = new Assets() { LargeImageKey = "cover" },
                Party = new Party(),
                Timestamps = new Timestamps()
                {
                    End = null
                }
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
                if (disposing)
                {
                    if (client != null)
                        client.Dispose();
                    if (Game != null)
                        Game.Dispose();
                    if (ProcessTimer != null)
                        ProcessTimer.Dispose();
                    if (WorkerTimer != null)
                        WorkerTimer.Dispose();
                }

                disposed = true;
            }
        }
        ~TouhouBasePresence()
        {
            Dispose(false);
        }
        #endregion
    }
}