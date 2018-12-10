using System.Data.Entity;

namespace ChampionshipService.Entities
{
    public class ChampionshipContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Type> Types { get; set; }
        public DbSet<Championship> Championships { get; set; }
        public DbSet<Year> Years { get; set; }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<Stadium> Stadia { get;set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Game> Games { get; set; }
        
        public ChampionshipContext() : base("ChampionshipDB")
        {
            Database.SetInitializer(new DbInitializer());
            //manual database initialization
            Database.Initialize(false);
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new GameConfiguration());
            modelBuilder.Configurations.Add(new AddressConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}