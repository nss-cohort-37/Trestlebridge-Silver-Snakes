using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Facilities
{
    public class NaturalField : IFacility<IResource>
    {
        private int _capacity = 10;
        private Guid _id = Guid.NewGuid();

        private List<IResource> _plants = new List<IResource>();

        public List<IResource> Plants
        {
            get
            {
                return _plants;
            }
        }

        public double Capacity
        {
            get
            {
                return _capacity;
            }
        }

        public void AddResource(IResource plant)
        {
            // TODO: implement this...
            try
            {
                _plants.Add(plant);
            }
            catch
            {
                Console.WriteLine("This plant doesn't belong in this field!");
            }
        }

        public void AddResource(List<IResource> plants)
        {
            // TODO: implement this...
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            if (this._plants.Count == 1)
            {
                output.Append($"Natural field {shortId} has {this._plants.Count} row of plants\n");
            }
            else
            {
                output.Append($"Natural field {shortId} has {this._plants.Count} rows of plants\n");
            }

            this._plants.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }

        public string PlantCount()
        {
            if (this._plants.Count == 1)
            {
                return $"({this._plants.Count} row of plants)";
            }
            else
            {
                return $"({this._plants.Count} rows of plants)";
            }
        }
        public void PlantTypeCount()
        {
            if (this._plants.Count > 0)
            {
                var PlantTypeCount = this._plants
                    .GroupBy(Plant => Plant.Type)
                    .Select(group =>
                    {
                        return new PlantTypeReport
                        {
                            PlantType = group.Key,
                            PlantCount = group.Count()
                        };
                    });

                foreach (var report in PlantTypeCount)
                {
                    if (report.PlantCount == 1)
                    {
                        Console.Write($"({report.PlantCount} row of {report.PlantType}s) ");
                    }
                    else
                    {
                        Console.Write($"({report.PlantCount} rows of {report.PlantType}s) ");
                    }
                }
            }
        }
    }
    public class PlantTypeReport
    {
        public string PlantType { get; set; }
        public int PlantCount { get; set; }
    }
}