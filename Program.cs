using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading;
using static System.Console;

namespace SD_31_Watch_n_Write
{
    class Program
    {
        static void Main(string[] args)
        {
            int nbOfSeries;

            do
            {
                Clear();
                WriteLine("How many times you wish to read n write series of numbers. Of which first is just a \"1\"?");
                int.TryParse(ReadLine(), out int _out);
                nbOfSeries = _out;

            } while (nbOfSeries <= 0);

            Clear();
            Stack<int> series = new Stack<int>();
            series.Push(1);

            for (int i = 0; i < nbOfSeries; i++)
            {
                WriteLine(string.Concat("\tserie:", (i + 1)));
                Stack<int> _temp = new Stack<int>(series);
                series = Read(_temp);
                Write(series);
            }

            Console.WriteLine("\n\t\ttheEnd ===============================");
        }


        private static void Write(Stack<int> series)
        {
            series.Reverse().ToList().ForEach(x => Console.Write(x)); WriteLine();
        }


        private static Stack<int> Read(Stack<int> series)
        {
            Stack<int> ret = new Stack<int>();
            int counter = 1;
            while (series.Count != 1)
            {
                var current = series.Pop();
                if (current == (series.Peek()))
                {
                    counter++;
                }
                else
                {
                    ret.Push(counter);
                    counter = 1;
                    ret.Push(current);
                }
            }
            ret.Push(counter);
            ret.Push(series.Pop());

            return ret;
        }


    } // end of class
} // end of namespace
