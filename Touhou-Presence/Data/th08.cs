using System.Diagnostics;

namespace Touhou_Presence.Data
{
    public class th08 : TouhouBase
    {
        public th08(Process Game)
        {
            this.Game = Game;
            ClientID = "447393228401147914";
            SubTitle = "Imperishable Night";
            ProgramName = "th08";
            StageOffset = 0x124D2D8;
            CharacterOffset = 0x124CF48;
            DifficultyOffset = 0x124CF49;
            IsPauseOffset = 0x124D0A0;
            StatusOffset = 0x124D0B4;
            IsInGameOffset = 0x120F41F;
            Init();

            WorkerTimer.Elapsed += ElapsedFunc;
            WorkerTimer.Start();
        }

        public override string CharacterString {
            get {
                switch (Character)
                {
                    case 0: return "Border Team";
                    case 1: return "Magic Team";
                    case 2: return "Scarlet Team";
                    case 3: return "Netherworld Team";
                    case 4: return "Reimu";
                    case 5: return "Yukari";
                    case 6: return "Marisa";
                    case 7: return "Alice";
                    case 8: return "Sakuya";
                    case 9: return "Remilia";
                    case 10: return "Youmu";
                    case 11: return "Yuyuko";
                }
                return string.Empty;
            }
        }
        public string StageString {
            get {
                switch (Stage)
                {
                    case 1: return "Stage 1";
                    case 2: return "Stage 2";
                    case 4: return "Stage 3";
                    case 8: return "Stage 4 Uncanny";
                    case 16: return "Stage 4 Powerful";
                    case 32: return "Stage 5";
                    case 64: return "Final";
                    case 128: return "Final B";
                    default: return string.Empty;
                }
            }
        }

        public override string DiffChap {
            get {
                string difficulty = Difficulty;
                if (difficulty == "Extra")
                {
                    return difficulty;
                }
                else
                {
                    return difficulty + " ~ " + StageString;
                }
            }
        }
        public override string StatusString {
            get {
                if (!IsInGame) return "In Main Menu";
                if (IsPause) return "Pausing";
                switch (Status)
                {
                    case 4: return "Playing";
                    case 5: return "Practicing";
                    case 12: return "Watching Replay";
                    case 14: return "Demonstration";
                    case 133: return "Spell Practicing";
                }
                return string.Empty;
            }
        }
    }
}
