using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1GraficadorSeñales
{
    class Muestra
    {
        //El sintante del tiempo en que fue tomada la muestra
        public double x { get; set; }

        //El valor de esa muestra en ese instante
        public double y { get; set; }

        public Muestra(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

    }
}
