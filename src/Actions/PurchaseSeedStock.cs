using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions {
    public class PurchaseSeedStock {
        public static void CollectInput (Farm farm) {
            Console.WriteLine ("1. Sesame");
            Console.WriteLine ("2. Sunflower");
            Console.WriteLine ("3. Wildflower");

            Console.WriteLine ();
            Console.WriteLine ("What are you buying today?");

            Console.Write ("> ");
            string choice = Console.ReadLine ();

            switch (Int32.Parse (choice)) {
                case 1:
                    ChoosePlantField.CollectPlantInput (farm, new Sesame (), 1);
                    break;
                case 2:
                    ChoosePlantField.CollectPlantInput (farm, new Sunflower (), 3);
                    break;
                case 3:
                    ChoosePlantField.CollectPlantInput (farm, new Wildflower (), 2);
                    break;
                default:
                    break;
            }
        }
    }
}