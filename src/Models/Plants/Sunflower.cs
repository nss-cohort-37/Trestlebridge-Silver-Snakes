using System;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Plants {
    public class Sunflower : IResource, ISeedComposts {
        private int _seedsProduced = 650;
        private double _compost = 21.6;
        public string Type { get; } = "Sunflower";

        public double Harvest () {
            return _seedsProduced;
        }
        public double Compost () {
            return _compost;
        }

        public override string ToString () {
            return $"Here comes the sun do doot do do";
        }
    }
}