using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    public class SeriesTeamPlayersModel
    {
        public int ID { get; set; }
        public int SeriesId { get; set; }
        public int SeriesTeamId { get; set; }
        public int PlayerId { get; set; }
        public bool IsActive { get; set; }
        public PlayersModel player { get; set; }
    }
}
