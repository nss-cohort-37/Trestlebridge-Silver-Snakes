using System;
using System.Linq;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Animals;

namespace Trestlebridge.Actions {
  public class ChooseChickenHouse {
    public static void CollectInput (Farm farm, Chicken animal) {
      Utils.Clear ();

      for (int i = 0; i < farm.ChickenHouses.Count; i++) {
        Console.Write ($"{i + 1}. Chicken House {farm.ChickenHouses[i].AnimalCount()} ");

        Console.WriteLine ();
      }

      Console.WriteLine ();

      // How can I output the type of animal chosen here?
      Console.WriteLine ($"Place the chicken where?");

      Console.Write ("> ");
      int choice = Int32.Parse (Console.ReadLine ()) - 1;

      farm.ChickenHouses[choice].AddResource (animal);

      /*
          Couldn't get this to work. Can you?
          Stretch goal. Only if the app is fully functional.
       */
      // farm.PurchaseResource<IGrazing>(animal, choice);

    }
  }
}