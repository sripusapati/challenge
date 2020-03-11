using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelLib;
using Newtonsoft.Json;

namespace DataLib
{
    public class PlayersDataModel
    {
        public int nationId { get; set; }
        
        public List<PlayersModel> GetPlayerByNationId()
        {
            List<PlayersModel> players = new List<PlayersModel>();
            ChallengeEntities challengeEntities = new ChallengeEntities();

            var playersData = (from pl in challengeEntities.Players
                     join n in challengeEntities.Nationalities on pl.Nationality equals n.id
                     where pl.Nationality == nationId
                     select new { pl, n }).ToList();

            if (playersData != null && playersData.Count > 0)
            {                
                foreach(var eachRow in playersData)
                {
                    PlayersModel p = new PlayersModel();
                    p = JsonConvert.DeserializeObject<PlayersModel>(JsonConvert.SerializeObject(eachRow.pl));
                    p.nationality = JsonConvert.DeserializeObject<NationalityModel>(JsonConvert.SerializeObject(eachRow.n));
                    players.Add(p);
                }
            }
            return players;
        }

        public PlayersModel AddPlayer(PlayersModel player)
        {
            PlayersModel players = new PlayersModel();

            using (ChallengeEntities challengeEntities = new ChallengeEntities())
            {
                var playersModelData = JsonConvert.DeserializeObject<Player>(JsonConvert.SerializeObject(player));
                challengeEntities.Players.Add(playersModelData);
                challengeEntities.SaveChanges();
                players = JsonConvert.DeserializeObject<PlayersModel>(JsonConvert.SerializeObject(playersModelData));
            }

            return players;
        }

        public PlayersModel UpdatePlayer(PlayersModel player)
        {
            PlayersModel players = new PlayersModel();

            using (ChallengeEntities challengeEntities = new ChallengeEntities())
            {
                var playersData = challengeEntities.Players.Where(x => x.id == player.ID).FirstOrDefault();
                playersData = JsonConvert.DeserializeObject<Player>(JsonConvert.SerializeObject(player));
                challengeEntities.SaveChanges();
                players = JsonConvert.DeserializeObject<PlayersModel>(JsonConvert.SerializeObject(playersData));
            }

            return players;
        }

        public PlayersModel GetPlayerById(int PlayerId)
        {
            PlayersModel players = new PlayersModel();
            using (ChallengeEntities challengeEntities = new ChallengeEntities())
            {
                var playersData = (from pl in challengeEntities.Players
                                   join n in challengeEntities.Nationalities on pl.Nationality equals n.id
                                   where pl.id == PlayerId
                                   select new { pl, n }).ToList();
                if (playersData != null && playersData.Count > 0)
                {
                    foreach (var eachRow in playersData)
                    {
                        players = JsonConvert.DeserializeObject<PlayersModel>(JsonConvert.SerializeObject(eachRow.pl));
                        players.nationality = JsonConvert.DeserializeObject<NationalityModel>(JsonConvert.SerializeObject(eachRow.n));                        
                    }
                }
            }
            return players;
        }
    }
}
