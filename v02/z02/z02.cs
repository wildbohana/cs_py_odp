using System;
using System.Collections.Generic;

namespace z02
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, List<string>> recnik = new Dictionary<int, List<string>>(10);

            recnik.Add(0, new List<string> { "fifi" });
            recnik.Add(1, new List<string> { "slobodan", "slobodic" });
            recnik.Add(2, new List<string> { "filip", "visnjic" });
            recnik.Add(3, new List<string> { "vuk", "stefanovic", "karadzic" });
            recnik.Add(4, new List<string> { "filic" });
            recnik.Add(5, new List<string> { "ilija", "ilic" });
            recnik.Add(6, new List<string> { "marko", "markovic" });
            recnik.Add(7, new List<string> { "slobodan", "slobodic" });
            recnik.Add(8, new List<string> { "stevo", "stevic" });
            recnik.Add(9, new List<string> { "milica", "milic" });

            for (int i = 0; i < 10; i++)
            {
                List<string> str = new List<string>();
				
                if (recnik.TryGetValue(i, out str))
                    for (int j = 0; j < str.Count; j++)
                        Console.WriteLine(i + " - " + j + " - " + str[j]);
            }            
        }
    }
}
