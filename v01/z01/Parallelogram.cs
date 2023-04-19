using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak1
{
    class Parallelogram : IQuadrilateral
    {
        // Polja
        double width;
        double length;
        double height;

        // Propertiji
        public double Width { get => width; set => width = value; }
        public double Length { get => length; set => length = value; }
        public double Height { get => height; set => height = value; }

        // Konstruktori
        //public Parallelogram() : this(1, 1, 1) {}
        public Parallelogram(double width = 1, double length = 1, double height = 1)
        {
            this.width = width;
            this.length = length;
            this.height = height;
        }

        // Metode
        public double CalculateArea()
        {
            return Width * Height;
        }

        public double CalculatePerimeter()
        {
            return 2 * (Width + Length);
        }

        public void ShowInfo()
        {
            string informacije = "";

            informacije += "PARALLELOGRAM\n";
            informacije += "Width:\t" + Width + "\n";
            informacije += "Length:\t" + Length + "\n";
            informacije += "Height:\t" + Height + "\n";
            informacije += "Prm:\t" + CalculatePerimeter() + "\n";
            informacije += "Area:\t" + CalculateArea() + "\n";

            Console.WriteLine(informacije);
        }
    }
}
