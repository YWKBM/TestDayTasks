using System.Runtime.InteropServices.JavaScript;
using MapLib.Core.Interfaces;
using MapLib.Core.Models.ObjectModel;

namespace MapLib.Services;

public class ObjectService : IObjectService
{
    public bool CreateObject(int x, int y, ObjectType type)
    {
        throw new NotImplementedException();
    }

    public bool DeleteObject(int x, int y)
    {
        throw new NotImplementedException();
    }

    public List<JSType.Object> GetObjects(int x, int y, int rad)
    {
        throw new NotImplementedException();
    }
}