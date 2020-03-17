using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;
using System.Linq;
using System.Collections.Generic;

namespace Trestlebridge.Actions
{
    public class ChooseMeatToProcess
    {
        public static void CollectMeatInput(GrazingField GrazingField)
        {
            Utils.Clear();

            Console.WriteLine("The following animals are in the Chicken House.\n");

            var animalGroups = GrazingField.AnimalTypeGroups();
            for (int i = 1; i < animalGroups.Count() + 1; i++)
            {
                Console.WriteLine($"{i}. {animalGroups[i - 1].Count()} {animalGroups[i - 1].Key}");
            }

            Console.WriteLine("\nWhich resource should be processed?");

            while (true)
            {
                var parsedChoice = Int32.Parse(Console.ReadLine()) - 1;


                if (parsedChoice < 0 || parsedChoice > animalGroups.Count() - 1)
                {
                    Console.WriteLine("Please enter a valid index range");
                }
                else
                {
                    Utils.Clear();
                    Console.WriteLine($"How many {animalGroups[parsedChoice].Key} should be processed?");
                    Console.Write("> ");
                    var parsedChoice2 = int.Parse(Console.ReadLine());
                    for (int i = 0; i < parsedChoice2; i++)
                    {
                        var selectedGroup = animalGroups[parsedChoice];
                        var selectedKey = selectedGroup.Key;
                        var foundAnimal = GrazingField.Animals.FirstOrDefault(animal => animal.Type == selectedKey);
                        GrazingField.Animals.Remove(foundAnimal);
                    }
                    break;
                }
            }
        }

        public static void CollectChickenInput(ChickenHouse Chickenhouse)
        {
            Utils.Clear();
            Console.WriteLine("The following animals are in the Chicken House.\n");
            Console.WriteLine($"1. {Chickenhouse.AnimalCount()}");
            Console.WriteLine("\nHow many Chickens should be processed?");
            Console.Write("> ");
            var parsedChoice = int.Parse(Console.ReadLine());
            while (true)
            {
                for (int i = 0; i < parsedChoice; i++)
                {
                    Chickenhouse.Animals.Remove(Chickenhouse.Animals[Chickenhouse.Animals.Count - i - 1]);
                }
                break;
            }
        }
    }
}