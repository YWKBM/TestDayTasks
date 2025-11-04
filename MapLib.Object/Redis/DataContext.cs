using System.Text.Json;
using MapLib.Core.Models.ObjectModel;
using StackExchange.Redis;

namespace MapLib.Object.Redis;

public class DataContext
{
    private readonly IConnectionMultiplexer redis;
    private readonly IDatabase db;
    
    private const string ObjectsKeyPrefix = "objects:";
    private const string GeoIndexKey = "geo:objects";
    
    public DataContext(IConnectionMultiplexer redis)
    {
        this.redis = redis;
        db = redis.GetDatabase();
    }

    public async Task<bool> CreateAsync(ObjectInfo objectInfo)
    {
        if (string.IsNullOrEmpty(objectInfo.Id))
        {
            objectInfo.Id = Guid.NewGuid().ToString();
        }

        var key = GetObjectKey(objectInfo.Id);
        var json = JsonSerializer.Serialize(objectInfo);
        
        var trans = db.CreateTransaction();

        var set = trans.SetAddAsync(key, json);

        var geo = trans.GeoAddAsync(
            GeoIndexKey,
            NormalizeToLongitude(objectInfo.X),
            NormalizeToLatitude(objectInfo.Y),
            objectInfo.Id
        );

        await trans.ExecuteAsync();

        return true;
    }
    
    public async Task<bool> Delete(string objectId)
    {
        var key = GetObjectKey(objectId);
        
        var json = await db.StringGetAsync(key);
        if (string.IsNullOrEmpty(json)) return false;
        
        var obj = JsonSerializer.Deserialize<ObjectInfo>(json);
        if (obj == null) return false;
        
        var trans = db.CreateTransaction();
        
        var del = trans.KeyDeleteAsync(key);
        var geoDel = trans.GeoRemoveAsync(GeoIndexKey, objectId);
        var typeDel = trans.SetRemoveAsync( 
            $"objects:index:type:{obj.Type}", 
            objectId);

        await trans.ExecuteAsync();

        return true;
    }

    public async Task<List<ObjectInfo>> GetObjectInZone(int x, int y, int rad)
    {
        var results = await db.GeoRadiusAsync(
            GeoIndexKey,
            NormalizeToLongitude(x),
            NormalizeToLatitude(y),
            rad / 111.0,
            GeoUnit.Kilometers);
        
        var objects = new List<ObjectInfo>();
        foreach (var result in results)
        {
            var obj = await GetByIdAsync(result.Member!);
            if (obj != null)
                objects.Add(obj);
        }

        return objects;
    }
    
    public async Task<ObjectInfo?> GetByIdAsync(string objectId)
    {
        var key = GetObjectKey(objectId);
        var json = await db.StringGetAsync(key);
        
        if (json.IsNullOrEmpty)
            return null;
        
        return JsonSerializer.Deserialize<ObjectInfo>(json!);
    }

    private string GetObjectKey(string objectId) => $"{ObjectsKeyPrefix}{objectId}";
    
    private double NormalizeToLongitude(int x) => (x / 1000.0) * 360.0 - 180.0;
    private double NormalizeToLatitude(int y) => (y / 1000.0) * 180.0 - 90.0;
}