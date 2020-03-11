using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLib
{
    public class SeriesTeamsModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int SeriesId { get; set; }
        public string Logo { get; set; }
        public bool IsActive { get; set; }
    }
}
