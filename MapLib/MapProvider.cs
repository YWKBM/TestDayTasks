using MapLib.Core.Models.MapModel;

namespace MapLib;

public class MapProvider
{
    private Map map = new Map();

    public Map Instance => map;
}