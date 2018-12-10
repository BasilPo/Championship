using System.Collections.Generic;

namespace ChampionshipService.Entities
{
    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Championship> Championships { get; set; } = new HashSet<Championship>();
    }
}