using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions {
  public class ChooseDuckHouse {
    public static void CollectInput (Farm farm, Duck animal) {
      Utils.Clear ();

      var availableDuckHouses = farm.DuckHouses.Where(duckHome => duckHome.Animals.Count < duckHome.Capacity).ToList();

      if (availableDuckHouses.Count == 0)
      {
          Console.WriteLine("There are no available duck houses. \nPress return to go back to the main menu");
          Console.ReadLine();
      }
      else
      {
        for (int i = 0; i < availableDuckHouses.Count; i++) {
            Console.Write ($"{i + 1}. DuckHouse {availableDuckHouses[i].AnimalCount()} ");
            Console.WriteLine ();
        }

        Console.WriteLine ();

        // How can I output the type of animal chosen here?
        while(true)
        {
          Console.WriteLine ($"Place the duck where?");
          Console.Write ("> ");
            try
            {
              var choice = Console.ReadLine ();
              if (String.IsNullOrEmpty(choice))
              {
                break;
              }
              else
              {
                availableDuckHouses[Int32.Parse(choice) - 1].AddResource (animal);
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