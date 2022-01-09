using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Screen_Base : MonoBehaviour {

    private CanvasGroup _canvasGroup = null;
    // Start is called before the first frame update
    void Start() {
        _canvasGroup = GetComponent<CanvasGroup>();
    }
    public virtual void Open() {
        ScreenUtilities.ToggleCanvasGroup(_canvasGroup, true);
    }

    public virtual void Close() {
        ScreenUtilities.ToggleCanvasGroup(_canvasGroup, false);
    }
    public CanvasGroup GetCanvasGroup() {
        return _canvasGroup;
    }
  
}
