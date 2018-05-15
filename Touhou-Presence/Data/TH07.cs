using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Touhou_Presence.Data
{
    internal class TH07 : TouhouBase
    {
        internal TH07()
        {
            ProgramName = "th07";
            ChapterOffset = 0x22F85C;
            CharacterOffset = 0x22F645;
            SpellOffset = 0x22F646;
            DifficultyOffset = 0x226280;
            IsPauseOffset = 0x22F640;
            CharSpellOffset = 0x22F647;
            StatusOffset = 0x22F648;
            IsInGameOffset = 0x22FBDC;
            Init();
        }

        public override string StatusString { get; }
    }
}
