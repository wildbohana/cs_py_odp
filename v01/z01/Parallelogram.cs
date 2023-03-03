using System;
using System.Collections.Generic;
using System.Text;

namespace z01
{
    class Parallelogram
    {
		// Polja
        private int width;
        private int length;
        private int height;

		// Propertiji
        public int Width { get => width; set => width = value; }
        public int Length { get => length; set => length = value; }
        public int Height { get => height; set => height = value; }

		// Konstruktor
        public Parallelogram(int width = 2, int length = 3, int height = 2)
        {
            this.width = width;
            this.length = length;
            this.height = height;
        }

		// Metode
        public double CalculateArea(int a, int h)
        {
            return a * h;
        }

        public double CalculatePerimeter(int a, int b)
        {
            return 2 * (a + b);
        }

        public string ShowInfo()
        {
            string informacije = "";

            informacije += "PARALLELOGRAM\n";
            informacije += "Width:\t" + Width + "\n";
            informacije += "Length:\t" + Length + "\n";
            informacije += "Height:\t" + Height + "\n";
            informacije += "Prm:\t" + CalculatePerimeter(Width, Length) + "\n";
            informacije += "Area:\t" + CalculateArea(Width, Height) + "\n";

            return informacije;
        }
    }
}
