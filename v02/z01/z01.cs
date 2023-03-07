using System;
using System.Collections.Generic;

namespace z01
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> test123 = new List<int>(154357);
            int zbir = 0;

            for (int i = 0; i < test123.Capacity - 1; i++)
            {
                if (i % 4 == 0) test123.Add(i);
                else test123.Add(-i);
            }

            for (int i = 0; i < test123.Count; i++)
                if (i % 17 == 0) zbir += test123[i];

            /*
            for (int i = 0; i < test123.Count; i++)
                Console.WriteLine(test123[i]);
            */

            Console.WriteLine("Zbir deljivih sa 17: " + zbir);
            Console.WriteLine(test123.Count);
        }
    }
}
