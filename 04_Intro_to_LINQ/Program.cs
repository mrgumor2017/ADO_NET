using System;
using System.Collections.Generic;
using System.Linq;
using static System.Console;

namespace _04_Intro_to_LINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Zadacha1
            int[] arrayInt = { 5, 34, 67, -12, 94, -42, -102 };

            IEnumerable<int> query = from i in arrayInt
                                     where i > 0
                                     orderby i ascending
                                     select i;
            WriteLine("Even elements ascending:");
            foreach (int item in query)
            {
                Write($"{item}\t");
            }
            WriteLine();

            var result = arrayInt.Where(i => i > 0).OrderBy(i => i);

            WriteLine("Even elements descending:");
            foreach (int item in result)
            {
                Write($"{item}\t");
            }
            WriteLine();

            #endregion
            #region Zadacha2

            IEnumerable<int> query2 = from i in arrayInt
                                      where i > 0 && i / 100 == 0 && i / 10 > 0
                                      select i;
            WriteLine("Even elements ascending:");
            foreach (int item in query2)
            {
                Write($"{item}\t");
            }
            WriteLine();
            double avr1 = query2.Average();
            WriteLine("Avarage:" + avr1);


            var result2 = arrayInt.Where(i => i > 0 && i / 100 == 0 && i / 10 > 0);

            WriteLine("Even elements descending:");
            foreach (int item in result2)
            {
                Write($"{item}\t");
            }
            WriteLine();
            double avr2 = result2.Average();
            WriteLine("Avarage2:" + avr2);
            #endregion
            #region Zadacha3
            int[] arrayYears = { 1725, 1889, 1956, 2034, 1450, 2100, 1991, 1605, 2027, 1803, 2000 };
            IEnumerable<int> query3 = from i in arrayYears
                                      where i % 4 == 0 && i % 100 != 0 || i % 400 == 0
                                      orderby i ascending
                                      select i;
            WriteLine("Even elements ascending:");
            foreach (int item in query3)
            {
                Write($"{item}\t");
            }
            WriteLine();

            var result3 = arrayYears.Where(i => i % 4 == 0 && i % 100 != 0 || i % 400 == 0).OrderBy(i => i);

            WriteLine("Even elements descending:");
            foreach (int item in result3)
            {
                Write($"{item}\t");
            }
            WriteLine();
            #endregion
            #region Zadacha4

            IEnumerable<int> query4 = from i in arrayInt
                                      where i % 2 == 0
                                      select i;
            WriteLine("Even elements ascending:");
            foreach (int item in query4)
            {
                Write($"{item}\t");
            }
            WriteLine();
            double max1 = query4.Max();
            WriteLine("Max:" + max1);


            var result4 = arrayInt.Where(i => i % 2 == 0);

            WriteLine("Even elements descending:");
            foreach (int item in result4)
            {
                Write($"{item}\t");
            }
            WriteLine();
            double max2 = result4.Max();
            WriteLine("Max2:" + max2);

            #endregion
            #region Zadacha5
            List<string> lines = new List<string> { "Apple", "Sky", "River", "Dream", "Mountain", "Freedom", "Knowledge", "Strength", "Ocean", "Happiness" };
            IEnumerable<string> query5 = from i in lines
                                         select i + "!!!";
            WriteLine("Even elements ascending:");
            foreach (string item in query5)
            {
                Write($"{item}  ");
            }
            WriteLine();
            var result5 = lines.Select(i => i + "!!!");
            WriteLine("Even elements descending:");
            foreach (string item in result5)
            {
                Write($"{item}  ");
            }
            WriteLine();
            #endregion
            #region Zadacha6
            char s = 'a';
            IEnumerable<string> query6 = from i in lines
                                         where i.Contains(s)
                                         select i;
            WriteLine("Even elements ascending:");
            foreach (string item in query6)
            {
                Write($"{item}  ");
            }
            WriteLine();
            var result6 = lines.Where(i => i.Contains(s));
            WriteLine("Even elements descending:");
            foreach (string item in result6)
            {
                Write($"{item}  ");
            }
            WriteLine();
            #endregion
            #region Zadacha7
            IEnumerable<IGrouping<int, string>> query7 = from i in lines
                                                         group i by i.Length;
            WriteLine("Forming groups of criteria:");
            foreach (IGrouping<int, string> group in query7)
            {
                Write($"Key: {group.Key}\nValue:");

                foreach (string item in group)
                {
                    Write($"\t{item}");
                }
                WriteLine();
            }

            var result7 = lines.GroupBy(i => i.Length).OrderBy(g => g.Key);
            WriteLine("Forming groups of criteria:");
            foreach (IGrouping<int, string> group in result7)
            {
                Write($"Key: {group.Key}\nValue:");

                foreach (string item in group)
                {
                    Write($"\t{item}");
                }
                WriteLine();
            }
            #endregion
        }

    }
}
