using UnityEngine;
using System.Collections.Generic;
using System.Xml.Serialization;

/// <summary>
/// global structure that save all the information about the place.
/// </summary>
[XmlRoot("Map")]
public class MapData{

    [XmlArray("Rooms")]
    [XmlArrayItem("Room")]
    public List<RoomData> rooms { get; set; }

}

/// <summary>
/// Structure that represents a room forthe global map.
/// note that every coordinates in the room must be 
/// clockwise in order to have the normal facing the center 
/// of the room.
/// </summary>
[XmlRoot("Room")]
public class RoomData
{

    [XmlArray("Coordinates")]
    [XmlArrayItem("Coordinate")]
    public List<CoordinateData> coordinates { get; set; }

}

/// <summary>
/// Represents the 2D Coordinates of a room in the map.
/// </summary>
[XmlRoot("Coordinate")]
public class CoordinateData
{

    [XmlAttribute("x")]
    public float x { get; set; }
    [XmlAttribute("y")]
    public float y { get; set; }
}