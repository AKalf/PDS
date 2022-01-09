using System;
using UnityEngine;

[Serializable]
public struct Table_Item  {
    public string Name { get; set; }
    public Area_Item Area { get; set; }
    public Color TableColor { get; set; }
    public float PosX { get; set; }
    public float PosY { get; set; }
    public float PosZ { get; set; }

    public Table_Item(string name,Area_Item area, Color color) {
        Name = name;
        Area = area;
        TableColor = color;
        PosX = 0;
        PosY = 0;
        PosZ = 0;
    }
}
[Serializable]
public struct Product_Item  {
    public string Name { get; set; }
    public ProductCategory_Item Category { get; set; }
    public AdditionsList_Item Additions { get; set; }

    public Product_Item (string name, ProductCategory_Item category, AdditionsList_Item additions){ 
        Name = name;
        Category = category;
        Additions = additions;
    }
}
[Serializable]
public struct Catalog_Item  {
    public string Name { get; set; }
}
[Serializable]
public struct Area_Item  {
    public string Name { get; set; }
    public Area_Item(string name) { 
        Name = name;
    }
}
