using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions
{
    public class ChooseGrazingField
    {
        public static void CollectInput(Farm farm, IGrazing animal)
        {
            Utils.Clear();

            var availableGrazingFields = farm.GrazingFields.Where(grazingField => grazingField.Animals.Count < grazingField.Capacity).ToList();

            if (availableGrazingFields.Count == 0)
            {
                Console.WriteLine("There are no available grazing fields. \nPress return to go back to the main menu");
                Console.ReadLine();
            }
            else
            {
                for (int i = 0; i < availableGrazingFields.Count; i++)
                {
                        Console.Write($"{i + 1}. Grazing Field {availableGrazingFields[i].AnimalCount()} ");
                        availableGrazingFields[i].AnimalTypeCount();
                        Console.WriteLine();
                }

                Console.WriteLine();

                // How can I output the type of animal chosen here?
                
                while(true)
                {
                    Console.WriteLine($"Place the animal where? Or hit return to exit");
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
                            availableGrazingFields[Int32.Parse(choice) - 1].AddResource(animal);
                            break;
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