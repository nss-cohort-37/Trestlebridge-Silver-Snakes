using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Plants;

namespace Trestlebridge.Actions
{
    public class ChoosePlantField
    {
        public static void CollectPlantInput(Farm farm, IResource Plant, int fieldTypeNum)
        {
            Utils.Clear();

            static void NaturalFieldsPrint(Farm farm)
            {
                var availableNaturalFields = farm.NaturalFields.Where(naturalField => naturalField.Plants.Count < naturalField.Capacity).ToList();

                for (int i = 0; i < availableNaturalFields.Count; i++)
                {
                    Console.Write($"{i + 1}. Natural Field {availableNaturalFields[i].PlantCount()} ");
                    availableNaturalFields[i].PlantTypeCount();
                    Console.WriteLine();
                }

            }
            static void PlowedFieldsPrint(Farm farm)
            {
                var availablePlowedFields = farm.PlowedFields.Where(plowedField => plowedField.Plants.Count < plowedField.Capacity).ToList();

                for (int i = 0; i < availablePlowedFields.Count; i++)
                {
                    Console.Write($"{i + 1}. Plowed Field {availablePlowedFields[i].PlantCount()} ");
                    availablePlowedFields[i].PlantTypeCount();
                    Console.WriteLine();
                }
            }
            static void FieldListForSunflowers(Farm farm)
            {
                var availableNaturalFields = farm.NaturalFields.Where(naturalField => naturalField.Plants.Count < naturalField.Capacity).ToList();

                int indexCounter = availableNaturalFields.Count;
                for (int i = 0; i < availableNaturalFields.Count; i++)
                {
                    Console.Write($"{i + 1}. Natural Field {availableNaturalFields[i].PlantCount()} ");
                    availableNaturalFields[i].PlantTypeCount();
                    Console.WriteLine();
                }


                var availablePlowedFields = farm.PlowedFields.Where(plowedField => plowedField.Plants.Count < plowedField.Capacity).ToList();

                for (int i = 0; i < availablePlowedFields.Count; i++)
                {
                    Console.Write($"{i + 1 + indexCounter}. Plowed Field {availablePlowedFields[i].PlantCount()} ");
                    availablePlowedFields[i].PlantTypeCount();
                    Console.WriteLine();
                }

            }
            while (true)
            {

                if (fieldTypeNum == 1)
                {
                    var availablePlowedFields = farm.PlowedFields.Where(plowedField => plowedField.Plants.Count < plowedField.Capacity).ToList();

                    if (availablePlowedFields.Count == 0)
                    {
                        Console.WriteLine("There are no availible Plowed Fields");
                        Console.WriteLine("press enter to return to the main menu");
                        Console.ReadLine();
                        break;
                    }
                    else
                    {
                        PlowedFieldsPrint(farm);

                    }
                }
                else if (fieldTypeNum == 2)
                {
                    var availableNaturalFields = farm.NaturalFields.Where(naturalField => naturalField.Plants.Count < naturalField.Capacity).ToList();

                    if (availableNaturalFields.Count == 0)
                    {
                        Console.WriteLine("There are no availible Natural Fields");
                        Console.WriteLine("press enter to return to the main menu");
                        Console.ReadLine();
                        break;

                    }
                    NaturalFieldsPrint(farm);
                }
                else
                {
                    var availablePlowedFields = farm.PlowedFields.Where(plowedField => plowedField.Plants.Count < plowedField.Capacity).ToList();
                    var availableNaturalFields = farm.NaturalFields.Where(naturalField => naturalField.Plants.Count < naturalField.Capacity).ToList();

                    if (availableNaturalFields.Count == 0 && availablePlowedFields.Count == 0)
                    {
                        Console.WriteLine("There are no availible Fields for Sunflowers");
                        Console.WriteLine("press enter to return to the main menu");
                        Console.ReadLine();
                        break;

                    }
                    FieldListForSunflowers(farm);
                }

                Console.WriteLine();

                // How can I output the type of Plant chosen here?

                Console.WriteLine($"Place the Plant where?");
                Console.Write("> ");
                try
                {
                    var choice = Console.ReadLine();
                    if (String.IsNullOrEmpty(choice))
                    {
                        break;
                    }
                    else
                    {
                        var parsedChoice = Int32.Parse(choice) - 1;
                        if (fieldTypeNum == 1)
                        {
                            farm.PlowedFields[parsedChoice].AddResource(Plant);
                            Console.WriteLine("Congrats! You've planted a row of Sesame seeds in a plowed field.");
                            Console.WriteLine("Press return to go back to the main menu.");
                            Console.ReadLine();
                        }
                        else if (fieldTypeNum == 2)
                        {
                            farm.NaturalFields[parsedChoice].AddResource(Plant);
                            Console.WriteLine("Congrats! You've planted a row of Wildflower seeds in a natural field.");
                            Console.WriteLine("Press return to go back to the main menu.");
                            Console.ReadLine();
                        }
                        else
                        {
                            if (parsedChoice > farm.NaturalFields.Count - 1)
                            {
                                parsedChoice = parsedChoice - farm.NaturalFields.Count;
                                farm.PlowedFields[parsedChoice].AddResource(Plant);
                                Console.WriteLine("Congrats! You've planted a row of Sunflower seeds in a plowed field.");
                                Console.WriteLine("Press return to go back to the main menu.");
                                Console.ReadLine();
                            }
                            else
                            {
                                farm.NaturalFields[parsedChoice].AddResource(Plant);
                                Console.WriteLine("Congrats! You've planted a row of Sunflower seeds in a natural field.");
                                Console.WriteLine("Press return to go back to the main menu.");
                                Console.ReadLine();
                            }
                        }
                        break;
                    }
                }
                catch
                {
                    Console.WriteLine("Please enter a valid index range");
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