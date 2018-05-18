using System;

namespace Touhou_Presence
{
    public abstract class TouhouBase : TouhouBasePresence
    {
        protected string LastStatus = null;
        protected bool IsPlaying = false;
        protected bool WasPause = false;
        protected DateTime? PlayTime;

        protected override void Init()
        {
            base.Init();
        }

        protected virtual void ElapsedFunc(object sender, EventArgs e)
        {
            // Need smallImage. it will shown character, or difficulty.
            Presence.Assets.LargeImageText = SubTitle;
            if (Game.HasExited)
            {
                WorkerTimer.Enabled = false;
                ProcessFinder.ProcessClose();
                return;
            }
            if (IsInGame)
            {
                if (!IsPlaying)
                {
                    IsPlaying = true;
                    Presence.Details = StatusString + " " + CharSpellString;
                    Presence.Timestamps.Start = PlayTime = DateTime.UtcNow;
                    return;
                }
                Presence.State = DiffChap;
                bool isPause = IsPause;
                if (!WasPause && isPause)
                {
                    WasPause = true;
                    Presence.Details = "Pausing " + CharSpellString;
                    Presence.Timestamps.Start = DateTime.UtcNow;
                }
                else if (WasPause && !isPause)
                {
                    WasPause = false;
                    Presence.Details = StatusString + " " + CharSpellString;
                    Presence.Timestamps.Start = (PlayTime += DateTime.UtcNow - Presence.Timestamps.Start);
                }
            }
            else
            {
                IsPlaying = false;
                Presence.Details = "In Main Menu";
                Presence.Timestamps.Start = PlayTime = null;
                Presence.State = null;
            }
            UpdatePresence();
        }

        public string ProgramName { get; protected set; }
        public string SubTitle { get; protected set; }

        protected int DifficultyOffset = 0;
        public virtual string Difficulty {
            get {
                switch (BringByte(Game.MainModule.BaseAddress + DifficultyOffset))
                {
                    case 0: return "Easy";
                    case 1: return "Normal";
                    case 2: return "Hard";
                    case 3: return "Lunatic";
                    case 4: return "Extra Stage";
                    default: return "Unknown";
                }
            }
        }

        protected int StageOffset = 0;
        public virtual int Stage { get => BringByte(Game.MainModule.BaseAddress + StageOffset); }

        public virtual string DiffChap {
            get {
                string difficulty = Difficulty;
                if (difficulty == "Extra Stage")
                {
                    return difficulty;
                }
                else
                {
                    return difficulty + " ~ Stage " + Stage;
                }
            }
        }

        protected int CharacterOffset = 0;
        public virtual int Character { get => BringByte(Game.MainModule.BaseAddress + CharacterOffset); }
        public virtual string CharacterString { get; }

        protected int SpellOffset = 0;
        public virtual int Spell { get => BringByte(Game.MainModule.BaseAddress + SpellOffset); }
        public virtual string SpellString { get; }

        protected int CharSpellOffset = 0;
        public virtual int CharSpell { get => BringByte(Game.MainModule.BaseAddress + CharSpellOffset); }
        public virtual string CharSpellString { get => CharacterString + " " + SpellString; }

        protected int IsPauseOffset = 0;
        public virtual bool IsPause { get => BringBool(Game.MainModule.BaseAddress + IsPauseOffset); }

        protected int IsInGameOffset = 0;
        public virtual bool IsInGame { get => BringBool(Game.MainModule.BaseAddress + IsInGameOffset); }
        
        protected int StatusOffset = 0;
        public virtual int Status { get => BringByte(Game.MainModule.BaseAddress + StatusOffset); }
        public virtual string StatusString { get; }
    }
}
