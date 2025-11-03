namespace MapLib.Core.Models.ObjectModel;

public class Object
{
    public int Id { get; set; }
    
    public int X { get; set; }
    
    public int Y { get; set; }
    
    public ObjectType Type { get; set; }
}