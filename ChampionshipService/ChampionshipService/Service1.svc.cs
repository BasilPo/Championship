using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using ChampionshipService.Entities;
using System.Data.Entity;

namespace ChampionshipService
{
    public class CupService : IGameDataContract, ILoginContract, IEntityContract
    {
        ChampionshipContext context = null;

        public GameData[] GetGameData()
        {
            GameData[] gameData = null;
            using (context = new ChampionshipContext()) 
            {
                //eager loading
                var gamesFromDB = context.Games.Include(g => g.FirstTeam)
                    .Include(g => g.SecondTeam)
                    .Include(g => g.Stadium)
                    .Include(g => g.Championship).ToList();
                gameData = new GameData[gamesFromDB.Count];
                for (int i = 0; i < gameData.Length; i++) 
                {
                    gameData[i] = new GameData
                    {
                        Id = gamesFromDB[i].Id,
                        Date = gamesFromDB[i].Date,
                        Time = gamesFromDB[i].Time,
                        Duration = gamesFromDB[i].Duration,
                        StadiumName = gamesFromDB[i].Stadium.Name,
                        ChampionshipName = gamesFromDB[i].Championship.Name,
                        FirstTeam = gamesFromDB[i].FirstTeam.Name,
                        SecondTeam = gamesFromDB[i].SecondTeam.Name,
                        Score = gamesFromDB[i].Score
                    };
                }
            }
            return gameData;
        }

        public bool IsValid(string login, string password)
        {
            bool isSignUp = false;
            using (context = new ChampionshipContext()) 
            {
                User user = context.Users
                    .SingleOrDefault(u => u.Login == login && u.Password == password);
                if (user != null)
                    isSignUp = true;
                return isSignUp;
            }
        }

        public void AddTeam(string name, int year, int numberPlayers, string cityFrom)
        {
            using (context = new ChampionshipContext()) 
            {
                Team team = context.Teams
                    .Where(t => t.Name == name && t.Year.Value == year && t.City.Name == cityFrom)
                    .FirstOrDefault();
                if (team == null)
                {
                    team = new Team { Name = name, NumberPlayers = numberPlayers };
                    Year yearTeam = context.Years.FirstOrDefault(y => y.Value == year);
                    if (yearTeam == null)
                    {
                        yearTeam = new Year { Value = year };
                        context.Years.Add(yearTeam);
                    }
                    City cityTeam = context.Cities.FirstOrDefault(c => c.Name == cityFrom);
                    if (cityTeam == null)
                    {
                        cityTeam = new City { Name = cityFrom };
                        context.Cities.Add(cityTeam);
                    }
                    team.Year = yearTeam;
                    team.City = cityTeam;
                    context.Teams.Add(team);
                    context.SaveChanges();
                }
            }
        }

        public void AddStadium(string name, string address, string city)
        {
            using(context = new ChampionshipContext())
            {
                Stadium stadium = context.Stadia
                    .FirstOrDefault(s => s.Name == name && s.Address.Street == address && s.Address.City.Name == city);
                if (stadium == null)
                {
                    stadium = new Stadium { Name = name };
                    City cityStadium = context.Cities.FirstOrDefault(c => c.Name == city);
                    if (cityStadium == null)
                    {
                        cityStadium = new City { Name = city };
                        context.Cities.Add(cityStadium);
                    }
                    Address addressStadium = context.Addresses.FirstOrDefault(a => a.Street == address);
                    if (addressStadium == null)
                    {
                        addressStadium = new Address { Street = address, City = cityStadium };
                        context.Addresses.Add(addressStadium);
                    }
                    stadium.Address = addressStadium;
                    context.Stadia.Add(stadium);
                    context.SaveChanges();
                }
            }
        }

