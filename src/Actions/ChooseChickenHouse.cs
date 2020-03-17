// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Trestlebridge.Interfaces;
// using Trestlebridge.Models;
// using Trestlebridge.Models.Animals;
// using Trestlebridge.Models.Facilities;

// namespace Trestlebridge.Actions
// {
//     public class ChooseChickenHouse
//     {
//         public static void CollectInput(Farm farm, List<Chicken> animals)
//         {
//             Utils.Clear();
//             var availableChickenHouses = farm.ChickenHouses.Where(chickenHome => chickenHome.Animals.Count < chickenHome.Capacity).ToList();


//             static void PrintChickenHouses(Farm farm, List<ChickenHouse> availableChickenHouses)
//             {
//                 Utils.Clear();
//                 for (int i = 0; i < availableChickenHouses.Count; i++)
//                 {
//                     Console.Write($"{i + 1}. Chicken House {availableChickenHouses[i].AnimalCount()} (Room for {availableChickenHouses[i].Capacity - availableChickenHouses[i].Animals.Count} Chickens)");
//                     Console.WriteLine();
//                 }
//             }
//             if (availableChickenHouses.Count == 0)
//             {
//                 Console.WriteLine("There are no available chicken houses. \nPress return to go back to the main menu");
//                 Console.ReadLine();
//             }
//             else
//             {
//                 for (int i = 0; i < availableChickenHouses.Count; i++)
//                 {
//                     Console.Write($"{i + 1}. Chicken House {availableChickenHouses[i].AnimalCount()} ");
//                     Console.WriteLine();
//                 }

//                 Console.WriteLine();

//                 // How can I output the type of animal chosen here?
//                 while (true)
//                 {
//                     PrintChickenHouses(farm, availableChickenHouses);
//                     Console.WriteLine($"Place the chickens where? \nYou have {animals.Count} to place\nor hit return to exit");
//                     Console.Write("> ");
//                     try
//                     {
//                         var choice = Console.ReadLine();
//                         if (String.IsNullOrEmpty(choice))
//                         {
//                             break;
//                         }
//                         else
//                         {

//                             while (true)
//                             {

//                                 Console.WriteLine("How many chickens would you like to add to a house?");
//                                 try
//                                 {
//                                     int amount = 0;

//                                     while (true)
//                                     {
//                                         amount = int.Parse(Console.ReadLine());
//                                         if (amount > 0 && amount <= animals.Count)
//                                         {
//                                             break;
//                                         }
//                                         else
//                                         {
//                                             Console.WriteLine($"Please Enter a number between 1-{animals.Count}");
//                                         }
//                                     }


//                                     for (int i = 0; i < amount; i++)
//                                     {
//                                         availableChickenHouses[Int32.Parse(choice) - 1].AddResource(animals[i]);

//                                     }

//                                     for (int i = 0; i < amount; i++)
//                                     {
//                                         animals.Remove(animals[amount - i - 1]);

//                                     }
//                                     Console.WriteLine($"You have added {amount} Chickens to the chicken house!");
//                                     Console.WriteLine($"Press any key to continue");
//                                     Console.ReadLine();


//                                 }
//                                 catch
//                                 {
//                                     Console.WriteLine("I Broke");
//                                 }
//                                 break;
//                             }

//                             if (animals.Count == 0)
//                             {
//                                 break;
//                             }

//                         }
//                     }
//                     catch
//                     {
//                         Console.WriteLine("Please enter a valid index range");
//                     }
//                 }
//             }


//             /*
//                 Couldn't get this to work. Can you?
//                 Stretch goal. Only if the app is fully functional.
//              */
//             // farm.PurchaseResource<IGrazing>(animal, choice);

//         }
//     }
// }




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

                Console.WriteLine($"How many chickens would you like to add to a house? You have {animals.Count} to place");
                try
                {
                    int amount = 0;

                    while (true)
                    {
                        amount = int.Parse(Console.ReadLine());
                        if (amount > 0 && amount <= animals.Count)
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"Please Enter a number between 1-{animals.Count}");
                        }
                    }
                    var availableChickenHouses = farm.ChickenHouses.Where(chickenHome => chickenHome.Animals.Count + amount <= chickenHome.Capacity).ToList();

                    while (true)
                    {
                        PrintChickenHouses(farm, availableChickenHouses);
                        Console.WriteLine($"Place the chickens where? \nor hit return to exit");
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
                                Console.WriteLine($"You have added {amount} Chickens to the chicken house!");
                                Console.WriteLine($"Press any key to continue");
                                Console.ReadLine();
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