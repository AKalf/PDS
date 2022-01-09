using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Screen_Manager 
{
    private static List<Screen_Base> OpenScreens = new List<Screen_Base>();

    public static void OpenScreenAndCloseAllOthers(Screen_Base screenToOpen) {
        if (screenToOpen == null) {
            Debug.LogError("Screen base to transit is null! ");
            return;
        }
            foreach (Screen_Base screen in OpenScreens) 
            screen.Close();
        OpenScreens.Clear();
        screenToOpen.Open();
        OpenScreens.Add(screenToOpen);
    }
    public static void OpenScreenAdditevely(Screen_Base screenToOpen) {
        screenToOpen.Open();
        if (OpenScreens.Contains(screenToOpen) == false)
            OpenScreens.Add(screenToOpen);
    }
}
