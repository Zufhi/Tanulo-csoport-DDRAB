using Létra;
using System.IO;

StreamReader sr = new StreamReader("letra.txt");
string[] temp = sr.ReadLine().Split(", ");
int[] line = new int[temp.Length];

for (int i = 0; i < line.Length; i++)
{
    line[i] = int.Parse(temp[i]);
}

Dobas D = new Dobas(line);

int jelenlegi = 0;
int vissza_count = 0;
Console.WriteLine("2.feladat");
foreach (var item in D.DobasElemek)
{
    jelenlegi += item;
    if (jelenlegi % 10 == 0)
    {
        jelenlegi -= 3;
        vissza_count++;
    }

    Console.Write($"{jelenlegi} ");
}
Console.WriteLine($"\n3. feladat\nA játék során {vissza_count} alkalommal lépett létrára.");

Console.WriteLine("4.feladat");
if (jelenlegi > 45)
{
    Console.WriteLine("A játékot befejezte.");
}
else
{
    Console.WriteLine("A játékot abbahagyta.");
}

Console.ReadKey();