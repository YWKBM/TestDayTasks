using MemoryPack;

namespace MapService.DTO.Requests;

[MemoryPackable]
public partial class GetTerritoriesInAreaRequest
{
    public int X1 { get; set; }
    
    public int X2 { get; set; }
    
    public int Y1 { get; set; }
    
    public int Y2 { get; set; }
}
