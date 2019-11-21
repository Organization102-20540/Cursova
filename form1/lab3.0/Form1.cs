using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab3._0
{
    public partial class Form1 :Form

    {
        public Form1()
        {
            InitializeComponent();
        }
        double x, Xmax;
        double E = 1e-4;
        private double f(double x)
        {
            return (Math.Pow(x,2) - Math.Pow(E,2) - 2);
        }


        double dF(double x) //возвращает значение производной
        {
            return 1 + 1 / x;
        }
        double d2F(double x) // значение второй производной
        {
            return -(1 / (x * x));
        }

        private void Iteration(double x, double Xmax)
        {
            double a, b, y1, y2;
            a = x;
            b = Xmax;

            for (; a < b; a += E)
            {
                y1 = f(a);
                y2 = f(a + E);
                if (y1 * y2 < 0)
                {
                    chart1.Series[1].Points.AddXY((2 * a + E) / 2, (y1 + y2) / 2);
                }
            }

        }
         private void Dyhotomia(double x, double Xmax)
        {
            double a = x;
            double b = Xmax;
            double U;
            while (Math.Abs(a - b) >= E)
            {
                double U_a = f(a);
                U = f((a + b) / 2);
                if (U_a * U > 0)
                {
                    a = (a + b) / 2;
                }
                else
                {
                    b = (a + b) / 2;
                }
            }
            double X = (a + b) / 2;
            chart1.Series[1].Points.AddXY(X, f(X));

        }

        private void Newton(double x, double Xmax)
        {
            double x0, xn;
            double a, b;
            xn = 1;

            a = x; b = Xmax;
            if (f(a) * d2F(a) > 0) x0 = a;
            else x0 = b;
            xn = x0 - f(x0) / dF(x0);

            while (Math.Abs(x0 - xn) > E)
            {
                x0 = xn;
                xn = x0 - f(x0) / dF(x0);
            }

            chart1.Series[1].Points.AddXY(xn, f(xn));
        }

       

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                x = Convert.ToDouble(textBox1.Text);
                

                Xmax = Convert.ToDouble(textBox2.Text);
               
                if (x > Xmax)
                {
                    MessageBox.Show("Помилка!!! Дані введені не коректоно. Мінімальне значення не можебути більшим за максимальне");
                    return;
                }
            }
            catch
            {
                textBox1.Focus();
            }


            double Xm = Xmax;

            chart1.Series[0].Points.Clear();

            for (double Xi = x; Xi < Xm + 1e-1; Xi += 1e-1)
            {
                chart1.Series[0].Points.AddXY(Xi, f(Xi));

            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            chart1.Series[1].Points.Clear();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0: Iteration(x, Xmax); break;
                case 1: Dyhotomia(x, Xmax); break;
                case 2: Newton(x, Xmax); break;
            }
        }

        


    }
}
