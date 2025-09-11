using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

class ImageMatrix
{
    public string[,] matrix;

    public ImageMatrix()
    {
        matrix = new string[360, 640];

        List<string> temp = new List<string>();
        using (StreamReader sr = new StreamReader("kep.txt"))
        {
            string sor;
            while ((sor = sr.ReadLine()) != null)
            {
                foreach (string bit in sor.Split(' '))
                {
                    temp.Add(bit);
                }
            }
        }

        int index = 0;
        for (int i = 0; i < 360; i++)
        {
            for (int j = 0; j < 640; j++)
            {
                matrix[i, j] = $"{temp[index]} {temp[index + 1]} {temp[index + 2]}";
                index += 3;
            }
        }
    }
    public string Pixel(int row, int col)
    {
        return matrix[row, col].Replace(" ", ", ");
    }
    public int Bright()
    {
        int db = 0;
        int sorok = matrix.GetLength(0);
        int oszlopok = matrix.GetLength(1);
        for (int i = 0; i < sorok; i++)
        {
            for (int j = 0; j < oszlopok; j++)
            {
                string[] temp = matrix[i, j].Split(' ');
                if (int.Parse(temp[0]) + int.Parse(temp[1]) + int.Parse(temp[2]) > 600)
                {
                    db++;
                }
            }
        }
        return db;
    }
    public string Dark()
    {
        string[] temp = matrix[0, 0].Split(' ');
        int min= int.Parse(temp[0]) + int.Parse(temp[1]) + int.Parse(temp[2]);
        int sorok = matrix.GetLength(0);
        int oszlopok = matrix.GetLength(1);
        for (int i = 0; i < sorok; i++)
        {
            for (int j = 0; j < oszlopok; j++)
            {
                string[] temp2 = matrix[i, j].Split(' ');
                if (int.Parse(temp2[0]) + int.Parse(temp2[1]) + int.Parse(temp2[2]) < min)
                {
                    min = int.Parse(temp2[0]) + int.Parse(temp2[1]) + int.Parse(temp2[2]);
                }
            }
        }
        string rgbk="";
        for (int i = 0; i < sorok; i++)
        {
            for (int j = 0; j < oszlopok; j++)
            {
                string[] temp2 = matrix[i, j].Split(' ');
                if (int.Parse(temp2[0]) + int.Parse(temp2[1]) + int.Parse(temp2[2]) == min)
                {
                    rgbk += matrix[i, j]+" ";
                }
            }
        }
        return rgbk;
    }
    public string hatar(int value)
    {
        int sorok = matrix.GetLength(0);
        int oszlopok = matrix.GetLength(1);
        string ertekek = "";
        for (int i = 0; i < sorok; i++)
        {
            for (int j = 1; j < oszlopok; j++)
            {
                string[] temp = matrix[i, j].Split(' ');
                string[] temp2 = matrix[i, j-1].Split(' ');
                int egy =int.Parse(temp[2]);
                int ketto =int.Parse(temp2[2]);
                if (egy-ketto > value)
                {
                    ertekek += $"{i+1},";
                }
            }
        }
        return ertekek;
    }
}
