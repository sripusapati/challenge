using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    public class MatchModel
    {
        public int id { get; set; }
        public int SeriesId { get; set; }
        public int SeriesTeamId { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string GroundName { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public byte IsActive { get; set; }
    }
}
