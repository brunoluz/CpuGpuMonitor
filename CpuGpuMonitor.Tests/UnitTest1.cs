using System.Xml.Serialization;

using NUnit;

namespace CpuGpuMonitor.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            List<string> WordsToRemoveSensors = ["Max"];

            string sensorName = "Core Max";

            bool hasWord = WordsToRemoveSensors.Any(s => sensorName.Contains(s));
            

            Assert.That(hasWord, Is.True);
        }
    }
}
