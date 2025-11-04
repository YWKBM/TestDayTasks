using MapLib.Core.Models.TerritoryModel;
using MemoryPack;

namespace MapService.DTO.Responses;

[MemoryPackable]
public partial class GetTerritoriesInAreaResponse
{
    public List<Territory> Territories { get; set; }
    
    [MemoryPackable]
    public partial record TerritoryItem
    {
        public int Id { get; set; }
        
        public BordersInfoItem BordersInfo { get; set; }
        
        [MemoryPackable]
        public partial record BordersInfoItem
        {
            public int OffsetX { get; set; }
            
            public int OffsetY { get; set; }
            
            public int Width { get; set; }
            
            public int Height { get; set; }
        }
    }
}

// public int Id { get; set; }
//     
// public BordersInfo BordersInfo { get; set; }