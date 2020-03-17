using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
    public class PurchaseStock
    {
        public static void CollectInput(Farm farm)
        {

            var ChickenList = new List<Chicken>();

            Console.WriteLine("1. Cow");
            Console.WriteLine("2. Ostrich");
            Console.WriteLine("3. Pig");
            Console.WriteLine("4. Goat");
            Console.WriteLine("5. Sheep");
            Console.WriteLine("6. Duck");
            Console.WriteLine("7. Chicken");

            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("What are you buying today? Hit return to exit");
                Console.Write("> ");
                try
                {
                    string choice = Console.ReadLine();
                    if (String.IsNullOrEmpty(choice))
                    {
                        break;
                    }
                    else
                    {
                        if (Int32.Parse(choice) < 1 || Int32.Parse(choice) > 7)
                        {
                            Console.WriteLine("Please enter a valid index range");
                        }
                        else
                        {
                            switch (Int32.Parse(choice))
                            {
                                case 1:
                                    ChooseGrazingField.CollectInput(farm, new Cow());
                                    break;
                                case 2:
                                    ChooseGrazingField.CollectInput(farm, new Ostrich());
                                    break;
                                case 3:
                                    ChooseGrazingField.CollectInput(farm, new Pig());
                                    break;
                                case 4:
                                    ChooseGrazingField.CollectInput(farm, new Goat());
                                    break;
                                case 5:
                                    ChooseGrazingField.CollectInput(farm, new Sheep());
                                    break;
                                case 6:
                                    ChooseDuckHouse.CollectInput(farm, new Duck());
                                    break;
                                case 7:
                                    Console.WriteLine("How many Chickens would you like to buy?");
                                    try
                                    {

                                        int amount = int.Parse(Console.ReadLine());
                                        for (int i = 0; i < amount; i++)
                                        {
                                            ChickenList.Add(new Chicken());
                                        }
                                    }
                                    catch
                                    {

                                    }
                                    ChooseChickenHouse.CollectInput(farm, ChickenList);
                                    break;
                                default:
                                    break;
                            }
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
    }
}