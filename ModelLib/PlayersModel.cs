using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    public class PlayersModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Bats { get; set; }
        public string Bowls { get; set; }
        public decimal? Credits { get; set; }
        public int Nationality { get; set; }
        public string Logo { get; set; }
        public decimal TotalPoints { get; set; }
        public bool IsActive { get; set; }
        public NationalityModel nationality { get; set; }
    }
}
