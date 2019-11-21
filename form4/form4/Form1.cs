using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        public double a, b, dx;
        static int N = 10;
        double[] x = new double[N], y = new double[N];

        private double f(double x)
        {
            return Math.Sin(x);
        }

       

        private void Button1_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            dx = (b - a) / N;
            for (double X = x[0]; X <= x[N - 1]; X += dx)
            {
                double R = 0;
                R = L(X, x, y, N);
                chart1.Series[0].Points.AddXY(X, R);
            }

        }

         private void Button2_Click(object sender, EventArgs e)
        {
            chart1.Series[1].Points.Clear();
            a = Convert.ToDouble(textBox1.Text);
            b = Convert.ToDouble(textBox2.Text);
            if (b < a)
            {
                MessageBox.Show("Помилка!!! Ліва межа не може бути більшою за праву");
                return;
            }
            dx = (b - a) / N;
            
            for (int i = 0; i < N; i++)
            {
                x[i] = a + i * dx;
                y[i] = f(x[i]);
                chart1.Series[1].Points.AddXY(x[i], y[i]);
            }
        }
        

        private double L(double x, double[] x_values, double[] y_values, int size)
        {
            double lagrange_pol = 0;
            double basics_pol;

            for (int i = 0; i < size; i++)
            {
                basics_pol = 1;
                for (int j = 0; j < size; j++)
                {
                    if (j == i)
                    {
                        continue;
                    }
                    basics_pol *= (x - x_values[j]) / (x_values[i] - x_values[j]);
                }
                lagrange_pol += basics_pol * y_values[i];
            }
            return lagrange_pol;
        }
    }
}
