using System.Runtime.InteropServices.JavaScript;
using MapLib.Core.Models.ObjectModel;

namespace MapLib.Core.Interfaces;

public interface IObjectService
{
    bool CreateObject(int x, int y, ObjectType type);

    bool DeleteObject(int x, int y);

    List<JSType.Object> GetObjects(int x, int y, int rad);
}