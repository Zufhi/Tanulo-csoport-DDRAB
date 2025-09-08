using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Rendelések
{
    class Program
    {
        static void Main(string[] args) 
        {
            /* Rendeles beolvasas */
            StreamReader rendelesReader = new StreamReader("rendeles.csv");
            List<rendelesek> RendelesekLista = new List<rendelesek>();

            string line;
            string[] Msor = null;
            List<string> cikkSz = null;
            List<int> mennySz = null;

            while ((line = rendelesReader.ReadLine()) != null) 
            {
                string[] temp = line.Split(';');

                if (temp[0] == "M")
                {
                    if (Msor != null)
                    {
                        rendelesek t = new rendelesek(Msor[1], int.Parse(Msor[2]), Msor[3], cikkSz, mennySz);
                        RendelesekLista.Add(t);
                    }

                    Msor = temp;
                    cikkSz = new List<string>();
                    mennySz = new List<int>();
                }


                if (temp[0] == "T") 
                {
                    cikkSz.Add(temp[2]);
                    mennySz.Add(int.Parse(temp[3]));
                }
            }
            rendelesReader.Close();

            /*----------------------------------------------------------------------------------------------------*/


            /* Raktar beolvasas */
            StreamReader raktarReader = new StreamReader("raktar.csv");
            List<raktar> RaktarLista = new List<raktar>();

            while ((line = raktarReader.ReadLine()) != null)
            {
                string[] temp = line.Split(';');

                raktar t = new raktar(temp[0], temp[1], int.Parse(temp[2]), int.Parse(temp[3]));

                RaktarLista.Add(t);
            }
            raktarReader.Close();

            /*----------------------------------------------------------------------------------------------------*/




            foreach (var item in RendelesekLista) 
            {

                Console.WriteLine($"{item.datum} {item.rendelesSzam} {item.email}");
                for (int i = 0; i < (item.mennyiseg.Count); i++)
                {
                    Console.WriteLine($"{item.cikkSzam[i]}\t{item.mennyiseg[i]} db");
                }

                Console.WriteLine("");
            }

            Console.WriteLine();

            foreach (var item in RaktarLista)
            {

                Console.WriteLine($"{item.cikkSzam} {item.nev} {item.ar} Ft {item.mennyiseg} db");
            }
        }
    }
}