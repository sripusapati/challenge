using ModelLib;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLib
{
    public class MatchDataModel
    {
        public MatchModel AddMatch(MatchModel match)
        {
            MatchModel matchModel = new MatchModel();

            using (ChallengeEntities challengeEntities = new ChallengeEntities())
            {
                var matchModelData = JsonConvert.DeserializeObject<Match>(JsonConvert.SerializeObject(match));
                challengeEntities.Matches.Add(matchModelData);
                challengeEntities.SaveChanges();
                matchModel = JsonConvert.DeserializeObject<MatchModel>(JsonConvert.SerializeObject(matchModelData));
            }

            return matchModel;
        }

        public MatchModel UpdateMatch(MatchModel match)
        {
            MatchModel matchModel = new MatchModel();

            using (ChallengeEntities challengeEntities = new ChallengeEntities())
            {
                var matchModelData = challengeEntities.Matches.Where(x => x.id == match.id).FirstOrDefault();
                matchModelData = JsonConvert.DeserializeObject<Match>(JsonConvert.SerializeObject(match));
                challengeEntities.SaveChanges();
                matchModel = JsonConvert.DeserializeObject<MatchModel>(JsonConvert.SerializeObject(matchModelData));
            }

            return matchModel;
        }
    }
}
