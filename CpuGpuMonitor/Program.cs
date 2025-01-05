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
            PrintTemperatureGraph(temps);
        }
        

    }

    static void PrintTemperatureGraph(List<TemperatureMetric> metrics)
    {
        if (metrics == null || metrics.Count == 0)
        {
            Console.WriteLine("No temperature data available.");
            return;
        }

        // Ordena as métricas por DateTime
        metrics = metrics.OrderBy(m => m.DateTime).ToList();

        // Encontra os valores mínimo e máximo para normalizar os dados
        float minValue = metrics.Min(m => m.Value) ?? 0;
        float maxValue = metrics.Max(m => m.Value) ?? 0;

        // Define a largura do gráfico
        int graphWidth = 50;

        foreach (var metric in metrics)
        {
            // Normaliza o valor para a largura do gráfico
            int normalizedValue = (int)((metric.Value - minValue) / (maxValue - minValue) * graphWidth);

            // Imprime a linha do gráfico
            Console.WriteLine($"{metric.DateTime:HH:mm:ss} | {new string('#', normalizedValue)} {metric.Value}°C");
        }
    }
}



