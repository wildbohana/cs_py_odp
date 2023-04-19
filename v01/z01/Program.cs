using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Predefinisano
            Rectangle kvadrat1 = new Rectangle();
            Parallelogram prl1 = new Parallelogram();

            kvadrat1.ShowInfo();
            prl1.ShowInfo();

            // Proizvoljno
            Rectangle kvadrat2 = new Rectangle(4);
            Parallelogram prl2 = new Parallelogram(3, 5, 8);

            kvadrat2.ShowInfo();
            prl2.ShowInfo();

            // Broj instanci
            Console.WriteLine("Number of rectangle instances: " + Rectangle.ClassCount());
            Console.ReadKey();
        }
    }
}
