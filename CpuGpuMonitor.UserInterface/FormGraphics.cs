using OxyPlot.Axes;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System.Linq;
using OxyPlot.Legends;

namespace CpuGpuMonitor.UserInterface
{
    public partial class FormGraphics : Form
    {
        readonly MonitorCore core = new();
        readonly List<LineSeries> lineSeries = [];
        readonly List<TemperatureMetric> allTemps = [];
        readonly PlotModel plotModel = new()
        {
            Title = "Temperature Metrics"
        };

        public FormGraphics()
        {
            InitializeComponent();
            this.timerUpdateSeries.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            plotModel.Legends.Add(new Legend
            {
                LegendTitle = "Legend",
                LegendPosition = LegendPosition.RightBottom,
            });

            this.plotView1.Model = plotModel;
        }

        void UpdatePlot(List<LineSeries> lineSeries, List<TemperatureMetric> metrics)
        {
            foreach (var metric in metrics)
            {
                LineSeries lineSerie = lineSeries.FirstOrDefault(s => s.Title == metric.FullSensorName);
                if (lineSerie is null)
                {
                    lineSerie = new LineSeries { Title = metric.FullSensorName };
                    this.plotModel.Series.Add(lineSerie);
                }

                lineSerie.Points.Add(new DataPoint(DateTimeAxis.ToDouble(metric.DateTime), metric.Value));
                lineSeries.Add(lineSerie);
            }
        }

        private void timerUpdateSeries_Tick(object sender, EventArgs e)
        {
            var newTemps = core.GetTemps();
            this.allTemps.InsertRange(0, newTemps);
            UpdatePlot(lineSeries, newTemps);
            this.plotView1.InvalidatePlot(true);
        }

        private void plotView1_Click(object sender, EventArgs e)
        {

        }

        private void FormGraphics_FormClosed(object sender, FormClosedEventArgs e)
        {
            var csvFilePath = $"temperature_metrics_{DateTime.Now.ToString("yyyyMMddHHmmss")}.csv";
            using (var writer = new StreamWriter(csvFilePath))
            {
                writer.WriteLine("DateTime,HardwareName,SensorName,Value,FullSensorName");
                foreach (var temp in allTemps)
                {
                    writer.WriteLine($"{temp.DateTime},{temp.HardwareName},{temp.SensorName},{temp.Value},{temp.FullSensorName}");
                }
            }
        }
    }
}
