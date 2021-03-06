﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1GraficadorSeñales
{
    class SeñalSenoidal
    {
        public double Amplitud { get; set; }
        public double Fase { get; set; }
        public double Frecuencia { get; set; }

        public List<Muestra> muestras { get; set; }
        public double AmplitudMaxima { get; set; }

        public SeñalSenoidal()
        {
            Amplitud = 1.0;
            Fase = 0.0;
            Frecuencia = 1.0;
            muestras = new List<Muestra>();
            AmplitudMaxima = 0;
        }

        public SeñalSenoidal(double amplitud, double fase, double frecuencia)
        {
            Amplitud = amplitud;
            Fase = fase;
            Frecuencia = frecuencia;
            AmplitudMaxima = 0;
            muestras = new List<Muestra>();
        }

        public double evaluar(double tiempo)
        {
            double resultado;
            resultado = Amplitud * Math.Sin(((2 * Math.PI * Frecuencia) * tiempo) + Fase);
            return resultado;
        }

        
    }
}
