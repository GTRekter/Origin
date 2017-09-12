using System.Xml.Serialization;
using System.Collections.Generic;
using System;

[Serializable()]
[XmlRoot("Configuration")]
public class Configuration
{
    [XmlArray("PageDimensions")] 
    [XmlArrayItem("Dimension", typeof(string))]
    public string[] PageDimensions { get; set; }

    [XmlArray("ItemLists")]
    [XmlArrayItem("ItemList", typeof(string))]
    public string[] ItemLists { get; set; }
}

[Serializable()]
public class ItemLists
{


}




//[XmlArray("Items")]
//[XmlArrayItem("Item", typeof(Item))]
//public List<Item> Items { get; set; }


//[Serializable()]
//public class Item
//{
//    [XmlAttribute(AttributeName = "Type")]
//    public string Type { get; set; }

//    [XmlArray("Properties")]
//    [XmlArrayItem("Property", typeof(Property))]
//    public List<Property> Properties { get; set; }

//}

//[Serializable()]
//public class Property
//{
//    [XmlAttribute(AttributeName = "Name")]
//    public string Name { get; set; }

//    [XmlArray("Visibilities")]
//    [XmlArrayItem("Visibility", typeof(Visibility))]
//    public List<Visibility> Visibilities { get; set; }

//}

//[Serializable()]
//public class Visibility
//{
//    [XmlAttribute(AttributeName = "Name")]
//    public string Name { get; set; }
//}



