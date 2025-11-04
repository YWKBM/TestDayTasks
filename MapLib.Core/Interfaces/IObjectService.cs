using System.Runtime.InteropServices.JavaScript;
using MapLib.Core.Models.ObjectModel;

namespace MapLib.Core.Interfaces;

public interface IObjectService
{
    Task<bool> CreateObject(int x, int y, ObjectType type);

    Task<bool> DeleteObject(string objectId);

    Task<List<ObjectInfo>> GetObjects(int x, int y, int rad);
}