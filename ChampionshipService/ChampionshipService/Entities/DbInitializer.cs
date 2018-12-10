using System.Data.Entity;

namespace ChampionshipService.Entities
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<ChampionshipContext>
    {
        protected override void Seed(ChampionshipContext context)
        {
            //default - preliminary data - set manually
            User user1 = new User { Login = "user1", Password = "u1234" };
            User user2 = new User { Login = "user2", Password = "u5678" };
            context.Users.Add(user1);
            context.Users.Add(user2);

            Type regionCup = new Type { Name = "Region Cup" };
            Type districtCup = new Type { Name = "District Cup" };
            Type cityCup = new Type { Name = "City Cup" };
            context.Types.Add(regionCup);
            context.Types.Add(districtCup);
            context.Types.Add(cityCup);

            context.SaveChanges();
            base.Seed(context);
        }
    }
}