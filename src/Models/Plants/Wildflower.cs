using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants {
    public class Wildflower : IResource, ICompostProducing {

        private double _compost = 30.3;
        public string Type { get; } = "Wildflower";

        public double Compost () {
            return _compost;
        }

        public override string ToString () {
            return $"These flowers are wild!";
        }
    }
}