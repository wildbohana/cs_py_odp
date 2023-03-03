using System;
using System.Collections.Generic;
using System.Text;

namespace z01
{
    interface IQuadrilateral
    {
        // Properties
        int Width { get; set; }
        int Length { get; set; }

        // Metode
        double CalculatePerimeter(int a, int b);
        double CalculateArea(int a, int b);
        string ShowInfo();
    }
}
