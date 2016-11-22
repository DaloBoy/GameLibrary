using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameLibrary.Model
{
    public class Game
    {
        public string title { get; set; }
        public double pris { get; set; }
        public string dato { get; set; }
        public string comment { get; set; }

        public override string ToString()
        {
            return title + "  Prisen er  " + pris + "kr,-";
        }
    }
}
