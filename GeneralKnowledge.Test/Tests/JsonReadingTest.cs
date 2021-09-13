using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// Basic data retrieval from JSON test
    /// </summary>
    public class JsonReadingTest : ITest
    {
        public class Sample
        {
            public double temperature { get; set; }
            public int pH { get; set; }
            public int phosphate { get; set; }
            public int chloride { get; set; }
            public int nitrate { get; set; }
        }
        public class Root
        {
            public List<Sample> samples { get; set; }
        }
        public string Name { get { return "JSON Reading Test"; } }
        public void Run()
        {
            var jsonData = Resources.SamplePoints;
            // TODO:
            // Determine for each parameter stored in the variable below, the average value, lowest and highest number.
            // Example output
            // parameter   LOW AVG MAX
            // temperature   x   y   z
            // pH            x   y   z
            // Chloride      x   y   z
            // Phosphate     x   y   z
            // Nitrate       x   y   z
            PrintOverview(jsonData);
        }
        private void PrintOverview(byte[] data)
        {
            var sampointinstring = System.Text.Encoding.ASCII.GetString(data);
            var SamplePoint = JsonConvert.DeserializeObject<Root>(sampointinstring);
            SamplePoint.samples.First();
            var properties = SamplePoint.samples.First().GetType().GetProperties().Select(x => x.Name);
            Console.WriteLine("parameter  \t \t \t  \t LOW  \t AVG \t  MAX");
            foreach (var item in properties)
            {
                var low = Low(SamplePoint.samples, item);
                var avg = AVG(SamplePoint.samples, item);
                var max = MAX(SamplePoint.samples, item);
                Console.WriteLine($"{item} \t \t \t \t {low} \t {Math.Round(avg, 2, MidpointRounding.AwayFromZero)} \t {max}");
            }
        }
        private object Low(List<Sample> details, string propertyname)
        {
            var values = details.Select(x => x.GetType().GetProperty(propertyname).GetValue(x)).Min();
            return values;
        }
        private double AVG(List<Sample> details, string propertyname)
        {
            IEnumerable<Object> Resulttemp = details.Select(x => x.GetType().GetProperty(propertyname).GetValue(x));
            List<double> Result = new List<double>();
            foreach (var item in Resulttemp)
            {
                Result.Add(Convert.ToDouble(item));
            }
            return Result.Average();
        }
        private object MAX(List<Sample> details, string propertyname)
        {
            var values = details.Select(x => x.GetType().GetProperty(propertyname).GetValue(x)).Max();
            return values;
        }
    }
}
