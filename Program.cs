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

            if (Msor != null)
            {
                rendelesek t = new rendelesek(Msor[1], int.Parse(Msor[2]), Msor[3], cikkSz, mennySz);
                RendelesekLista.Add(t);
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


            // Rendelések feldolgozása
            List<string> Kiiras = new List<string>();
            bool teljesitheto;
            int osszAr;

            Dictionary<string, int> rendLista = new Dictionary<string, int>();
            Dictionary<string, int> beszerzLista = new Dictionary<string, int>();


            foreach (var Rendelesitem in RendelesekLista)
            {
                osszAr = 0;
                teljesitheto = true;
                rendLista.Clear();

                for (int i = 0; i < Rendelesitem.mennyiseg.Count(); i++) 
                {
                    foreach (var RaktarItem in RaktarLista) 
                    {
                        if (Rendelesitem.cikkSzam[i] == RaktarItem.cikkSzam)
                        {
                            if (Rendelesitem.mennyiseg[i] <= RaktarItem.mennyiseg)
                            {
                                if (!rendLista.ContainsKey(Rendelesitem.cikkSzam[i]))
                                {
                                    rendLista.Add(Rendelesitem.cikkSzam[i], Rendelesitem.mennyiseg[i]);
                                }

                                osszAr += RaktarItem.ar * Rendelesitem.mennyiseg[i];
                            }

                            else 
                            {
                                teljesitheto = false;
                                int hiany = Rendelesitem.mennyiseg[i] - RaktarItem.mennyiseg;
                                if (beszerzLista.ContainsKey(Rendelesitem.cikkSzam[i]))
                                {
                                    beszerzLista[Rendelesitem.cikkSzam[i]] += hiany;
                                }

                                else 
                                {
                                   beszerzLista.Add(Rendelesitem.cikkSzam[i], hiany);
                                }
                            }
                        }
                    }
                }

                if (teljesitheto)
                {
                    Kiiras.Add($"{Rendelesitem.email};A rendelését két napon belül szállítjuk. A rendelés értéke: {osszAr} Ft");

                    foreach (var item in RaktarLista) 
                    {
                        foreach (var dictionaryItem in rendLista) 
                        {
                            if (item.cikkSzam == dictionaryItem.Key) 
                            {
                                item.mennyiseg -= dictionaryItem.Value;
                            }
                        }
                    }
                }

                else 
                {
                    Kiiras.Add($"{Rendelesitem.email};A rendelése függő állapotba került. Hamarosan értesítjük a szállítás időpontjáról.");
                }
            }

            // levelek.csv kiírása
            StreamWriter levelek = new StreamWriter("levelek.csv");
            foreach (var item in Kiiras) 
            {
                levelek.WriteLine(item);
            }
            levelek.Close();


            // beszerzes.csv kiírása
            StreamWriter beszerzes = new StreamWriter("beszerzes.csv");
            foreach (var item in beszerzLista)
            {
                beszerzes.WriteLine($"{item.Key};{item.Value}");
            }

            beszerzes.Close();
        }
    }
}