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
    public static void CollectMeatInput(List<IMeatProducing> Animals)
    {




      Console.WriteLine("Which animal would you like to process?");

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
              // ChooseMeatProcessingFacility.CollectProcessingInput(farm);
              break;
            default: break;

          }
          break;

        }
      }
    }
  }
}