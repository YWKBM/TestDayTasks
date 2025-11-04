using MapLib.Core.Interfaces;
using MapLib.Core.Models;
using MapLib.Core.Models.MapModel;
using MapLib.Core.Models.TerritoryModel;
using MapLib.Core.Models.TileModel;

namespace MapLib.Services;

public class MapService(MapProvider mapProvider) : IMapService
{
    private Map map = mapProvider.Instance;
    
    public Tile GetTile(int x, int y)
    {
        ValidateCoordinates(x, y);
        return map.Tile(x, y);
    }

    public TileType GetTileType(int x, int y)
    {
        ValidateCoordinates(x, y);
        return map.Tile(x, y).Type;
    }

    public int GetTerritoryId(int x, int y)
    { 
        ValidateCoordinates(x, y);
        return map.Tile(x, y).TerritoryId;
    }

    public Territory? GetTerritoryInfo(int id)
    {
        return map.GetTerritoryInfo(id);
    }
    
    private void ValidateCoordinates(int x, int y)
    {
        if (x < 0 || x >= 1000 || y < 0 || y >= 1000)
            throw new ArgumentOutOfRangeException($"Coordinates ({x}, {y}) are out of map bounds");
    }
}