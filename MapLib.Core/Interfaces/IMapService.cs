using MapLib.Core.Models;

namespace MapLib.Core.Interfaces;

public interface IMapService
{
    Tile GetTile(int x, int y);
    
    TileType GetTileType(int x, int y);
    
    int GetTerritoryId(int x, int y);

    Territory? GetTerritoryInfo(int id);
}