using System;
using System.Collections.Generic;
using Trestlebridge.Interfaces;

namespace Trestlebridge.Models.Facilities
{
  public class PlowingField
  {

    public void AddResource(IGrazing animal)
    {
      // TODO: implement this...
      throw new NotImplementedException();
    }

    public void AddResource(List<IGrazing> animals)
    {
      // TODO: implement this...
      throw new NotImplementedException();
    }
    private int _capacity = 13;

    public double Capacity
    {
      get
      {
        return _capacity;
      }
    }
  }
}