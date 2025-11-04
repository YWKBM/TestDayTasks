using MemoryPack;

namespace MapService.DTO.Requests;

[MemoryPackable]
public partial record PlaceObjectRequest
{
    public int X { get; set; }
    
    public int Y { get; set; }
    
    public int ObjectType { get; set; }
}