using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadatak1
{
    interface IQuadrilateral
    {
        // Propertiji
        double Width { get; set; }
        double Length { get; set; }

        // Metode
        double CalculatePerimeter();
        double CalculateArea();
        void ShowInfo();
    }
}
