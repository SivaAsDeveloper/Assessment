using SharedDTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GeneralKnowledge.Test.App.Tests
{
    /// <summary>
    /// CSV processing test
    /// </summary>
    public class CsvProcessingTest : ITest
    {
        public void Run()
        {
            // TODO
            // Create a domain model via POCO classes to store the data available in the CSV file below
            // Objects to be present in the domain model: Asset, Country and Mime type
            // Process the file in the most robust way possible
            // The use of 3rd party plugins is permitted

            //Collection of simple POCO domain object
            List<Asset> Result = new List<Asset>();
            var csvFile = Resources.AssetImport;
            List<string> records = csvFile.Split('\n').ToList();
            string[] rowlabels = records.Take(1).First().Split(',');
            Dictionary<string, int> LookUpvalues = new Dictionary<string, int>();
            records.RemoveAt(0);
            for (int i = 0; i < rowlabels.Length; i++)
            {
                LookUpvalues.Add(rowlabels[i], i);
            }
            foreach (var row in records)
            {
                if (!string.IsNullOrEmpty(row))
                {
                    var columns = row.Split(',');
                    Result.Add(new Asset()
                    {
                        AssetId = new Guid(columns[LookUpvalues["asset id"]]),
                        Country = columns[LookUpvalues["country"]],
                        MIMEType = columns[LookUpvalues["mime_type"]]
                    });
                }
            }
            Console.WriteLine(Result.Count());
        }
    }
}
