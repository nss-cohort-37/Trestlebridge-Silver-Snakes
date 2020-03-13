using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Interfaces;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Models.Facilities {
    public class DuckHouse : IFacility<Duck> {
        private int _capacity = 12;
        private Guid _id = Guid.NewGuid ();

        private List<Duck> _animals = new List<Duck> ();

        public double Capacity {
            get {
                return _capacity;
            }
        }

        public List<Duck> Animals {
            get {
                return _animals;
            }
        }

        public void AddResource (Duck animal) {
            // TODO: implement this...
            try {
                _animals.Add (animal);
            } catch {
                Console.WriteLine ("This animal doesn't belong in this field!");
            }
        }

        public void AddResource (List<Duck> animals) {
            // TODO: implement this...
            throw new NotImplementedException ();
        }

        public string AnimalCount () {
            return $"({this._animals.Count} ducks)";
        }

        public override string ToString () {
            StringBuilder output = new StringBuilder ();
            string shortId = $"{this._id.ToString().Substring(this._id.ToString().Length - 6)}";

            output.Append ($"Duck house {shortId} has {this._animals.Count} ducks\n");
            this._animals.ForEach (a => output.Append ($"   {a}\n"));

            return output.ToString ();
        }
    }
}