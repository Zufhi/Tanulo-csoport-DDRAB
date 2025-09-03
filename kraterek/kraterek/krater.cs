using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kraterek
{
    internal class krater
    {
        public double Xkordinata { get; set; }
        public double Ykordinata { get; set; }
        public double sugar { get; set; }
        public string nev { get; set; }

        public krater(string bemenet) 
        {
            Xkordinata = Convert.ToDouble(bemenet.Split("\t")[0]);
            Ykordinata = Convert.ToDouble(bemenet.Split("\t")[1]);
            sugar = Convert.ToDouble(bemenet.Split("\t")[2]);
            nev = bemenet.Split("\t")[3];
        }
    }
}
