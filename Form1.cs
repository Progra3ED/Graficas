using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graficas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<int> xi = new List<int>();
        List<int> yi = new List<int>();

        List<double> xd = new List<double>();
        List<double> yd = new List<double>();

        double funcion1(float x)
        {

            double y = Math.Pow(3 * x, 2) + x;

            return y;

        }

        double funcion2(float x)
        {

            double y = Math.Sin(x);

            return y;

        }

        double funcion3(float x)
        {
            double y = Math.Cos(x);

            return y;

        }

        int funcion4(int x)
        {

            int y = x + 1;

            return y;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int posicion = lbFunciones.SelectedIndex;
            chart1.Series["Series1"].Points.Clear();


            for (float x = 0; x < 100; x++)
            {
                double y = 0;
                switch (posicion)
                {
                    case 0:
                        y = funcion1(x);
                        break;
                    case 1:
                        y = funcion2(x);
                        break;
                    case 2:
                        y = funcion3(x);
                        break;
                    case 3:
                        y = funcion4((int)x);
                        break;
                    default:
                        break;
                }

                chart1.Series["Series1"].Points.AddXY(x, y);

            }
        }


        // para el método dos personalizando el ciclo y tipo de dato para cada tipo de funcion

        void seno(float inicio, float fin, float incremento)
        {            
            for (float x = inicio; x < fin; x+=incremento)
            {
                xd.Add (x);
                yd.Add (Math.Sin(x));                
            }
        }

        void cuadratica(int inicio, int fin, int incremento)
        {           
            for (int x = inicio; x < fin; x+=incremento)
            {
                xi.Add(x);
                yi.Add((int)Math.Pow(3 * x, 2) + x); 
            }            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int posicion = lbFunciones.SelectedIndex;
            chart1.Series["Series1"].Points.Clear();

            xd.Clear();
            yd.Clear();



            switch (posicion)
            {
                case 0:
                    cuadratica(-99, 101, 1);
                    chart1.Series["Series1"].Points.DataBindXY(xi,yi);
                    break;
                case 1:
                    seno(1, 10, 1f);
                    chart1.Series["Series1"].Points.DataBindXY(xd,yd);
                    break;
                default:
                    break;
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //para que la grafica sea una linea suave
            chart1.Series["Series1"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Spline;
        }
    }
}
