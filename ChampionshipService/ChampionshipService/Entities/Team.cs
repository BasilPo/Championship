using System.Collections.Generic;

namespace ChampionshipService.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? YearId { get; set; }
        public int? CityId { get; set; }
        public int NumberPlayers { get; set; }
        public int? HotelId { get; set; }
        public virtual Year Year { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Game> FirstGames { get; set; } = new HashSet<Game>();
        public virtual ICollection<Game> SecondGames { get; set; } = new HashSet<Game>();
        public virtual Hotel Hotel { get; set; }
    }
}