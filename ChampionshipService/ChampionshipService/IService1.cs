using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace ChampionshipService
{
    [ServiceContract]
    public interface IGameDataContract
    {
        [OperationContract]
        GameData[] GetGameData();
    }

    [ServiceContract]
    public interface ILoginContract
    {
        [OperationContract]
        bool IsValid(string login, string password);
    }

    [ServiceContract]
    public interface IEntityContract
    {
        [OperationContract(IsOneWay = true)]
        void AddTeam(string name, int year, int numberPlayers, string cityFrom);

        [OperationContract(IsOneWay = true)]
        void AddStadium(string name, string address, string city);

        [OperationContract(IsOneWay = true)]
        void AddChampionship(string name, DateTime start, DateTime finish, string type);

        [OperationContract(IsOneWay = true)]
        void SettleTeamToHotel(string teamName, int teamYear, string teamCity, string hotelName, string hotelAddress, string cityName);

        [OperationContract(IsOneWay = true)]
        void AddGame(DateTime date, DateTime time, TimeSpan span, string teamsName1, string teamsName2, int teamsYear1, int teamsYear2, string teamsCity1, string teamsCity2, string stadiumName, string cupName);

        [OperationContract(IsOneWay = true)]
        void AddScore(int idGame, string score);
    }

    [DataContract]
    public class GameData
    { 
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public DateTime Time { get; set; }
        [DataMember]
        public TimeSpan Duration { get; set; }
        [DataMember]
        public string StadiumName { get; set; }
        [DataMember]
        public string ChampionshipName { get; set; }
        [DataMember]
        public string FirstTeam { get; set; }
        [DataMember]
        public string SecondTeam { get; set; }
        [DataMember]
        public string Score { get; set; }
    }
}