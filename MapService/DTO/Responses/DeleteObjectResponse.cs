using MemoryPack;

namespace MapService.DTO.Responses;

[MemoryPackable]
public partial record DeleteObjectResponse
{
    public string ObjectId { get; set; }
}