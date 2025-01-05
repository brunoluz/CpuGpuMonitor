namespace CpuGpuMonitor
{
    public class TemperatureMetric
    {
        public required DateTime DateTime { get; set; }
        public required string HardwareName { get; set; }
        public required string SensorName { get; set; }
        public required float Value { get; set; }
    }
}