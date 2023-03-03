using System;

namespace z01
{
    class Program
    {
        static void Main(string[] args)
        {
            // Predefinisano
            Rectangle kvadrat1 = new Rectangle();
            Parallelogram prl1 = new Parallelogram();

            Console.WriteLine(kvadrat1.ShowInfo());
            Console.WriteLine(prl1.ShowInfo());

            // Proizvoljno
            Rectangle kvadrat2 = new Rectangle(4);
            Parallelogram prl2 = new Parallelogram(3, 5, 8);

            Console.WriteLine(kvadrat2.ShowInfo());
            Console.WriteLine(prl2.ShowInfo());

            // Broj instanci
            Console.WriteLine("Number of rectangle instances: " + Rectangle.numOfInstancesR);
        }
    }
}
