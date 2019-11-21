using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        double α, d, D, ε, f, E, d1, d2;

       

        private void textBox33_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == '-')
            {
                MessageBox.Show("Помилка!!! Параметр довжина не може бути від'ємнимною ");
            }

            if ((ch >= '0') && (ch <= '9'))
            {
                return;
            }

            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            if (e.KeyChar == ',')
            {
                if (textBox2.Text.IndexOf(',') != -1)
                {
                    e.Handled = true;
                }
                return;
            }
            e.Handled = true;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            ε = Convert.ToDouble(textBox22.Text);
            f = Convert.ToDouble(textBox24.Text);
            α = Convert.ToDouble(textBox27.Text);
            d = Convert.ToDouble(textBox23.Text);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ε = Convert.ToDouble(textBox4.Text);
            f = Convert.ToDouble(textBox2.Text);
            α = Convert.ToDouble(textBox26.Text);
            d = Convert.ToDouble(textBox3.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox32_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (ch == '-')
            {
                MessageBox.Show("Помилка!!! Параметр довжина не може бути від'ємнимною ");
            }

            if ((ch >= '0') && (ch <= '9'))
            {
                return;
            }

            if (e.KeyChar == '.')
            {
                e.KeyChar = ',';
            }

            if (e.KeyChar == ',')
            {
                if (textBox2.Text.IndexOf(',') != -1)
                {
                    e.Handled = true;
                }
                return;
            }
            e.Handled = true;
        }

        

       

        private void Button8_Click(object sender, EventArgs e)
        {
            chart1.Series[0].Points.Clear();
            chart1.Series[1].Points.Clear();
            chart1.Series[2].Points.Clear();

            label3.Text = "";
            label8.Text = "";

        }

        

     

       

        private double fun (double b)
        {
            return (1.898*Math.Pow(10,-4)*Math.Sqrt(ε*f)*(1+D/d))/(D*Math.Log(D/d))- α;
        }

        private void Iteration(double x, double Xmax)
        {
            double a_, b_, y1, y2;
            a_ = x;
            b_ = Xmax;
            E = 1e-4;
            for (; a_ < b_; )
            {
                y1 = fun(a_);
                y2 = fun(a_ + E);
                if (y1 * y2 < 0)
                {
                    chart1.Series[1].Points.AddXY((2 * a_ + E) / 2, (y1 + y2) / 2);
                    label3.Text = Convert.ToString(Math.Round(a_, 4)) + " м";
                }
                a_ += E;
                    }
            

        }

        private void Dyhotomia(double x, double Xmax)
        {
            double a = x;
            double b = Xmax;
            double U;
            while (Math.Abs(a - b) >= E)
            {
                double U_a = fun(a);
                U = fun((a + b) / 2);
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
            chart1.Series[2].Points.AddXY(X, fun(X));
            label8.Text = Convert.ToString(Math.Round(a, 4)) + " м";
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            d1 = Convert.ToDouble(textBox32.Text);
            d2 = Convert.ToDouble(textBox33.Text);

            if ((d1 == 0) || (d2 == 0))
            {
                MessageBox.Show("Увага!!! Параметр довжина не може бути нулем ");
                return;
            }

            if (d2 > d1)
            {
                MessageBox.Show("Помилка!!! Дані введені не коректоно. Глибина не можебути більшою за довжину");
                return;
            }

            for (D = 0.01; D < 50 + 0.01; D += 0.01)
            {
                chart1.Series[0].Points.AddXY(D, fun(D));
            }
            Iteration(0.01, 20);
            Dyhotomia(-2, 5);
        }
       

      

    }
}


