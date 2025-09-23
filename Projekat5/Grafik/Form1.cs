using SHES;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace Grafik
{
    public partial class Form1 : Form
    {
        public List<Podaci> podacis = new List<Podaci>();

        public Form1(string[] args)
        {
            InitializeComponent();
            LoadFile(args[0]);
            ChartLoad();
        }

        public void LoadFile(string file)
        {
            podacis = ReadFromXmlFile<List<Podaci>>(file);
        }
        void ChartLoad()
        {
            var chart = chart1.ChartAreas[0];

            chart.AxisX.IntervalType = System.Windows.Forms.DataVisualization.Charting.DateTimeIntervalType.Number;
            chart.AxisX.LabelStyle.Format = "";
            chart.AxisY.LabelStyle.Format = "";

            chart.AxisX.LabelStyle.IsEndLabelVisible = true;
            chart.AxisX.Minimum = 0;
            chart.AxisY.Minimum = 0;
            chart.AxisY.Maximum = 24;

            chart.AxisX.Interval = 1;
            chart.AxisY.Interval = 10;

            chart1.Series[0].IsVisibleInLegend = false;
            chart1.Series.Add("Potrosnja");
            chart1.Series["Potrosnja"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Potrosnja"].Color = Color.Red;

            chart1.Series.Add("Uvoz/Izvoz");
            chart1.Series["Uvoz/Izvoz"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Uvoz/Izvoz"].Color = Color.Blue;

            chart1.Series.Add("Baterija");
            chart1.Series["Baterija"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Baterija"].Color = Color.Green;

            chart1.Series.Add("Proizvodnja");
            chart1.Series["Proizvodnja"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            chart1.Series["Proizvodnja"].Color = Color.Black;

            double step = 24 / 86400;
            
            for (int i = 0; i < 86400; i++)
            {
                chart1.Series["Potrosnja"].Points.AddXY(step * i, podacis[i].Potrosnja_potrosaca);
                chart1.Series["Uboz/Izvoz"].Points.AddXY(step * i, podacis[i].Energija_distribucije);
                chart1.Series["Baterija"].Points.AddXY(step * i, podacis[i].Energija_baterije);
                chart1.Series["Proizvodnja"].Points.AddXY(step * i, podacis[i].Energija_panela);
            }
            
        }

        public static T ReadFromXmlFile<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));

                reader = new StreamReader(filePath);

                return (T)serializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }
    }
}
