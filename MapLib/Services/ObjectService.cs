using System.Runtime.InteropServices.JavaScript;
using MapLib.Core.Interfaces;
using MapLib.Core.Models.ObjectModel;
using MapLib.Object.Redis;

namespace MapLib.Services;

public class ObjectService(
    DataContext db
    ) : IObjectService
{
    public async Task<string> CreateObject(int x, int y, ObjectType type)
    {
        ValidateCoordinates(x, y);

        var objectInfo = new ObjectInfo()
        {
            X = x,
            Y = y,
            Type = type,
        };

        return await db.CreateAsync(objectInfo);
    }

    public async Task<bool> DeleteObject(string objectId)
    {
        return await db.Delete(objectId);
    }

    public async Task<List<ObjectInfo>> GetObjects(int x, int y, int rad)
    {
        ValidateCoordinates(x, y);
        return await db.GetObjectInZone(x, y, rad);
    }
    
    private void ValidateCoordinates(int x, int y)
    {
        if (x < 0 || x >= 1000 || y < 0 || y >= 1000)
            throw new ArgumentOutOfRangeException($"Coordinates ({x}, {y}) are out of map bounds");
    }
}