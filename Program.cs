using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Linq;

namespace emeltinfo2005
{
    class Program
    {
        static void Main(string[] args)
        {
            #region "1. Feladat"
            Console.WriteLine("Kérem az 52. heti lottószámokat!");
            int[] missingnumbers = Array.ConvertAll(Console.ReadLine().Split(' '), Convert.ToInt32);
            #endregion

            #region "2. Feladat"
            Array.Sort(missingnumbers);

            Console.WriteLine("Az adatok sorba rendezve:");
            foreach (int number in missingnumbers)
            {
                Console.WriteLine(number.ToString() + " ");
            }
            #endregion

            #region "3. Feladat"
            Console.WriteLine("Kérnék egy egész számot 1-51 között!");
            int linenumber = int.Parse(Console.ReadLine());
            #endregion

            #region "4. Feladat"
            List<int> lotterynumbers = new List<int>();

            foreach (string line in File.ReadAllLines("dat/lottosz.dat"))
            {
                string[] numbersbuffer = line.Split(' ');

                for (int i = 0; i < numbersbuffer.Length; i++)
                {
                    lotterynumbers.Add(int.Parse(numbersbuffer[i]));
                }
            }

            string[] d = File.ReadAllLines("dat/lottosz.dat");
            Console.WriteLine("A(z) " + linenumber.ToString() + ". soron lévő számok a következők: " + d[linenumber - 1]);

            //vagy picit elegánsabban, ám ugyanazzal a végeredménnyel.
            //List<int> lotterynumbersatline = new List<int>();
            //lotterynumbersatline = lotterynumbers.GetRange(linenumber * 5 - 5, 5);
            #endregion

            #region "5. Feladat"
            Console.WriteLine("Van olyan szám, amelyet nem húztak ki az elmúlt 52 héten?");

            List<int> numbersto90 = new List<int>(Enumerable.Range(0, 90));
            List<int> difference = numbersto90.Except(lotterynumbers).ToList();

            if (difference.Count != 0)
            {
                Console.WriteLine("Igen, van!");
            }
            else
            {
                Console.WriteLine("Nem, nincs!");
            }
            #endregion

            #region "6. Feladat"
            List<int> divisiblewithtwo = lotterynumbers.Where(number => number % 2 == 0).ToList();
            Console.WriteLine(lotterynumbers.Count - divisiblewithtwo.Count + " darab páratlan szám van!");
            #endregion

            #region "7. Feladat"
            if (!File.Exists("dat/lotto52.ki"))
	        {
                File.Copy("dat/lottosz.dat", "dat/lotto52.ki");
	        }

            string newline = string.Join(" ", missingnumbers);
            File.AppendAllText("dat/lotto52.ki", Environment.NewLine + newline);
            #endregion

            #region "8. Feladat"
            Console.WriteLine("Egy számokat ennyiszer húzták ki:");
            List<int> freq = new List<int>();

            for (int i = 1; i <= 90; i++)
            {
                freq.Add(lotterynumbers.FindAll(number => number == i).Count);
            }

            int count = 0;
            foreach (var item in freq)
            {
                Console.Write(item.ToString() + " ");
                count++;

                if (count == 15)
                {
                    Console.WriteLine();
                    count = 0;
                }
            }
            #endregion

            #region "9. Feladat"
            List<int> primenumbers = new List<int>() 
            {
                2, 3, 5, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61, 67, 71, 73, 79, 83, 89
            };

            Console.WriteLine("A következő prímszámokat nem húzták ki:");

            foreach (var item in primenumbers)
            {
                bool x = lotterynumbers.Exists(number => number == item);
                if (x == false)
                {
                    Console.WriteLine(item.ToString());
                }
            }
            #endregion

            Console.ReadLine();
        }
    }
}
