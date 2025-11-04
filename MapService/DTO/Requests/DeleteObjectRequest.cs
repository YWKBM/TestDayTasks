using MemoryPack;

namespace MapService.DTO.Requests;

[MemoryPackable]
public partial record DeleteObjectRequest
{
    public string ObjectId { get; set; }
}