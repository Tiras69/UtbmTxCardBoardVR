using UnityEngine;
using System.Collections;
using System.Xml.Serialization;
using System.IO;

public static class MapSerializer {

    public static MapData Deserialize(string fileName)
    {
        MapData map = null;
        XmlSerializer xs = new XmlSerializer(typeof(MapData));
        
        using (StreamReader rd = new StreamReader(fileName))
        {
            map = xs.Deserialize(rd) as MapData;
        }
        
        return map;
    }
}
