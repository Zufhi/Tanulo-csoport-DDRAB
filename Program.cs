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
        static double tavolsag(double x1, double y1, double x2, double y2)
        {
            return Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1)); ;
        }
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


            Console.WriteLine("6. feladat");
            Console.Write("Kérem egy kráter nevét: ");
            string input2 = Console.ReadLine();
            List<string> NincsKozosResz = new List<string>();
            krater BekertKrater = null;

            foreach (var a in Adatok)
            {
                if (a.nev == input2) 
                {
                    BekertKrater = a;
                    break;
                }
            }

            foreach (var a in Adatok) 
            {
                if (a.nev != BekertKrater.nev) 
                {
                    if (tavolsag(a.Xkordinata, a.Ykordinata, BekertKrater.Xkordinata, BekertKrater.Ykordinata) > (a.sugar + BekertKrater.sugar)) 
                    {
                        NincsKozosResz.Add(a.nev);
                    }
                }
            }

            Console.Write("Nincs közös része: ");
            foreach (var n in NincsKozosResz) 
            {
                Console.Write($" {n},");
            }

            Console.WriteLine("7. feladat");

            foreach (var a in Adatok) 
            {
                foreach (var b in Adatok) 
                {
                    if (a.sugar > b.sugar) 
                    {
                        if (tavolsag(a.Xkordinata, a.Ykordinata, b.Xkordinata, b.Ykordinata) < (a.sugar - b.sugar)) 
                        {
                            Console.WriteLine($"A(z) {a.nev} kráter tartalmazza a(z) {b.nev} krátert.");
                        }
                    }
                }
            }

            StreamWriter sw = new StreamWriter("terulet.txt");

            foreach (var a in Adatok) 
            {
                sw.WriteLine($"{Math.Round(((a.sugar * a.sugar) * Math.PI), 2)}\t{a.nev}");
            }

            sw.Close();
        }
    }
}
