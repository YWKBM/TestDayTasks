using MemoryPack;

namespace MapService.DTO.Responses;

[MemoryPackable]
public partial record GetObjectsInAreaResponse
{
    public List<ObjectItem> Items { get; set; }
    
    [MemoryPackable]
    public partial record ObjectItem
    {
        public string Id { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public int Type { get; set; }
    }
}