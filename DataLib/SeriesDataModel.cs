using ModelLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib
{
    public class SeriesDataModel
    {
        public int seriesId { get; set; }
        ChallengeEntities challengeEntities = new ChallengeEntities();

        public List<SeriesModel> GetAllSeries()
        {
            List<SeriesModel> series = new List<SeriesModel>();

            var seriesData = (from s in challengeEntities.Series
                              join st in challengeEntities.SeriesTypes on s.SeriesTypes equals st.id
                              where s.IsActive == 1
                              select new { s, st }).ToList();

            if (seriesData != null && seriesData.Count > 0)
            {
                foreach(var eachRow in seriesData)
                {
                    SeriesModel s = new SeriesModel();
                    s = JsonConvert.DeserializeObject<SeriesModel>(JsonConvert.SerializeObject(eachRow.s));
                    s.seriesType = JsonConvert.DeserializeObject<SeriesTypesModel>(JsonConvert.SerializeObject(eachRow.st));
                    series.Add(s);
                }
            }
            return series;
        }

        public SeriesModel GetSeriesBySeriesId()
        {
            SeriesModel series = new SeriesModel();

            var seriesData = (from s in challengeEntities.Series
                              join st in challengeEntities.SeriesTypes on s.SeriesTypes equals st.id
                              where s.id == seriesId
                              select new { s, st }).FirstOrDefault();

            if (seriesData != null && seriesData.s != null)
            {
                series = JsonConvert.DeserializeObject<SeriesModel>(JsonConvert.SerializeObject(seriesData.s));
                series.seriesType = JsonConvert.DeserializeObject<SeriesTypesModel>(JsonConvert.SerializeObject(seriesData.st));
                series.seriesTeams = GetSeriesTeamBySeriesId();
                series.seriesTeamPlayers = GetSeriesTeamPlayersBySeriesId();
                series.match = GetMatchsBySeriesId();
            }
            return series;
        }

        public List<SeriesTeamsModel> GetSeriesTeamBySeriesId()
        {
            List<SeriesTeamsModel> listSeriesTeamsModels = new List<SeriesTeamsModel>();
            var seriesTeam = (from st in challengeEntities.SeriesTeams
                              where st.SeriesId == seriesId
                              select new { st }).ToList();

            if (seriesTeam != null && seriesTeam.Count > 0)
            {
                foreach (var eachRow in seriesTeam)
                {
                    SeriesTeamsModel seriesTeamsModel = new SeriesTeamsModel();
                    seriesTeamsModel = JsonConvert.DeserializeObject<SeriesTeamsModel>(JsonConvert.SerializeObject(eachRow.st));
                    listSeriesTeamsModels.Add(seriesTeamsModel);
                }
            }
            return listSeriesTeamsModels;
        }

        public List<SeriesTeamPlayersModel> GetSeriesTeamPlayersBySeriesId()
        {
            List<SeriesTeamPlayersModel> seriesTeamPlayersModels = new List<SeriesTeamPlayersModel>();
            var seriesTeamPlayers = (from st in challengeEntities.SeriesTeamPlayers
                              join p in challengeEntities.Players on st.PlayerId equals p.id
                              where st.SeriesId == seriesId
                              select new { st, p }).ToList();

            if (seriesTeamPlayers != null && seriesTeamPlayers.Count > 0)
            {
                foreach (var eachRow in seriesTeamPlayers)
                {
                    SeriesTeamPlayersModel seriesPlayers = new SeriesTeamPlayersModel();
                    seriesPlayers = JsonConvert.DeserializeObject<SeriesTeamPlayersModel>(JsonConvert.SerializeObject(eachRow.st));
                    seriesPlayers.player = JsonConvert.DeserializeObject<PlayersModel>(JsonConvert.SerializeObject(eachRow.p));
                    seriesTeamPlayersModels.Add(seriesPlayers);
                }
            }
            return seriesTeamPlayersModels;
        }

        public List<MatchModel> GetMatchsBySeriesId()
        {
            List<MatchModel> matchModels = new List<MatchModel>();
            var seriesMatchs = (from m in challengeEntities.Matches
                              where m.SeriesId == seriesId
                              select new { m }).ToList();

            if (seriesMatchs != null && seriesMatchs.Count > 0)
            {
                foreach (var eachRow in seriesMatchs)
                {
                    MatchModel seriesMatch = new MatchModel();
                    seriesMatch = JsonConvert.DeserializeObject<MatchModel>(JsonConvert.SerializeObject(eachRow.m));
                    matchModels.Add(seriesMatch);
                }
            }

            return matchModels;
        }

        public SeriesModel AddSeries(SeriesModel series)
        {
            SeriesModel seriesModel = new SeriesModel();

            using (ChallengeEntities challengeEntities = new ChallengeEntities())
            {
                var seriesModelData = JsonConvert.DeserializeObject<Series>(JsonConvert.SerializeObject(series));
                challengeEntities.Series.Add(seriesModelData);
                challengeEntities.SaveChanges();
                seriesModel = JsonConvert.DeserializeObject<SeriesModel>(JsonConvert.SerializeObject(seriesModelData));
            }

            return seriesModel;
        }

        public SeriesModel UpdateSeries(SeriesModel series)
        {
            SeriesModel seriesModel = new SeriesModel();

            using (ChallengeEntities challengeEntities = new ChallengeEntities())
            {
                var seriesData = challengeEntities.Series.Where(x => x.id == series.ID).FirstOrDefault();
                seriesData = JsonConvert.DeserializeObject<Series>(JsonConvert.SerializeObject(seriesData));
                challengeEntities.SaveChanges();
                series = JsonConvert.DeserializeObject<SeriesModel>(JsonConvert.SerializeObject(seriesData));
            }

            return series;
        }
    }
}
