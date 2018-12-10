using System.Collections.Generic;

namespace ChampionshipService.Entities
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Team> Teams { get; set; } = new HashSet<Team>();
        public virtual ICollection<Address> Addresses { get; set; } = new HashSet<Address>();
    }
}