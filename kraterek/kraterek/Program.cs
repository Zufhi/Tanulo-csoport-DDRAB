using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace kraterek
{
    class Program
    {
        static void Main(string[] args)
        {
            List<krater> Adatok = new List<krater>();
            foreach (var sor in File.ReadAllLines("felszin_tvesszo.txt")) 
            {
                Adatok.Add(new krater(sor));
            }

            Console.WriteLine("2. feladat");
            int darab = 0;
            foreach (var a in Adatok) 
            {
                darab++;
            }
            Console.WriteLine("A kráterek száma: " + darab);


            Console.WriteLine("3. feladat");
            Console.Write("Kérem egy kráter nevét: ");
            string input = Console.ReadLine();
            foreach (var a in Adatok) 
            {
                if (a.nev == input) 
                {
                    Console.WriteLine($"A(z) {a.nev} középpontja X={a.Xkordinata} Y={a.Ykordinata} sugara R={a.sugar}.");
                }
            }

            Console.WriteLine("4. feladat");
            double max = Adatok[0].sugar;
            string maxNev = Adatok[0].nev;

            foreach (var a in Adatok) 
            {
                if (a.sugar > max) 
                {
                    max = a.sugar;
                    maxNev = a.nev;
                }
            }

            Console.WriteLine($"A legnagyobb kráter neve és sugara: {maxNev} {max}");
        }

        static double tavolsag(double x1, double y1, double x2, double y2) 
        { 
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)); ;
        }
    }
}
