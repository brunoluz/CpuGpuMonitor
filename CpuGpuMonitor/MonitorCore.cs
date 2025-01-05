using LibreHardwareMonitor.Hardware;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CpuGpuMonitor
{
    internal class MonitorCore
    {
        public readonly List<string> WordsToRemoveSensors = ["Max", "Average", "Package", "Hot Spot"];
        private readonly Computer computer = new()
        {
            IsCpuEnabled = true,
            IsGpuEnabled = true,
            IsMemoryEnabled = false,
            IsMotherboardEnabled = false,
            IsControllerEnabled = false,
            IsNetworkEnabled = false,
            IsStorageEnabled = false
        };

        public MonitorCore()
        {
            computer.Open();
        }

        public List<TemperatureMetric> GetTemps()
        {
            List<TemperatureMetric> metrics = [];
            DateTime now = DateTime.Now;

            computer.Accept(new UpdateVisitor());

            foreach (IHardware hardware in computer.Hardware)
            {
                var sensors = from x in hardware.Sensors
                              where x.SensorType == SensorType.Temperature
                              && !WordsToRemoveSensors.Any(s => x.Name.Contains(s))
                              select x;

                foreach (ISensor sensor in sensors)
                {
                    metrics.Add(new TemperatureMetric
                    {
                        DateTime = now,
                        HardwareName = hardware.Name,
                        SensorName = sensor.Name,
                        Value = sensor.Value
                    });
                }
            }

            return metrics;
            
        }

        ~MonitorCore()
        {
            computer.Close();
        }

    }
}
