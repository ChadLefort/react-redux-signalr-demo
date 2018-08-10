using System;

namespace ReactReduxSignalRDemo.Models
{
    public class Stats
    {
        public int StatsId { get; set; }
        public int UserId { get; set; }
        public int Kills { get; set; }
        public int Deaths { get; set; }
        public decimal KillDeathRatio => Math.Round(decimal.Divide(Kills, Deaths) , 2);
        public int Wins { get; set; }
        public int Losses { get; set; }
        public decimal WinLossRatio => Math.Round(decimal.Divide(Wins, Losses), 2);
    }
}
