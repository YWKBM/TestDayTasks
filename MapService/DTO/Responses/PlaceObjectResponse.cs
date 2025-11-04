using MemoryPack;

namespace MapService.DTO.Responses;

[MemoryPackable]
public partial record PlaceObjectResponse
{
    public string ObjectId { get; set; }
    
    public int ObjectType { get; set; }
}