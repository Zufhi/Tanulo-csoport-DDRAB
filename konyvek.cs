using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace konyvek
{
    public class konyvek
    {
        public int Ev {  get; set; }
        public int NE { get; set; }
        public string Eredete { get; set; }
        public string Leiras { get; set; }
        public int Peldany { get; set; }

        public konyvek(string s)
        {
            Ev = int.Parse(s.Split(';')[0]);
            NE = int.Parse(s.Split(';')[1]);
            Eredete = s.Split(';')[2];
            Leiras = s.Split(';')[3];
            Peldany = int.Parse(s.Split(';')[4]);
        }
    }
}

