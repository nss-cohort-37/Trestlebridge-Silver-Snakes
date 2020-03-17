using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;
using System.Linq;
using System.Collections.Generic;

namespace Trestlebridge.Actions
{
    public class ChooseMeatProcessingFacility
    {
        public static void CollectProcessingInput(Farm farm)
        {
            Utils.Clear();
            var notEmptyGrazingFields = farm.GrazingFields.Where(grazingField => grazingField.Animals.Count > 0).ToList();

            var notEmptyChickenHouses = farm.ChickenHouses.Where(chickenHouse => chickenHouse.Animals.Count > 0).ToList();

            var meatyGrazingFields = notEmptyGrazingFields.Where(grazingField =>
            {
                var allGoats = grazingField.Animals.All(animal => animal.Type == "Goat");
                return !allGoats;
            }).ToList();

            int indexCounter = meatyGrazingFields.Count;
            for (int i = 0; i < meatyGrazingFields.Count; i++)
            {
                Console.Write($"{i + 1}. Grazing Field {meatyGrazingFields[i].AnimalCount()} ");
                meatyGrazingFields[i].AnimalTypeCount();
                Console.WriteLine();
            }

            for (int i = 0; i < notEmptyChickenHouses.Count; i++)
            {
                Console.Write($"{i + 1 + indexCounter}. Chicken House {notEmptyChickenHouses[i].AnimalCount()} ");
                notEmptyChickenHouses[i].AnimalCount();
                Console.WriteLine();
            }

            Console.WriteLine("Which facility would you like to process with?");

            while (true)
            {
                var parsedChoice = int.Parse(Console.ReadLine()) - 1;

                if (parsedChoice > meatyGrazingFields.Count - 1)
                {
                    parsedChoice = parsedChoice - meatyGrazingFields.Count;
                    ChooseMeatToProcess.CollectChickenInput(notEmptyChickenHouses[parsedChoice]);
                    break;
                }
                else
                {
                    ChooseMeatToProcess.CollectMeatInput(meatyGrazingFields[parsedChoice]);
                    break;
                }
            }



            // if (parsedChoice > availableNaturalFields.Count - 1)
            // {
            //   parsedChoice = parsedChoice - availableNaturalFields.Count;
            //   availablePlowedFields[parsedChoice].AddResource(Plant);
            //   Console.WriteLine("Congrats! You've planted a row of Sunflower seeds in a plowed field.");
            //   Console.WriteLine("Press return to go back to the main menu.");
            //   Console.ReadLine();
            // }
            // else
            // {
            //   availableNaturalFields[parsedChoice].AddResource(Plant);
            //   Console.WriteLine("Congrats! You've planted a row of Sunflower seeds in a natural field.");
            //   Console.WriteLine("Press return to go back to the main menu.");
            //   Console.ReadLine();
            // }


            // while (true)
            // {
            //   var choice = Console.ReadLine();

            //   if (Int32.Parse(choice) < 1 || Int32.Parse(choice) > 3)
            //   {
            //     Console.WriteLine("Please enter a valid index range");
            //   }
            //   else
            //   {
            //     switch (Int32.Parse(choice))
            //     {
            //       case 1:
            //         ChooseMeatToProcess.CollectMeatInput(farm);
            //         break;
            //       default: break;

            //     }
            //     break;

            //   }
            // }
            // Console.ReadLine();
        }
    }
}