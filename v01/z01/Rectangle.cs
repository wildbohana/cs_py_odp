using System;
using System.Collections.Generic;
using System.Text;

namespace z01
{
    class Rectangle : IQuadrilateral
    {
        public static int numOfInstancesR = 0;

		// Polja
        private int width;
        private int length;

		// Propertiji
        public int Width { get => width; set => width = value; }
        public int Length { get => length; set => length = value; }

		// Konstruktor
        public Rectangle(int value = 5)
        {
            this.width = value;
            this.length = value;

            numOfInstancesR++;
        }

		// Metode
        public double CalculateArea(int a, int b)
        {
            return a * a;
        }

        public double CalculatePerimeter(int a, int b)
        {
            return 4 * a;
        }

        public string ShowInfo()
        {
            string informacije = "";

            informacije += "RECTANGLE\n";
            informacije += "Width:\t" + Width + "\n";
            informacije += "Length:\t" + Length + "\n";
            informacije += "Prm:\t" + CalculatePerimeter(Width, Length) + "\n";
            informacije += "Area:\t" + CalculateArea(Width, Length) + "\n";

            return informacije;
        }
    }
}
