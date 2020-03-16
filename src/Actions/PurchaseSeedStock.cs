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

            while(true)
            {
                Console.WriteLine ("What are you buying today? Hit return to exit");
                Console.Write ("> ");
                try
                {
                    string choice = Console.ReadLine ();
                    if (String.IsNullOrEmpty(choice))
                    {
                      break;
                    }
                    else
                    {
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
                        break;
                    }
                }
                catch
                {
                  Console.WriteLine("Please enter a valid index range");
                }
            }
        }
    }
}