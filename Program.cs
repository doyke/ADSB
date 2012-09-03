using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateFile();

            byte[] bys = new byte[10000000];
            StreamReader sr = new StreamReader("data.txt");
            string temp = sr.ReadLine();

            do
            {
                int index = 0;
                int.TryParse(temp, out index);
                bys[index] = 1;

                temp = sr.ReadLine();
            }
            while (!string.IsNullOrEmpty(temp));

            for (int i = 0; i < bys.Length; i++)
            {
                
            }
        }

        private static void CreateFile()
        {
            FileStream file = File.Open("data.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            StreamWriter sw = new StreamWriter(file);

            int max = 10000000;

            for (int i = max - 2; i > -1; i -= 2)
            {
                sw.WriteLine(i.ToString());
            }

            sw.Close();
            file.Close();
        }
    }
}
