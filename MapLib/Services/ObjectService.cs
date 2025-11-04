using System.Runtime.InteropServices.JavaScript;
using MapLib.Core.Interfaces;
using MapLib.Core.Models.ObjectModel;
using MapLib.Object.Redis;

namespace MapLib.Services;

public class ObjectService(
    DataContext db
    ) : IObjectService
{
    public async Task<bool> CreateObject(int x, int y, ObjectType type)
    {
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
        return await db.GetObjectInZone(x, y, rad);
    }
}