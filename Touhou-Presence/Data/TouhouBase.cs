using System;

namespace Touhou_Presence.Data
{
    public abstract class TouhouBase : AccessMemory
    {
        public string ProgramName { get; protected set; }

        protected IntPtr DifficultyOffset = IntPtr.Zero;
        public int Difficulty { get; }

        protected IntPtr ChapterOffset = IntPtr.Zero;
        public int Chapter { get; }

        protected IntPtr CharacterOffset = IntPtr.Zero;
        public int Character { get => BringByte(CharacterOffset); }
        public virtual string CharacterString { get; }

        protected IntPtr SpellOffset = IntPtr.Zero;
        public int Spell { get => BringByte(SpellOffset); }
        public virtual string SpellString { get; }

        protected IntPtr CharSpellOffset = IntPtr.Zero;
        public int CharSpell { get => BringByte(CharSpellOffset); }
        public virtual string CharSpellString { get; }

        protected IntPtr IsPauseOffset = IntPtr.Zero;
        public bool IsPause { get => BringBool(IsPauseOffset); }

        protected IntPtr StatusOffset = IntPtr.Zero;
        public int Status { get; }
        public virtual string StatusString { get; }
    }
}
