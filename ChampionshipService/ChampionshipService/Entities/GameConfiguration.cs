using System.Data.Entity.ModelConfiguration;

namespace ChampionshipService.Entities
{
    public class GameConfiguration : EntityTypeConfiguration<Game>
    {
        public GameConfiguration()
        {
            HasRequired(g => g.FirstTeam)
                .WithMany(t => t.FirstGames)
                .HasForeignKey(g => g.FirstTeamId)
                .WillCascadeOnDelete(false);
            HasRequired(g => g.SecondTeam)
                .WithMany(t => t.SecondGames)
                .HasForeignKey(g => g.SecondTeamId)
                .WillCascadeOnDelete(false);
        }
    }
}