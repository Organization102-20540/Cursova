using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double a,a1, b1,  b, N, S, S1, p;
        

        private double f(double x)
        {
            return Math.Sin(x);
        }


        private double rectangle()
        {
            double dx = (b - a) / N;
            double S = 0;
            double x = a + dx;

            while (x < b)
            {
                S = S + dx * Math.Abs(f(x));
                x = x + dx;

            }

            return S;
        }

        private double trap()
        {
            double dx = (b - a) / N;
            double h = 0;
            double x1 = a;

            S = 0;

            while (x1 < b)
            {
                h = (Math.Abs(f(x1)) + Math.Abs(f(x1 + dx))) / 2;
                S = S + dx * h;
                x1 = x1 + dx;

            }

            
            return S;
        }

       

        

       

       

        


        private void Button2_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();
        }

        

        private void Button1_Click_1(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            b = Convert.ToDouble(textBox2.Text);
            if (b < a)
            {
                MessageBox.Show("Помилка!!! Верхня межа не може бути більшою за нижню");
                return;
            }
            
            
            {
                double p = Math.Truncate(( b-a) / Math.PI);
                a1 =a- Math.PI*Math.Truncate(a / Math.PI);
                b1 =b- Math.PI*Math.Truncate(b / Math.PI);
                S1 =Math.Abs(Math.Cos(b1) - Math.Cos(a1)) +2*p;
                label17.Text = S1.ToString();
                label22.Text = S1.ToString();
                label27.Text = S1.ToString();
                label32.Text = S1.ToString();
                label37.Text = S1.ToString();
            }
            N = 10;
            if (N == 10)
            {
                double Res = rectangle();
                label18.Text = Res.ToString();
                Res = trap();
                label19.Text = Res.ToString();
                Res = Monte_Carlo();
                label20.Text = Res.ToString();
                Res = Simpson();
                label21.Text = Res.ToString();
                N = 20;
            }

            if (N == 20)
            {
                double Res = rectangle();
                label23.Text = Res.ToString();
                Res = trap();
                label24.Text = Res.ToString();
                Res = Monte_Carlo();
                label25.Text = Res.ToString();
                Res = Simpson();
                label26.Text = Res.ToString();
                N = 50;
            }

            if (N == 50)
            {
                double Res = rectangle();
                label28.Text = Res.ToString();
                Res = trap();
                label29.Text = Res.ToString();
                Res = Monte_Carlo();
                label30.Text = Res.ToString();
                Res = Simpson();
                label31.Text = Res.ToString();
                N = 100;
            }

            if (N == 100)
            {
                double Res = rectangle();
                label33.Text = Res.ToString();
                Res = trap();
                label34.Text = Res.ToString();
                Res = Monte_Carlo();
                label35.Text = Res.ToString();
                Res = Simpson();
                label36.Text = Res.ToString();
                N = 1000;
            }

            if (N == 1000)
            {
                double Res = rectangle();
                label38.Text = Res.ToString();
                Res = trap();
                label39.Text = Res.ToString();
                Res = Monte_Carlo();
                label40.Text = Res.ToString();
                Res = Simpson();
                label41.Text = Res.ToString();
            }
        }

        private double Simpson()
        {
            double dx = (b - a) / N;
            double S = 0;
            double S1 = 0;
            double x = a + dx;

            S1 = (Math.Abs(f(a)) + Math.Abs(f(b))) / 2;

            while (x < b-dx)
            {
                S1 = S1 + Math.Abs(f(x));
                x = x + dx;
               
            }
            S = S1 * dx;
            
            return S;
        }
        private double Monte_Carlo()
        {
            double xx, yy, i, j;
            int a_ = Convert.ToInt32(a) * 1000;
            int b_ = Convert.ToInt32(b) * 1000;
            i = j = 0;

            if (N == 10) for (double k = a; k < b + 0.01; k += 0.01)
                {
                    chart1.Series[0].Points.AddXY(k, f(k));
                }

            Random Rand = new Random();
            for (double n = 0; n <= N; n++)
            {
                xx = Rand.Next(a_, b_);
                xx = xx / 1000;
                yy = Rand.Next(-1000, 1000);
                yy = yy / 1000;

                if (yy > 0)
                {
                    if (yy < f(xx) )
                    {
                        i++;
                        chart1.Series[1].Points.AddXY(xx, yy);
                    }
                    else chart1.Series[2].Points.AddXY(xx, yy);
                }
                else if (yy > f(xx))
                {
                    j++;
                    chart1.Series[1].Points.AddXY(xx, yy);
                }
                else chart1.Series[2].Points.AddXY(xx, yy);
            }

            double S_pol = Math.Abs(2 * (b - a));
            double Ratio_i = Math.Abs(i / N);
            double Ratio_j = Math.Abs(j / N);
            double Res;

            Res=S_pol*(i+j)/(N);
            return Res;
        }


        
    }
}

  