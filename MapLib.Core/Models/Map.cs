using MapLib.Core.Services;

namespace MapLib.Core.Models;

public class Map
{
    private const int WIDTH = 1000;
    private const int HEIGHT = 1000;
    private const int TERRITORY_COUNT = 87;
    
    private readonly Tile[,] tiles;
    private readonly Dictionary<int, Territory> territories;
    
    public Tile Tile(int x, int y) => tiles[x, y];
    
    public Territory? GetTerritoryInfo(int id)
    {
        return territories.TryGetValue(id, out var territory) ? territory : null;
    }
    
    public Map()
    {
        tiles = new Tile[WIDTH, HEIGHT];
        territories = new Dictionary<int, Territory>();
        TerritoryGenService.GenerateTerritories(TERRITORY_COUNT, territories, tiles);
    }
}