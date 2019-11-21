using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form2._0
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
           

            chart1.Series[1].Color = Color.Red;
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            comboBox2.Text = comboBox2.GetItemText("Виберіть метод");
            comboBox1.Text = comboBox1.GetItemText("Виберіть варіант");

        }
        static double[] ee = { 2.5, 3, 7, 2.7, 1, 4 };
        static double[] fl = { 0.1, 0.001, 0.05, 0.2, 0.2, 0.07 };
        static double[] a = { 0.1, 2, 0.2, 0.14, 0.22, 0.05 };
        static double[] d = { 1E-3, 2E-3, 0.5E-3, 2E-3, 0.5E-3, 1.5E-3 };

        private double function(double ee, double fl, double D, double d, double a)
        {
            return ((1.898 * Math.Pow(10, -4) * Math.Sqrt(ee * fl) * (1 + D / d)) / (D *1/ Math.Log(Math.Exp(1) ,D / d)) - a); 
        }


        private void Button1_Click_1(object sender, EventArgs e)
        {
            chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series[0].Points.Clear();
            double D_mn0 = 0;
            double D_mx0 = 0;
            int j = comboBox1.SelectedIndex;
            int n = 100;
            double ii = 0;
            if (j == -1)
            {
                MessageBox.Show("Виберіть спочатку варіант");
            }
            else
            {

                
                double D_min = 1 * d[j];
                double D_max = 100000 * d[j];
                 
                
                double f = function(ii, a[j], d[j], fl[j], ee[j]);
                for (ii = D_max; ii > D_max*1.1; )
                {
                    if (f > 0)
                    {
                        D_max=ii*10;
                    }
                    else
                    {
                        D_max = D_max * 1.2;
                    }
                }
                double D_dx = (D_max - D_min) / n;



                for (double i = D_min; i < D_max; i += D_dx)
                {

                    f = function(i, a[j], d[j], fl[j], ee[j]);

                    switch (j)
                    {

                        case 0: f = function(i, a[j], d[j], fl[j], ee[j]); break;
                        case 1: f = function(i, ee[j], a[j], d[j], fl[j]); break;
                        case 2: f = function(i, ee[j], a[j], d[j], fl[j]); break;
                        case 3: f = function(i, ee[j], a[j], d[j], fl[j]); break;
                        case 4: f = function(i, ee[j], a[j], d[j], fl[j]); break;
                        case 5: f = function(i, ee[j], a[j], d[j], fl[j]); break;

                    }
                    

                    chart1.Series[0].Points.AddXY(i, f);
                }

                switch (comboBox2.SelectedIndex)
                {
                    case 0: iteration(); break;
                    case 1: dihoto(); break;

                }
            }

        }
        private void iteration()
        {
            chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
            chart1.Series[1].Points.Clear();
            int j = comboBox1.SelectedIndex;
            int n = 10000;


            double D_min = 1 * d[j];
            double D_max = 100000 * d[j];
            double ii = 0;
            double f = 0;


            for (ii = D_max; ii > D_max * 1.1;)
            {
                if (f > 0)
                {
                    D_max = ii * 10;
                }
                else
                {
                    D_max = D_max * 1.2;
                }
            }


            double D_dx = (D_max - D_min) / n;
            
            
            double f_ = f;
            double Dmin = 0;
            double fmin = 0;

            f_ = function(D_min, ee[j], a[j], d[j], fl[j]);

            while (D_min < D_max)
            {
                f = function(D_min, ee[j], a[j], d[j], fl[j]);
               
                if (Math.Abs (f) < Math.Abs(f_) )
                {
                    fmin = f;
                    Dmin = D_min;
                    
                }
                
                
                f_ = f;
                D_min += D_dx;
            }

            D_min = Dmin;
            f = fmin;

            chart1.Series[1].Points.AddXY(D_min, f);
            label2.Text = D_min.ToString()+" m";




        }
        private void dihoto()
        {


            chart1.Series[1].Points.Clear();
            int j = comboBox1.SelectedIndex;
            int n = 10000;

            
           
            
                    
            double f_ = 0;
            double D_min = 1 * d[j];
            double D_max = 100000 * d[j];
            double ii = 0;
            double f = 0;


            for (ii = D_max; ii > D_max * 1.1;)
            {
                if (f > 0)
                {
                    D_max = ii * 10;
                }
                else
                {
                    D_max = D_max * 1.2;
                }
            }
            double D_dx = (D_max - D_min) / n;
            double eps = 0.00001;


            while (Math.Abs(D_min - D_max) > eps)
            {
                f = function((D_min + D_max) / 2, ee[j], a[j], d[j], fl[j]);
                f_ = function(D_min, ee[j], a[j], d[j], fl[j]);
                if (f_ * f < 0)
                {
                    D_max = (D_min + D_max) / 2;

                }
                else
                 {
                    if ((f_ < f) & (f_<0) & (f<0))
                    {
                        D_min = (D_min + D_max) / 2;
                    }
                    else
                    {
                        
                        D_max = (D_min + D_max) / 2;
                    }
                 }

                
            }


            
            label2.Text = (D_min ).ToString()+"m";
           

            chart1.Series[1].Points.AddXY(D_min , f);

        }

       
    }
}


       

        

       
       
    


