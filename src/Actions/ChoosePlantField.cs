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
        for (int i = 0; i < farm.NaturalFields.Count; i++)
        {
          Console.Write($"{i + 1}. Natural Field {farm.NaturalFields[i].PlantCount()} ");
          farm.NaturalFields[i].PlantTypeCount();
          Console.WriteLine();

        }

      }
      static void PlowedFieldsPrint(Farm farm)
      {
        for (int i = 0; i < farm.PlowedFields.Count; i++)
        {
          Console.Write($"{i + 1}. Plowed Field {farm.PlowedFields[i].PlantCount()} ");
          farm.PlowedFields[i].PlantTypeCount();
          Console.WriteLine();
        }
      }
      static void FieldListForSunflowers(Farm farm)
      {
        int indexCounter = farm.NaturalFields.Count;
        for (int i = 0; i < farm.NaturalFields.Count; i++)
        {
          Console.Write($"{i + 1}. Natural Field {farm.NaturalFields[i].PlantCount()} ");
          farm.NaturalFields[i].PlantTypeCount();
          Console.WriteLine();

        }

        for (int i = 0; i < farm.PlowedFields.Count; i++)
        {
          Console.Write($"{i + 1 + indexCounter}. Plowed Field {farm.PlowedFields[i].PlantCount()} ");
          farm.PlowedFields[i].PlantTypeCount();
          Console.WriteLine();
        }

      }
      while (true)
      {

        if (fieldTypeNum == 1)
        {
          if (farm.PlowedFields.Count == 0)
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
          if (farm.NaturalFields.Count == 0)
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
          if (farm.NaturalFields.Count == 0 && farm.PlowedFields.Count == 0)
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