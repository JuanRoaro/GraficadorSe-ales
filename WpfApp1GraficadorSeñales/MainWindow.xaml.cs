﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1GraficadorSeñales
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

        }

        private void Graficar_Click(object sender, RoutedEventArgs e)
        {
            double amplitud = double.Parse(txtAmplitud.Text);
            double tiempoInicial = double.Parse(txtTiempoInicial.Text);
            double fase = double.Parse(txtFase.Text);
            double tiempoFinal = double.Parse(txtTiempoFinal.Text);
            double frecuencia = double.Parse(txtFrecuencia.Text);
            double frecuenciaMuestreo = double.Parse(txtFrecuenciaMuestreo.Text);

            SeñalSenoidal señal = new SeñalSenoidal(amplitud, fase, frecuencia);

            double periodoMuestreo = 1 / frecuenciaMuestreo;

            plnGrafica.Points.Clear();

            for(double i = tiempoInicial; i <= tiempoFinal; i += periodoMuestreo )
            {
                double valorMuestra = señal.evaluar(i);

                if(Math.Abs (valorMuestra) > señal.AmplitudMaxima)
                {
                    señal.AmplitudMaxima = Math.Abs(valorMuestra);
                }

                señal.muestras.Add(new Muestra(i, valorMuestra));
                
            }

            //Recorrer una coleccion o arreglo

            foreach (Muestra muestra in señal.muestras)
            {
                plnGrafica.Points.Add(new Point(muestra.x * scrContenedor.Width, (muestra.y / señal.AmplitudMaxima * (((scrContenedor.Height / 2.0) - 30) * -1) + scrContenedor.Height / 2)));
            }

            lblAmplitudMaximaNegativaY.Text = señal.AmplitudMaxima.ToString();
            lblAmplitudMaximaNegativaY.Text = "-" + señal.AmplitudMaxima - ToString();

        }

        private void GraficarRampa_Click(object sender, RoutedEventArgs e)
        {
            
            double tiempoInicial = double.Parse(txtTiempoInicial.Text);
            
            double tiempoFinal = double.Parse(txtTiempoFinal.Text);
            double frecuenciaMuestreo = double.Parse(txtFrecuenciaMuestreo.Text);

            Rampa señal = new Rampa();

            double periodoMuestreo = 1 / frecuenciaMuestreo;

            plnGrafica.Points.Clear();

            for (double i = tiempoInicial; i <= tiempoFinal; i += periodoMuestreo)
            {
                double valorMuestra = señal.evaluar(i);

                señal.muestras.Add(new Muestra(i, valorMuestra));

            }

            //Recorrer una coleccion o arreglo

            foreach (Muestra muestra in señal.muestras)
            {
                plnGrafica.Points.Add(new Point(muestra.x * scrContenedor.Width, (muestra.y * (((scrContenedor.Height / 2.0) -30 )* -1)  + scrContenedor.Height / 2)));
            }
        }
    }
}
