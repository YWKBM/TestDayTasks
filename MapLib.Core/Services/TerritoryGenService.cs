using MapLib.Core.Models;

namespace MapLib.Core.Services;

public static class TerritoryGenService
{
    public static void GenerateTerritories(int count, Dictionary<int, Territory> territories, Tile[,] tiles)
    {
        // Генерация территорий. Простое разбиение на сетку
        int cols = (int)Math.Ceiling(Math.Sqrt(count));
        int rows = (int)Math.Ceiling((double)count / cols);
            
        int territoryWidth = 1000 / cols;
        int territoryHeight = 1000 / rows;
            
        int territoryId = 0;
            
        for (int row = 0; row < rows && territoryId < count; row++)
        {
            for (int col = 0; col < cols && territoryId < count; col++)
            {
                int x = col * territoryWidth;
                int y = row * territoryHeight;
                int width = (col == cols - 1) ? 1000 - x : territoryWidth;
                int height = (row == rows - 1) ? 1000 - y : territoryHeight;
                    
                GenerateTerritory(territoryId, x, y, width, height, territories, tiles);
                territoryId++;
            }
        }
    }

    private static void GenerateTerritory(int territoryId, int x, int y, int width, int height, 
        Dictionary<int, Territory> territories, Tile[,] tiles)
    {
        var territoryTiles = new List<Tile>();
        var random = new Random();
            
        for (int tileX = x; tileX < x + width; tileX++)
        {
            for (int tileY = y; tileY < y + height; tileY++)
            {
                // случайное распределение типов тайлов
                var tileType = random.Next(0, 100) < 70 ? TileType.Plane : TileType.Mountain;
                    
                tiles[tileX, tileY] = new Tile
                {
                    Type = tileType,
                    TerritoryId = territoryId,
                    X = tileX,
                    Y = tileY
                };
                    
                territoryTiles.Add(tiles[tileX, tileY]);
            }
        }
            
        var territory = new Territory(territoryId, x, y, width, height)
        {
            Tiles = territoryTiles.ToArray()
        };
            
        territories[territoryId] = territory;
    }
}