        public void SettleTeamToHotel(string teamName, int teamYear, string teamCity, string hotelName, string hotelAddress, string cityName)
        {
            using(context = new ChampionshipContext())
            {
                Team team = context.Teams
                    .FirstOrDefault(t => t.Name == teamName && t.Year.Value == teamYear && t.City.Name == teamCity);
                if (team != null)
                {
                    Hotel hotel = context.Hotels.FirstOrDefault(h => h.Name == hotelName && h.Address.Street == hotelAddress);
                    if (hotel == null)
                    {
                        hotel = new Hotel { Name = hotelName };
                        Address address = context.Addresses.FirstOrDefault(a => a.Street == hotelAddress);
                        if (address == null)
                        {
                            address = new Address { Street = hotelAddress };
                            City city = context.Cities.FirstOrDefault(c => c.Name == cityName);
                            if (city == null)
                            {
                                city = new City { Name = cityName };
                                context.Cities.Add(city);
                            }
                            address.City = city;
                            context.Addresses.Add(address);
                        }
                        hotel.Address = address;
                        context.Hotels.Add(hotel);
                    }
                    team.Hotel = hotel;
                    context.SaveChanges();
                }
            }
        }

        public void AddChampionship(string name, DateTime start, DateTime finish, string type)
        {
            using(context = new ChampionshipContext())
            {
                Championship championship = context.Championships
                    .FirstOrDefault(c => c.Name == name && c.StartDate == start && c.FinishDate == finish && c.Type.Name == type);
                if (championship == null)
                {
                    championship = new Championship { Name = name, StartDate = start, FinishDate = finish };
                    Entities.Type typeCup = context.Types.FirstOrDefault(t => t.Name == type);
                    if (typeCup == null)
                    {
                        typeCup = new Entities.Type { Name = type };
                        context.Types.Add(typeCup);
                    }
                    championship.Type = typeCup;
                    context.Championships.Add(championship);
                    context.SaveChanges();
                }
            }
        }

        public void AddGame(DateTime date, DateTime time, TimeSpan span, string teamsName1, string teamsName2, int teamsYear1, int teamsYear2, string teamsCity1, string teamsCity2, string stadiumName, string cupName)
        {
            using(context = new ChampionshipContext())
            {
                Game game = context.Games
                    .FirstOrDefault(g => g.Date == date && g.Time == time && g.FirstTeam.Name == teamsName1 && g.SecondTeam.Name == teamsName2);
                if (game == null)
                {
                    game = new Game { Date = date, Time = time, Duration = span };
                    Stadium stadium = context.Stadia.FirstOrDefault(s => s.Name == stadiumName);
                    Championship championship = context.Championships.FirstOrDefault(c => c.Name == cupName);
                    Team firstTeam = context.Teams
                        .FirstOrDefault(t => t.Name == teamsName1 && t.Year.Value == teamsYear1 && t.City.Name == teamsCity1);
                    Team secondTeam = context.Teams
                        .FirstOrDefault(t => t.Name == teamsName2 && t.Year.Value == teamsYear2 && t.City.Name == teamsCity2);
                    if (stadium != null && championship != null && firstTeam != null && secondTeam != null)
                    {
                        bool isAvailableNumberFirstGame = firstTeam.FirstGames.Where(g => g.Date == date)
                            .Union(firstTeam.SecondGames.Where(g => g.Date == date))
                            .Count() < 2;
                        bool isAvailableNumberSecondGame = secondTeam.FirstGames.Where(g => g.Date == date)
                            .Union(secondTeam.SecondGames.Where(g => g.Date == date))
                            .Count() < 2;
                        if (isAvailableNumberFirstGame && isAvailableNumberSecondGame)
                        {
                            game.Stadium = stadium;
                            game.Championship = championship;
                            game.FirstTeam = firstTeam;
                            game.SecondTeam = secondTeam;
                            context.Games.Add(game);
                            context.SaveChanges();
                        }
                    }
                }
            }
        }

        public void AddScore(int idGame, string score)
        {
            using(context = new ChampionshipContext())
            {
                Game game = context.Games.Find(idGame);
                game.Score = score;
                context.SaveChanges();
            }
        }
    }
}