using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions {
    public class CreateFacility {
        public static void CollectInput (Farm farm) {
            Console.WriteLine ("1. Grazing field");
            Console.WriteLine ("2. Plowed field");
            Console.WriteLine ("3. Natural field");
            Console.WriteLine ("4. Duck House");
            Console.WriteLine ("5. Chicken House");

            Console.WriteLine ();
            Console.WriteLine ("Choose what you want to create");

            Console.Write ("> ");
            string input = Console.ReadLine ();

            switch (Int32.Parse (input)) {
                case 1:
                    farm.AddGrazingField (new GrazingField ());
                    Console.WriteLine ("Congrats! You've created a grazing field.");
                    Console.WriteLine ("Press return to go back to the main menu.");
                    Console.ReadLine ();
                    break;

                case 4:
                    farm.AddDuckHouse (new DuckHouse ());
                    break;
                case 5:
                    farm.AddChickenHouse (new ChickenHouse ());
                    break;
                default:
                    break;
            }
        }
    }
}