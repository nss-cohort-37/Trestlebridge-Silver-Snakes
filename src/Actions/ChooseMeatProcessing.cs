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

      var meatProcessingFacilities = new List<IFacility<I>>();

      for (int i = 0; i < notEmptyGrazingFields.Count; i++)
      {
        // Console.Write($"{i + 1}. Grazing Field {notEmptyGrazingFields[i].AnimalCount()} ");
        // notEmptyGrazingFields[i].AnimalTypeCount();
        // Console.WriteLine();
        meatProcessingFacilities.Add(notEmptyGrazingFields[i]);
      }

      for (int i = 0; i < notEmptyChickenHouses.Count; i++)
      {
        Console.Write($"{i + 1}. Chicken House {notEmptyChickenHouses[i].AnimalCount()} ");
        notEmptyChickenHouses[i].AnimalCount();
        Console.WriteLine();
      }
      Console.ReadLine();
    }
  }
}