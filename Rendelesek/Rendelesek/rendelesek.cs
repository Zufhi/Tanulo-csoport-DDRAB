using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Rendelések
{
    public class rendelesek
    {
        public string datum { get; set; }
        public int rendelesSzam { get; set; }
        public string email { get; set; }
        public List<string> cikkSzam { get; set; }
        public List<int> mennyiseg { get; set; }

        public rendelesek(string date, int orderNumber, string mail, List<string> cikkSz, List<int> mennySz)
        {
            datum = date;
            rendelesSzam = orderNumber;
            email = mail;
            cikkSzam = cikkSz;
            mennyiseg = mennySz;
        }
    }
}
