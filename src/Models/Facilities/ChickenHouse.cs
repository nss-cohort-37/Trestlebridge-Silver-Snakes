using System;
using System.Collections.Generic;
using System.Text;
using Trestlebridge.Interfaces;
namespace Trestlebridge.Models.Facilities {
    public class ChickenHouse : IFacility<IMeatProducing> {
        private int _capacity = 15;
        public double Capacity {
            get {
                return _capacity;
            }
        }
        private Guid _id = Guid.NewGuid ();
        private List<IMeatProducing> _animals = new List<IMeatProducing> ();

        public void AddResource (IMeatProducing resource) {
            throw new NotImplementedException ();
        }
        public void AddResource (List<IMeatProducing> resources) {
            throw new NotImplementedException ();
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