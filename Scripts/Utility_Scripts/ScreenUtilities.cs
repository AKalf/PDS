using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScreenUtilities{
    public static void ToggleCanvasGroup(CanvasGroup group, bool isOn) {
        if (isOn) {
            group.alpha = 1;
            group.blocksRaycasts = true;
            group.interactable = true;
            group.ignoreParentGroups = true;
        }
        else {
            group.alpha = 0;
            group.blocksRaycasts = false;
            group.interactable = false ;
        }
    }

    public static void DestroyChildren(Transform transform, Action callback) {
        while (transform.childCount > 0) { 
            MonoBehaviour.Destroy(transform.GetChild(0));
        }
        if (callback != null)
            callback.Invoke();
    }
}
