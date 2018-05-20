using System.Diagnostics;

namespace Touhou_Presence.Data
{
    public class th07 : TouhouBase
    {
        public th07(Process Game)
        {
            this.Game = Game;
            ClientID = "445995245767884800";
            SubTitle = "Perfect Cherry Blossom";
            ProgramName = "th07";
            StageOffset = 0x22F85C;
            CharacterOffset = 0x22F645;
            SpellOffset = 0x22F646;
            DifficultyOffset = 0x226280;
            IsPauseOffset = 0x22F640;
            StatusOffset = 0x22F648;
            IsInGameOffset = 0x22FBDC;
            Init();

            WorkerTimer.Elapsed += ElapsedFunc;
            WorkerTimer.Start();
        }

        public override string CharacterString {
            get {
                switch (Character)
                {
                    case 0: return "Reimu";
                    case 1: return "Marisa";
                    case 2: return "Sakuya";
                }
                return string.Empty;
            }
        }
        public override string SpellString {
            get {
                switch (Spell)
                {
                    case 0: return "A";
                    case 1: return "B";
                }
                return string.Empty;
            }
        }
        public override string CharSpellString {
            get {
                return CharacterString + " " + SpellString;
                // Basically was must use CharSpellOffset.
            }
        }
        public override string StatusString {
            get {
                if (!IsInGame) return "In Main Menu";
                if (IsPause) return "Pausing";
                switch (Status) {
                    case 4: return "Playing";
                    case 5: return "Practicing";
                    case 12: return "Watching Replay";
                    case 14: return "Demonstration";
                }
                return string.Empty;
            }
        }
    }
}
