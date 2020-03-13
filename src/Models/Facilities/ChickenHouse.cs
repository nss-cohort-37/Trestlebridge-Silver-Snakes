using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;
namespace Trestlebridge.Models.Facilities {
    public class ChickenHouse : IFacility<Chicken> {
        private int _capacity = 15;
        public double Capacity {
            get {
                return _capacity;
            }
        }
        private Guid _id = Guid.NewGuid ();
        private List<Chicken> _animals = new List<Chicken> ();

        public void AddResource (Chicken resource) {
            try {
                _animals.Add (resource);
            } catch {
                Console.WriteLine ("This animal doesn't belong in this field!");
            }
        }
        public void AddResource (List<Chicken> resources) {
            throw new NotImplementedException ();
        }

        public string AnimalCount () {
            return $"({this._animals.Count} chickens)";
        }

        public override string ToString () {
            StringBuilder output = new StringBuilder ();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append ($"Chicken house {shortId} has {this._animals.Count} chickens\n");
            this._animals.ForEach (a => output.Append ($"   {a}\n"));

            return output.ToString ();
        }
    }
}