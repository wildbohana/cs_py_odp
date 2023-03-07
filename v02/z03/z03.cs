using System;
using System.Collections.Generic;

namespace z03
{
    class Program
    {
        static void Main(string[] args)
        {
            List<object> niz = new List<object>(3000000);
            int ukDuz = 0;

            for (int i = 0; i < niz.Capacity - 1; i++)
            {
                if (i % 3 == 0) niz.Add(null);
                else if (i % 3 == 1) niz.Add("string" + i);
                else if (i % 3 == 2) niz.Add(new object());
            }

            for (int i = 0; i < niz.Capacity - 1; i++)
            {
                try
                {
                    string current = niz[i] as string;
                    if (current != null)
                        ukDuz += current.Length;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.WriteLine("Ukupna duzina stringova: " + ukDuz);
        }
    }
}
