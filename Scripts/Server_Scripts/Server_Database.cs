using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Server_Database {

    private Server_Database() {
        InitialiseTablesPerArea();
    }

    private static Server_Database instance;
    public static Server_Database Instance { get { if (instance == null) instance = new Server_Database(); return instance; } }

    private void InitialiseTablesPerArea() {
        foreach (Table_Item tableItem in tables) {
            if (TablesPerArea.ContainsKey(tableItem.Area) == false)
                TablesPerArea.Add(tableItem.Area, new List<Table_Item>() { tableItem });
            else if (TablesPerArea[tableItem.Area].Contains(tableItem) == false)
                TablesPerArea[tableItem.Area].Add(tableItem);
        }
    }

    [SerializeField]
    private List<Table_Item> tables = new List<Table_Item>();
    public static Dictionary<Area_Item, List<Table_Item>> TablesPerArea = null;
    public static List<Table_Item> GetTablesForArea(Area_Item area) {
        if (TablesPerArea == null) {
            TablesPerArea = new Dictionary<Area_Item, List<Table_Item>>();
            Instance.InitialiseTablesPerArea();
        }
        return TablesPerArea[area];
    }
    [SerializeField]
    private List<Area_Item> areas = new List<Area_Item>();
    public static List<Area_Item> Areas => Instance.areas;


    public static void AddTable(Table_Item item) { 
        Instance.tables.Add(item);  
    }
    public static void AddArea(Area_Item newArea) { 
        Instance.areas.Add(newArea);
    }
}
