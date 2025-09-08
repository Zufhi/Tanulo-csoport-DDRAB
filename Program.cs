using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.InteropServices;
using System.CodeDom.Compiler;

namespace konyvek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<konyvek> list = new List<konyvek>();
            foreach (var s in File.ReadLines("kiadas.txt"))
            {
                konyvek sor = new konyvek(s);
                list.Add(sor);
            }
            //2. feladat
            Console.Write("2. feladat:\nSzerző: ");
            string Szerző = Console.ReadLine();
            int db = 0;
            foreach (var item in list)
            {
                if (item.Leiras.Contains(Szerző))
                {
                    db++;
                }
            }
            if (db == 0)
            {
                Console.WriteLine("Nem adtak ki");
            }
            else
            {
                Console.WriteLine($"{db} könyvkiadás");
            }
            //3. feladat
            db = 0;
            Console.Write("3. feladat:\nLegnagyobb példányszám: ");
            int m_db = 0;
            foreach (var item in list)
            {
                if (db < item.Peldany)
                {
                    db = item.Peldany;
                }
            }
            foreach (var item in list)
            {
                if (db == item.Peldany)
                {
                    m_db++;
                }
            }
            Console.WriteLine($"{db}, előfordult {m_db} alkalommal");
            //4. feladat
            Console.WriteLine("4. feladat:");
            foreach (var item in list)
            {
                if (item.Eredete == "kf" && item.Peldany >= 40000)
                {
                    Console.WriteLine($"{item.Ev}/{item.NE}. {item.Leiras}");
                    break;
                }
            }
            //5. feladat
            Console.WriteLine("5. feladat:");
            StreamWriter html = new StreamWriter("tabla.html");
            html.WriteLine("<table>\r\n<tr><th>Év</th><th>Magyar kiadás</th><th>Magyar példányszám</th><th>Külföldi\r\nkiadás</th><th>Külföldi példányszám</th></tr>");
            Console.WriteLine("Év\tMagyar kiadás\tMagyar példányszám\tKülföldi kiadás\tKülföldi példányszám");
            List<int> ints = new List<int>();
            int eev = 0;
            foreach (var item in list)
            {
                int ev = 0;
                int mk = 0;
                int mp = 0;
                int kk = 0;
                int kp = 0;
                foreach (var s in list)
                {
                    if (!ints.Contains(item.Ev))
                    {
                        eev = s.Ev;
                        ev = item.Ev;
                        
                        if (s.Ev == item.Ev)
                        {
                            if (s.Eredete == "ma")
                            {
                                mk++;
                                mp += s.Peldany;
                            }
                            else
                            {
                                kk++;
                                kp += s.Peldany;
                            }
                        }
                    }
                    else
                    {
                        

                        break;
                    }


                }
                ints.Add(ev);
                if (ev != 0) {
                    Console.WriteLine($"{ev}\t\t{mk}\t\t{mp}\t\t{kk}\t\t{kp}");
                    html.WriteLine($"<tr><td>{ev}</td><td>{mk}</td><td>{mp}</td><td>{kk}</td><td>{kp}</td></tr>");
                }
            }
            html.WriteLine("</table>");
            html.Close();

            //6. feladat
            Console.WriteLine("6. feladat:\nLegalább kétszer, nagyobb példányszámban újra kiadott könyvek:");
            foreach (var item in list)
            {
                int kiadas = 0;
                string nev = item.Leiras;
                int peldanyszam = item.Peldany;
                foreach (var s in list)
                {
                    if (nev == s.Leiras)
                    {
                        kiadas++;
                        if ()
                        {

                        }
                    }
                }
            }
        }
    }
}
