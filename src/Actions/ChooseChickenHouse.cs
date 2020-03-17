
using System;
using System.Collections.Generic;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;
namespace Trestlebridge.Actions
{
    public class ChooseChickenHouse
    {

        public static void CollectInput(Farm farm, List<Chicken> animals)
        {

            Utils.Clear();

            while (true)
            {


                if (farm.ChickenHouses.Count == 0)
                {

                    Console.WriteLine("There are no available chicken houses. \nPress return to go back to the main menu");
                    Console.ReadLine();
                    break;
                }
                else
                {
                    for (int i = 0; i < farm.ChickenHouses.Count; i++)
                    {
                        Console.Write($"{i + 1}. Chicken House {farm.ChickenHouses[i].AnimalCount()} ");
                        Console.WriteLine();
                    }
                    break;
                }
            }

            static void PrintChickenHouses(Farm farm, List<ChickenHouse> availableChickenHouses)
            {

                for (int i = 0; i < availableChickenHouses.Count; i++)
                {
                    Console.Write($"{i + 1}. Chicken House {availableChickenHouses[i].AnimalCount()} (Room for {availableChickenHouses[i].Capacity - availableChickenHouses[i].Animals.Count} Chickens)");
                    Console.WriteLine();
                }
            }
            while (animals.Count != 0)
            {

                Console.WriteLine($"How many chickens would you like to add to a house? You have {animals.Count} to place\n Or press 'Enter' to exit");
                try
                {
                    int amount = 0;
                    bool breakLoopBool = false;
                    while (true)
                    {
                        string stringAmount = Console.ReadLine();
                        if (String.IsNullOrEmpty(stringAmount))
                        {
                            breakLoopBool = true;
                            break;
                        }

                        amount = int.Parse(stringAmount);
                        if (amount > 0 && amount <= animals.Count)
                        {
                            break;
                        }

                        else
                        {
                            Console.WriteLine($"Please Enter a number between 1-{animals.Count}");
                        }
                    }
                    if (breakLoopBool == true)
                    {
                        break;
                    }
                    var availableChickenHouses = farm.ChickenHouses.Where(chickenHome => chickenHome.Animals.Count + amount <= chickenHome.Capacity).ToList();

                    while (true)
                    {
                        if (amount == 0)
                        {
                            break;
                        }
                        Utils.Clear();
                        PrintChickenHouses(farm, availableChickenHouses);
                        Console.WriteLine($"Place the chickens where?\nPlacing {amount} Chickens \nor hit return to exit");
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



                                for (int i = 0; i < amount; i++)
                                {
                                    availableChickenHouses[Int32.Parse(choice) - 1].AddResource(animals[i]);

                                }

                                for (int i = 0; i < amount; i++)
                                {
                                    animals.Remove(animals[amount - i - 1]);

                                }
                                if (amount == 1)
                                {

                                    Console.WriteLine($"You have added {amount} Chicken to the chicken house!");
                                }
                                else
                                {
                                    Console.WriteLine($"You have added {amount} Chickens to the chicken house!");

                                }
                                Console.WriteLine($"Press any key to continue");
                                Console.ReadLine();
                                Utils.Clear();
                                PrintChickenHouses(farm, availableChickenHouses);



                            }
                        }

                        catch
                        {
                            Console.WriteLine("I Broke");
                        }
                        break;
                    }
                }
                catch
                {

                }
            }

        }
    }
}