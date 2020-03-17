using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions
{
    public class ChooseChickenHouse
    {
        public static void CollectInput(Farm farm, List<Chicken> animals)
        {
            Utils.Clear();

            var availableChickenHouses = farm.ChickenHouses.Where(chickenHome => chickenHome.Animals.Count < chickenHome.Capacity).ToList();

            if (availableChickenHouses.Count == 0)
            {
                Console.WriteLine("There are no available chicken houses. \nPress return to go back to the main menu");
                Console.ReadLine();
            }
            else
            {
                for (int i = 0; i < availableChickenHouses.Count; i++)
                {
                    Console.Write($"{i + 1}. Chicken House {availableChickenHouses[i].AnimalCount()} ");
                    Console.WriteLine();
                }

                Console.WriteLine();

                // How can I output the type of animal chosen here?
                while (true)
                {
                    Console.WriteLine($"Place the chickens where? \nYou have {animals.Count} to place\nor hit return to exit");
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

                            while (true)
                            {
                                Console.WriteLine("How many would you like to add to this house?");
                                try
                                {
                                    int amount = int.Parse(Console.ReadLine());
                                    var initialCount = animals.Count;
                                    for (int i = 0; i < amount; i++)
                                    {
                                        availableChickenHouses[Int32.Parse(choice) - 1].AddResource(animals[i]);
                                        animals.Remove(animals[i]);
                                    }



                                }
                                catch
                                {

                                }
                                break;
                            }

                            if (animals.Count == 0)
                            {
                                break;
                            }

                        }
                    }
                    catch
                    {
                        Console.WriteLine("Please enter a valid index range");
                    }
                }
            }


            /*
                Couldn't get this to work. Can you?
                Stretch goal. Only if the app is fully functional.
             */
            // farm.PurchaseResource<IGrazing>(animal, choice);

        }
    }
}