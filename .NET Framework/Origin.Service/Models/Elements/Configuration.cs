using System.Xml.Serialization;
using System.Collections.Generic;
using System;

[Serializable()]
[XmlRoot("Configuration")]
public class Configuration
{
    [XmlElement(ElementName = "Date")]
    public Date Date { get; set; }

    [XmlElement(ElementName = "ItemLists")]
    public ItemListsConfiguration ItemLists { get; set; }

    [XmlArray("ItemDetails")]
    [XmlArrayItem("ItemDetail", typeof(ItemDetails))]
    public List<ItemDetails> ItemDetails { get; set; }
}

[Serializable()]
public class Date
{
    [XmlAttribute(AttributeName = "Format")]
    public string Format { get; set; }

}


[Serializable()]
public class ItemListsConfiguration
{
    [XmlAttribute(AttributeName = "DefaultItemTypeOriginId")]
    public string DefaultItemTypeOriginId { get; set; }

    [XmlArray("PageDimensions")]
    [XmlArrayItem("Dimension", typeof(string))]
    public string[] PageDimensions { get; set; }

    [XmlArray("ItemLists")]
    [XmlArrayItem("ItemList", typeof(ItemList))]
    public List<ItemList> ItemLists { get; set; }
}

[Serializable()]
public class ItemList
{
    [XmlAttribute(AttributeName = "ItemTypeOriginId")]
    public string ItemTypeOriginId { get; set; }

    [XmlArray("VisibleFields")]
    [XmlArrayItem("VisibleField", typeof(VisibleField))]
    public List<VisibleField> VisibleFields { get; set; }

}

[Serializable()]
public class ItemDetails
{
    [XmlAttribute(AttributeName = "ItemTypeOriginId")]
    public string ItemTypeOriginId { get; set; }

    [XmlArray("VisibleFields")]
    [XmlArrayItem("VisibleField", typeof(VisibleField))]
    public List<VisibleField> VisibleFields { get; set; }

}

[Serializable()]
public class VisibleField
{
    [XmlAttribute(AttributeName = "Name")]
    public string Name { get; set; }
    
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



