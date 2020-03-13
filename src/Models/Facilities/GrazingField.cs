using System;
using System.Text;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using System.Linq;

namespace Trestlebridge.Models.Facilities {
    public class GrazingField : IFacility<IGrazing>
    {
        private int _capacity = 20;
        private Guid _id = Guid.NewGuid();

        private List<IGrazing> _animals = new List<IGrazing>();

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public void AddResource (IGrazing animal)
        {
            // TODO: implement this...
            try
            {
                _animals.Add(animal);
            }
            catch
            {
                Console.WriteLine("This animal doesn't belong in this field!");
            }
        }

        public void AddResource (List<IGrazing> animals) 
        {
            // TODO: implement this...
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append($"Grazing field {shortId} has {this._animals.Count} animals\n");
            this._animals.ForEach(a => output.Append($"   {a}\n"));

            return output.ToString();
        }

        public string AnimalCount()
        {
            return $"({this._animals.Count} animals)";
        }

        public void AnimalTypeCount()
        {
            if (this._animals.Count > 0)
            {
            var animalTypeCount = this._animals
                .GroupBy(animal => animal.Type)
                .Select(group =>
                {
                    return new AnimalReport
                    {
                        AnimalType = group.Key,
                        AnimalCount = group.Count()
                    };
                });

                foreach (var report in animalTypeCount)
                {
                    if (report.AnimalCount == 1)
                    {
                        Console.Write($"({report.AnimalCount} {report.AnimalType}) ");
                    }
                    else
                    {
                        Console.Write($"({report.AnimalCount} {report.AnimalType}s) ");
                    }
                }
            }
        }
    }
    public class AnimalReport
    {
        public string AnimalType { get; set; }
        public int AnimalCount { get; set; }
    }
}