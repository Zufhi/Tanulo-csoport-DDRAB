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