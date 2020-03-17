using System;
using Trestlebridge.Interfaces;
using Trestlebridge.Models;
using Trestlebridge.Models.Facilities;

namespace Trestlebridge.Actions
{
  public class Processing
  {
    public static void CollectInput(Farm farm)
    {
      Console.WriteLine("1. Meat Processor");

      while (true)
      {
        var choice = Console.ReadLine();

        if (Int32.Parse(choice) < 1 || Int32.Parse(choice) > 3)
        {
          Console.WriteLine("Please enter a valid index range");
        }
        else
        {
          switch (Int32.Parse(choice))
          {
            case 1:
              ChooseMeatProcessingFacility.CollectProcessingInput(farm);
              break;
            default: break;

          }
          break;

        }
      }
    }
  }
}