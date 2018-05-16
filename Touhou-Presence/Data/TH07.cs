using System;
using System.Diagnostics;

namespace Touhou_Presence.Data
{
    internal class th07 : TouhouBase
    {
        internal th07()
        {
            ClientID = "445995245767884800";
            SubTitle = "Perfect Cherry Blossom";
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

            WorkerTimer.Elapsed += (sender, e) =>
            {
                if (Game is null || Game.HasExited)
                {
                    Process[] Processes = Process.GetProcessesByName(ProgramName);
                    if (Processes.Length == 0) return;
                    Game = Processes[0];
                }
                // Need smallImage. it will shown character, or difficulty.
                Presence.Assets.LargeImageText = SubTitle;
                if (IsInGame)
                {
                    if (!IsPlaying)
                    {
                        IsPlaying = true;
                        Presence.Details = StatusString + " " + CharSpellString;
                        Presence.Timestamps.Start = PlayTime = DateTime.UtcNow;
                        return;
                    }
                    Presence.State = Difficulty + " ~ Chapter " + Chapter;
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
            };
        WorkerTimer.Enabled = true;
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
                }
                return string.Empty;
            }
        }
    }
}
