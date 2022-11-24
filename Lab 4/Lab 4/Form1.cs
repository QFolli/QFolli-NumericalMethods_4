using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Lab_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Solving.Func func = Solving.Function;
            double x1, x2, h;
            int count = 0 , n, k = 1;
            x1 = 1; //Convert.ToDouble(textBoxX1.Text);
            x2 = 16; //Convert.ToDouble(textBoxX2.Text);
            h = 2.5; //Convert.ToDouble(textBoxH.Text);
            n = (int)((x2 - x1) / h) + 1;
            double[] X = new double[n];
            double[] Y = new double[n];

            chart1.Series.Clear();
            chart1.Series.Add("График 1");
            chart1.Series[0].ChartType = SeriesChartType.Line;
            for (double i = x1; i <= x2; i += h, count++)
            {
                chart1.Series[0].Points.AddXY(i, func(i));
                X[count] = i;
                Y[count] = func(i);
            }

            double[,] mas = new double[count - 1, count - 1];
            for (int i = 0; i < count - 1; i++)
            {
                for (int j = 0; j < count - k; j++)
                {
                    if (i == 0)
                        mas[j, i] = Y[j + 1] - Y[j];
                    else
                        mas[j, i] = mas[j + 1, i - 1] - mas[j, i - 1];
                }
                k++;
            }

            chart1.Series.Add("График 2");
            chart1.Series[1].ChartType = SeriesChartType.Line;
            for (double i = x1; i < x2; i += h)
            {
                chart1.Series[1].Points.AddXY(i, Solving.Newton(h, i, X, Y, mas));
            }
        }
    }
}
