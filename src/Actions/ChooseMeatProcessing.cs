using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;
using System.Linq;
using System.Collections.Generic;

namespace Trestlebridge.Actions
{
  public class ChooseMeatProcessing
  {
    public static void CollectProcessingInput(Farm farm)
    {
      Utils.Clear();
      var notEmptyGrazingFields = farm.GrazingFields.Where(grazingField => grazingField.Animals.Count > 0).ToList();

      var notEmptyChickenHouses = farm.ChickenHouses.Where(chickenHouse => chickenHouse.Animals.Count > 0).ToList();

      var meatyGrazingFields = notEmptyGrazingFields.Where(grazingField =>
      {
        var allGoats = grazingField.Animals.All(animal => animal.Type == "Goat");
        return !allGoats;
      }).ToList();

      int indexCounter = meatyGrazingFields.Count;
      for (int i = 0; i < meatyGrazingFields.Count; i++)
      {
        Console.Write($"{i + 1}. Grazing Field {meatyGrazingFields[i].AnimalCount()} ");
        meatyGrazingFields[i].AnimalTypeCount();
        Console.WriteLine();
      }

      for (int i = 0; i < notEmptyChickenHouses.Count; i++)
      {
        Console.Write($"{i + 1 + indexCounter}. Chicken House {notEmptyChickenHouses[i].AnimalCount()} ");
        notEmptyChickenHouses[i].AnimalCount();
        Console.WriteLine();
      }
      Console.ReadLine();
    }
  }
}