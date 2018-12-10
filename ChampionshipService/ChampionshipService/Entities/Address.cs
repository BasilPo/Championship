namespace ChampionshipService.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public int? CityId { get; set; }
        public virtual Stadium Stadium { get; set; }
        public virtual Hotel Hotel { get; set; }
        public virtual City City { get; set; }
    }
}