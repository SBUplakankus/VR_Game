using System;

namespace Systems.Stats
{
    public class ArenaRecord
    {
                
        public string ArenaId;
        public int TimesAttempted;
        public int TimesCompleted;
        public int BestScore;
        public float BestTime;         
        public int HighestWave;       
        public int TotalKills;
        public int TotalDeaths;
        public DateTime FirstCompletion;
        public DateTime LastPlayed;

                
                
        public float CompletionRate => (float)TimesCompleted / TimesAttempted;

            }
}