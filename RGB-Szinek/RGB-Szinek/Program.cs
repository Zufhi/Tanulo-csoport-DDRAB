using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("2.feladat:");
        Elso();
        Console.WriteLine("3.feladat:");
        Masodik();
        Console.WriteLine("4.feladat:");
        Harmadik();
        Console.WriteLine("6.feladat:");
        Negyedik();

        Console.ReadKey();
    }
    static void Elso()
    {
        ImageMatrix img = new ImageMatrix();

        Console.Write("Sor: ");
        int sor = int.Parse(Console.ReadLine()) - 1;
        Console.Write("Oszlop: ");
        int oszlop = int.Parse(Console.ReadLine()) - 1;

        Console.WriteLine($"A képpont színe RGB({img.Pixel(sor, oszlop)})");
    }
    static void Masodik()
    {
        ImageMatrix img = new ImageMatrix();
        Console.WriteLine($"A világos képpontok száma: {img.Bright()}");
    }
    static void Harmadik()
    {
        ImageMatrix img = new ImageMatrix();
        string[] temp = img.Dark().Split(' ');
        Console.WriteLine($"A legsötétebb pont RGB összege: {Convert.ToInt32(temp[0])+ Convert.ToInt32(temp[1])+ Convert.ToInt32(temp[2])}");
        Console.WriteLine("A legsötétebb pixelek színe:");
        for(int i = 2; i < temp.Length; i += 3)
        {
            Console.WriteLine($"RGB ({temp[i - 2]}, {temp[i - 1]},{temp[i]})");
        }
    }
    static void Negyedik()
    {
        ImageMatrix img = new ImageMatrix();
        string[] elteres = img.hatar(10).Split(',');
        Console.WriteLine($"A felhő legfelső sora: {elteres[0]}");
        Console.WriteLine($"A felhő legalsó sora: {elteres[elteres.Length-2]}");
    }
}
