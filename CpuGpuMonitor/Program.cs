using CpuGpuMonitor;
using LibreHardwareMonitor.Hardware;
using System;
using System.Management;

class Program
{
    
    static void Main()
    {
        MonitorCore core = new();

        while (true)
        {
            List<TemperatureMetric> temps = core.GetTemps();
            PrintTemperature(temps);

            Thread.Sleep(1000);
        }
        

    }

    static void PrintTemperature(List<TemperatureMetric> metrics)
    {
        foreach (var metric in metrics)
        {
            // Imprime a linha do gráfico
            Console.WriteLine($"{metric.DateTime:HH:mm:ss} | {metric.HardwareName} | {metric.SensorName} | {metric.Value.ToString(".0")} °C");
        }
    }
}



