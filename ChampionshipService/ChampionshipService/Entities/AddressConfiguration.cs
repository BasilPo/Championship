using System.Data.Entity.ModelConfiguration;

namespace ChampionshipService.Entities
{
    public class AddressConfiguration : EntityTypeConfiguration<Address> 
    {
        public AddressConfiguration()
        {
            //relationship zero-or-one-to-one
            HasOptional(a => a.Stadium)
                .WithRequired(s => s.Address)
                .WillCascadeOnDelete(false);
            HasOptional(a => a.Hotel)
                .WithRequired(h => h.Address)
                .WillCascadeOnDelete(false);
        }
    }
}