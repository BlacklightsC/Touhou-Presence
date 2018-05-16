using System;

namespace Touhou_Presence.Data
{
    public abstract class TouhouBase : public AccessMemory, public TouhouBasePresence
    {
        protected IntPtr MainOffset = new IntPtr(0x400000);

        public string ProgramName { get; protected set; }

        protected int DifficultyOffset = 0;
        public virtual string Difficulty {
            get {
                switch (BringByte(MainOffset + DifficultyOffset))
                {
                    case 0: return "Easy";
                    case 1: return "Normal";
                    case 2: return "Hard";
                    case 3: return "Lunatic";
                    default: return "Extra";
                }
            }
        }

        protected int ChapterOffset = 0;
        public virtual int Chapter { get => BringByte(MainOffset + ChapterOffset); }

        protected int CharacterOffset = 0;
        public int Character { get => BringByte(MainOffset + CharacterOffset); }
        public virtual string CharacterString { get; }

        protected int SpellOffset = 0;
        public int Spell { get => BringByte(MainOffset + SpellOffset); }
        public virtual string SpellString { get; }

        protected int CharSpellOffset = 0;
        public int CharSpell { get => BringByte(MainOffset + CharSpellOffset); }
        public virtual string CharSpellString { get; }

        protected int IsPauseOffset = 0;
        public bool IsPause { get => BringBool(MainOffset + IsPauseOffset); }

        protected int IsInGameOffset = 0;
        public bool IsInGame { get => BringBool(MainOffset + IsInGameOffset); }
        
        protected int StatusOffset = 0;
        public int Status { get => BringByte(MainOffset + StatusOffset); }
        public virtual string StatusString { get; }
    }
}
