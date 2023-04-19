using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak1
{
    class Rectangle : IQuadrilateral
    {
        // Broj isntanci
        static int cnt = 0;

        // Polja
        double width;
        double length;

        // Propertiji
        public double Width { get => width; set => width = value; }
        public double Length { get => length; set => length = value; }

        // Static metode za static polja!
        public static int ClassCount()
        {
            return cnt;
        }

        // Konstruktori
        //public Rectangle() : this(1, 1) {}
        public Rectangle(double width = 1, double length = 1)
        {
            this.width = width;
            this.length = length;
            cnt++;
        }

        // Metode
        public double CalculateArea()
        {
            return Width * Length;
        }

        public double CalculatePerimeter()
        {
            return 2 * (Width + Length);
        }

        public void ShowInfo()
        {
            string informacije = "";

            informacije += "RECTANGLE\n";
            informacije += "Width:\t" + Width + "\n";
            informacije += "Length:\t" + Length + "\n";
            informacije += "Prm:\t" + CalculatePerimeter() + "\n";
            informacije += "Area:\t" + CalculateArea() + "\n";

            Console.WriteLine(informacije);
        }
    }
}
