// using System;
// using System.Collections.Generic;
// using System.Linq;
// using Trestlebridge.Interfaces;
// using Trestlebridge.Models;
// using Trestlebridge.Models.Animals;
// using Trestlebridge.Models.Facilities;
// namespace Trestlebridge.Actions
// {
//     public class ChooseChickenHouse2
//     {

//         public static void CollectInput(Farm farm, List<Chicken> animals)
//         {
//             Utils.Clear();


//             static void PrintChickenHouses(Farm farm, List<ChickenHouse> availableChickenHouses)
//             {
//                 Utils.Clear();
//                 for (int i = 0; i < availableChickenHouses.Count; i++)
//                 {
//                     Console.Write($"{i + 1}. Chicken House {availableChickenHouses[i].AnimalCount()} (Room for {availableChickenHouses[i].Capacity - availableChickenHouses[i].Animals.Count} Chickens)");
//                     Console.WriteLine();
//                 }
//             }
//             while (true)
//             {
//                 var availableChickenHouses = farm.ChickenHouses.Where(chickenHome => chickenHome.Animals.Count + amount <= chickenHome.Capacity).ToList();

//                 PrintChickenHouses(farm, availableChickenHouses);
//                 Console.WriteLine("How many chickens would you like to add to a house?");
//                 try
//                 {
//                     int amount = 0;

//                     while (animals.Count != 0)
//                     {

//                         amount = int.Parse(Console.ReadLine());
//                         if (amount > 0 && amount <= animals.Count)
//                         {
//                             break;
//                         }


//                         else
//                         {
//                             Console.WriteLine($"Please Enter a number between 1-{animals.Count}");
//                         }

//                     }

//                     while (true)
//                     {
//                         PrintChickenHouses(farm, availableChickenHouses);
//                         Console.WriteLine($"Place the chickens where? \nYou have {animals.Count} to place\nor hit return to exit");
//                         Console.Write("> ");
//                         try
//                         {
//                             var choice = Console.ReadLine();
//                             if (String.IsNullOrEmpty(choice))
//                             {
//                                 break;
//                             }
//                             else
//                             {



//                                 for (int i = 0; i < amount; i++)
//                                 {
//                                     availableChickenHouses[Int32.Parse(choice) - 1].AddResource(animals[i]);

//                                 }

//                                 for (int i = 0; i < amount; i++)
//                                 {
//                                     animals.Remove(animals[amount - i - 1]);

//                                 }
//                                 Console.WriteLine($"You have added {amount} Chickens to the chicken house!");
//                                 Console.WriteLine($"Press any key to continue");
//                                 Console.ReadLine();


//                             }
//                         }

//                         catch
//                         {
//                             Console.WriteLine("I Broke");
//                         }
//                         break;
//                     }
//                 }
//                 catch
//                 {

//                 }
//             }
//         }
//     }
// }