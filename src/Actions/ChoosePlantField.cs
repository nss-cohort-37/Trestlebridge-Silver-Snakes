using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions {
    public class ChoosePlantField {
        public static void CollectPlantInput (Farm farm, IResource Plant, int fieldTypeNum) {
            Utils.Clear ();

            static void NaturalFieldsPrint (Farm farm) {
                for (int i = 0; i < farm.NaturalFields.Count; i++) {
                    Console.Write ($"{i + 1}. Natural Field {farm.NaturalFields[i].PlantCount()} ");
                    farm.NaturalFields[i].PlantTypeCount ();
                    Console.WriteLine ();

                }

            }
            static void PlowedFieldsPrint (Farm farm) {
                for (int i = 0; i < farm.PlowedFields.Count; i++) {
                    Console.Write ($"{i + 1}. Plowed Field {farm.PlowedFields[i].PlantCount()} ");
                    farm.PlowedFields[i].PlantTypeCount ();
                    Console.WriteLine ();
                }
            }
            static void FieldListForSunflowers (Farm farm) {
                int indexCounter = farm.NaturalFields.Count;
                for (int i = 0; i < farm.NaturalFields.Count; i++) {
                    Console.Write ($"{i + 1}. Natural Field {farm.NaturalFields[i].PlantCount()} ");
                    farm.NaturalFields[i].PlantTypeCount ();
                    Console.WriteLine ();

                }

                for (int i = 0; i < farm.PlowedFields.Count; i++) {
                    Console.Write ($"{i + 1 + indexCounter}. Plowed Field {farm.PlowedFields[i].PlantCount()} ");
                    farm.PlowedFields[i].PlantTypeCount ();
                    Console.WriteLine ();
                }

            }

            if (fieldTypeNum == 1) {
                PlowedFieldsPrint (farm);
            } else if (fieldTypeNum == 2) {
                NaturalFieldsPrint (farm);
            } else {
                FieldListForSunflowers (farm);
            }

            Console.WriteLine ();

            // How can I output the type of Plant chosen here?
            Console.WriteLine ($"Place the Plant where?");

            Console.Write ("> ");
            int choice = Int32.Parse (Console.ReadLine ()) - 1;

            if (fieldTypeNum == 1) {
                farm.PlowedFields[choice].AddResource (Plant);
                Console.WriteLine("Congrats! You've planted a row of Sesame seeds in a plowed field.");
                Console.WriteLine("Press return to go back to the main menu.");
                Console.ReadLine();
            } else if (fieldTypeNum == 2) {
                farm.NaturalFields[choice].AddResource (Plant);
                Console.WriteLine("Congrats! You've planted a row of Wildflower seeds in a natural field.");
                Console.WriteLine("Press return to go back to the main menu.");
                Console.ReadLine();
            } else {
                if (choice > farm.NaturalFields.Count - 1) {
                    choice = choice - farm.NaturalFields.Count;
                    farm.PlowedFields[choice].AddResource (Plant);
                    Console.WriteLine("Congrats! You've planted a row of Sunflower seeds in a plowed field.");
                    Console.WriteLine("Press return to go back to the main menu.");
                    Console.ReadLine();
                } else {
                    farm.NaturalFields[choice].AddResource (Plant);
                    Console.WriteLine("Congrats! You've planted a row of Sunflower seeds in a natural field.");
                    Console.WriteLine("Press return to go back to the main menu.");
                    Console.ReadLine();
                }

            }

            // farm.GrazingFields[choice].AddResource (Plant);

            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(Plant, choice);

        }
    }
}