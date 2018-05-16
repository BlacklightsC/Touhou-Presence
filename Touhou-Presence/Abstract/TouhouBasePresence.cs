using System;
using DiscordRPC;

namespace Touhou_Presence
{
    public abstract class TouhouBasePresence : IDisposable
    {
        protected DiscordRpcClient client;
        protected RichPresence presence;
        protected string ClientID;

        protected void Init()
        {
            client = new DiscordRpcClient(ClientID, false, -1);
            presence = new RichPresence()
            {
                Assets = new Assets() { LargeImageKey = "Cover" },
                Party = new Party(),
                Timestamps = new Timestamps()
            };
            client.Initialize();
            client.SetPresence(presence);
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
                    if (client != null)
                        client.Dispose();
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