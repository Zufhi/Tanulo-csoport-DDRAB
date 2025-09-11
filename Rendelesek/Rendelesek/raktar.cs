using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rendelések
{
    internal class raktar
    {
        public string cikkSzam { get; set; }
        public string nev { get; set; }
        public int ar { get; set; }
        public int mennyiseg { get; set; }

        public raktar(string cSz, string n, int a, int m)
        {
            cikkSzam = cSz;
            nev = n;
            ar = a;
            mennyiseg = m;
        }
    }
}
