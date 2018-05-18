using System;

namespace Touhou_Presence
{
    public abstract class TouhouBase : TouhouBasePresence
    {

        protected override void Init()
        {
            base.Init();
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
                    default:return "Extra";
                }
            }
        }

        protected int ChapterOffset = 0;
        public virtual int Chapter { get => BringByte(Game.MainModule.BaseAddress + ChapterOffset); }

        protected int CharacterOffset = 0;
        public int Character { get => BringByte(Game.MainModule.BaseAddress + CharacterOffset); }
        public virtual string CharacterString { get; }

        protected int SpellOffset = 0;
        public int Spell { get => BringByte(Game.MainModule.BaseAddress + SpellOffset); }
        public virtual string SpellString { get; }

        protected int CharSpellOffset = 0;
        public int CharSpell { get => BringByte(Game.MainModule.BaseAddress + CharSpellOffset); }
        public virtual string CharSpellString { get; }

        protected int IsPauseOffset = 0;
        public bool IsPause { get => BringBool(Game.MainModule.BaseAddress + IsPauseOffset); }

        protected int IsInGameOffset = 0;
        public bool IsInGame { get => BringBool(Game.MainModule.BaseAddress + IsInGameOffset); }
        
        protected int StatusOffset = 0;
        public int Status { get => BringByte(Game.MainModule.BaseAddress + StatusOffset); }
        public virtual string StatusString { get; }

        protected bool IsPlaying = false;
        protected bool WasPause = false;
        protected DateTime? PlayTime;
        protected string LastStatus = null;
    }
}
