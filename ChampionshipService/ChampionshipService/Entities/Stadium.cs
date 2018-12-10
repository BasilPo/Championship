using System.Collections.Generic;

namespace ChampionshipService.Entities
{
    public class Stadium
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //public int? AddressId { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Game> Games { get; set; } = new HashSet<Game>();
    }
}