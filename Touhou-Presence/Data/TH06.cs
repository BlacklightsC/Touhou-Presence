using System;
using System.Diagnostics;

namespace Touhou_Presence.Data
{
    //[Incomplete]
    public class th06 : TouhouBase
    {
        public th06(Process Game)
        {
            this.Game = Game;
            ClientID = "446970252773949440";
            SubTitle = "Embodiment of Scarlet Devil";
            ProgramName = "th06";
            StageOffset = 0x29D6D4;
            CharacterOffset = 0x29D4BD;
            SpellOffset = 0x29D4BE;
            DifficultyOffset = 0x29BCB0;
            IsPauseOffset = 0x29D4BF;
            StatusOffset = 0x29D4C1;
            IsInGameOffset = 0x29D4C1;
            Init();

            WorkerTimer.Elapsed += (sender, e) =>
            {
                // Need smallImage. it will shown character, or difficulty.
                Presence.Assets.LargeImageText = SubTitle;
                if (Game.HasExited)
                {
                    WorkerTimer.Enabled = false;
                    ProcessFinder.ProcessClose();
                    return;
                }
                bool isPause = IsPause;
                if (IsInGame || isPause)
                {
                    if (!IsPlaying)
                    {
                        IsPlaying = true;
                        Presence.Details = StatusString + " " + CharSpellString;
                        Presence.Timestamps.Start = PlayTime = DateTime.UtcNow;
                        return;
                    }
                    Presence.State = DiffChap;
                     
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
        public override int Status { get => BringInt(Game.MainModule.BaseAddress + StatusOffset); }
               
        public override string StatusString {
            get {
                byte[] status = BitConverter.GetBytes(Status);
                if (status[0] == 1)
                {
                    if (status[3] == 1)
                        return "Demonstration";
                    else if (BringBool(Game.MainModule.BaseAddress + 0x29BCBC))
                        return "Watching Replay";
                    else if (status[2] == 1)
                        return "Practicing";
                    else if (IsPause)
                        return "Pausing";
                    else
                        return "Playing";
                }
                else
                {
                    return "In Main Menu";
                }
            }
        }
    }
}
