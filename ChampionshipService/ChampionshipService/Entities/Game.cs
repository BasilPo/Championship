using System;

namespace ChampionshipService.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime Time { get; set; }
        public TimeSpan Duration { get; set; }
        public int? StadiumId { get; set; }
        public int? ChampionshipId { get; set; }
        public int? FirstTeamId { get; set; }
        public int? SecondTeamId { get; set; }
        public string Score { get; set; } 
        public virtual Team FirstTeam { get; set; }
        public virtual Team SecondTeam { get; set; }
        public virtual Stadium Stadium { get; set; }
        public virtual Championship Championship { get; set; }
    }
}