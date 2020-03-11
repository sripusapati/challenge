using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    public class SeriesModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int SeriesTypes { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> NoOfMatchs { get; set; }
        public int NoOfTeams { get; set; }
        public int CreatedBy { get; set; }
        public Nullable<int> UpdatedBy { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public byte IsActive { get; set; }
        public SeriesTypesModel seriesType { get; set; }
        public List<SeriesTeamsModel> seriesTeams { get; set; }
        public List<SeriesTeamPlayersModel> seriesTeamPlayers { get; set; }
        public List<MatchModel> match { get; set; }
    }
}
