using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1GraficadorSeñales
{
    class Rampa
    {
        public List<Muestra> muestras { get; set; }

        public Rampa()
        {
            muestras = new List<Muestra>();
        }

        public double evaluar(double tiempo)
        {
            double resultado;

            if (tiempo >= 0 )
            {
                resultado = tiempo;
            } 
            else
            {
                resultado = 0;
            }

            return resultado;
        }
    }


}
