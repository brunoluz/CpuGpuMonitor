using OxyPlot.Axes;
using OxyPlot;
using OxyPlot.Series;
using OxyPlot.WindowsForms;
using System.Linq;

namespace CpuGpuMonitor.UserInterface
{
    public partial class FormGraphics : Form
    {
        readonly MonitorCore core = new();
        readonly List<LineSeries> lineSeries = [];
        readonly List<TemperatureMetric> allTemps = [];
        readonly PlotModel plotModel = new() { Title = "Temperature Metrics" };

        public FormGraphics()
        {
            InitializeComponent();
            this.timerUpdateSeries.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.plotView1.Model = plotModel;
        }

        void UpdatePlot(List<LineSeries> lineSeries, List<TemperatureMetric> metrics)
        {
            foreach (var metric in metrics)
            {
                LineSeries lineSerie = lineSeries.FirstOrDefault(s => s.Title == metric.SensorName);
                if (lineSerie is null)
                {
                    lineSerie = new LineSeries { Title = metric.SensorName };
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
    }
}
