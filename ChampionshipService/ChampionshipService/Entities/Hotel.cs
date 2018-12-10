using System.Collections.Generic;

namespace ChampionshipService.Entities
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int? AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Team> Teams { get; set; } = new HashSet<Team>();
    }
}