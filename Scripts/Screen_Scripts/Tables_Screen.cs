using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tables_Screen : Screen_Base {

    private static Tables_Screen instance = null;
    public static Tables_Screen Instance => instance;

    [SerializeField]
    private RectTransform scrollViewContent = null;

    [SerializeField]
    private GameObject tableItemPrefab = null;

    private void Awake() {
         instance = this;
    }
    public override void Open() {
        base.Open();
        SpawnItemsFromList(scrollViewContent);
    }
    private void SpawnItemsFromList(RectTransform container) {
        foreach (Table_Item item in FetchContents()) {
           GameObject.Instantiate(tableItemPrefab, container).AddComponent<Table_Component>().TableItem = item;
        }
    }

    private List<Table_Item> FetchContents() {
        return null;
    }

   
}
