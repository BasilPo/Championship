using System.Collections.Generic;

namespace ChampionshipService.Entities
{
    public class Year
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public virtual ICollection<Team> Teams { get; set; } = new HashSet<Team>();
    }
}