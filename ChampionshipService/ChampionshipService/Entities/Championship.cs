using System;
using System.Collections.Generic;

namespace ChampionshipService.Entities
{
    public class Championship
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int? TypeId { get; set; }
        public virtual Type Type { get; set; }
        public virtual ICollection<Game> Games { get; set; } = new HashSet<Game>();
    }
}