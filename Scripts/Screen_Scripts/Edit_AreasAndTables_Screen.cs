using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Edit_AreasAndTables_Screen : Screen_Base
{

    [SerializeField]
    private GameObject tablePrefab = null;

    [SerializeField]
    private Dropdown areaSelectionDropdown= null;
    [SerializeField]
    private Dropdown tableColorDropdown = null;
    
    [SerializeField]
    private InputField areaNameInputField = null;
    [SerializeField]
    private InputField tableNameInputField = null;
    [SerializeField]
    private InputField newAreaNameInputField = null;
    [SerializeField]
    private InputField newTableNameInputField = null;

    [SerializeField]
    private Button addNewAreaButton = null;
    [SerializeField]
    private Button saveNewAreaButton = null;
    [SerializeField]
    private Button addNewTableButton = null;
    [SerializeField]
    private Button saveNewTableButton = null;

    [SerializeField]
    private Screen_Base newAreaScreen = null;
    [SerializeField]
    private Screen_Base newTableScreen  = null; 

    [SerializeField]
    private RectTransform tablesScrollViewContainer = null;

    private readonly Color[] availableColors = new Color[] {Color.black, Color.cyan, Color.green, Color.yellow, Color.blue };

    private Area_Item[] areas = null;
    private Table_Item[] areaTables = null;

    void Start() {
        FetchAreas();

        addNewAreaButton.onClick.AddListener(() => {
            newAreaNameInputField.text = "";
            Screen_Manager.OpenScreenAndCloseAllOthers(newAreaScreen);
        });
        saveNewAreaButton.onClick.AddListener(() => {
            if (string.IsNullOrEmpty(newAreaNameInputField.text) == false)
                Server_Database.AddArea(new Area_Item(newAreaNameInputField.text));
        });
        addNewTableButton.onClick.AddListener(() => {
            newTableNameInputField.text = "";
            Screen_Manager.OpenScreenAndCloseAllOthers(newTableScreen);
        });
        saveNewTableButton.onClick.AddListener(() => {
            if (string.IsNullOrEmpty(newTableNameInputField.text) == false)
                Server_Database.AddTable(new Table_Item(newTableNameInputField.text, areas[areaSelectionDropdown.value], availableColors[tableColorDropdown.value]));
        });
        InitialiseAreaSelectionDropdown();
        InitialiseTableColorsDropdown();
    }   
    private void FetchAreas() {
        areas = Server_Database.Areas.ToArray();
    }
    private void FetchAreaTables(Area_Item area) {
            areaTables = Server_Database.TablesPerArea[area].ToArray();
    }
    public void SetSelectedArea(int  value) {
        ScreenUtilities.DestroyChildren(tablesScrollViewContainer, () => {
            FetchAreaTables(areas[value]);
            foreach (Table_Item table in areaTables) {
                GameObject.Instantiate(tablePrefab, tablesScrollViewContainer).AddComponent<Table_Component>().TableItem = table;
            }
        });
    }

    private void InitialiseAreaSelectionDropdown() {
        areaSelectionDropdown.ClearOptions();
        foreach (Area_Item area in areas)
            areaSelectionDropdown.options.Add(new Dropdown.OptionData(area.Name));
        areaSelectionDropdown.onValueChanged.AddListener(SetSelectedArea);

    }
    private void InitialiseTableColorsDropdown() {
        tableColorDropdown.ClearOptions();
        foreach (Color color in availableColors)
            tableColorDropdown.options.Add(new Dropdown.OptionData(color.ToString()));
    }
  
}
