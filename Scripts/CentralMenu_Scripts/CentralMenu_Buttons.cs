using UnityEngine;
using UnityEngine.UI;

public class CentralMenu_Buttons : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField]
    private Button catalogManagerButton = null;
    [SerializeField]
    private Button clientViewButton = null;
    [Header("Panels")]
    [SerializeField]
    private CanvasGroup catalogManagerPanel = null;
    [SerializeField]
    private CanvasGroup clientViewPanel = null;

    // Start is called before the first frame update
    void Start()
    {
        catalogManagerButton.onClick.AddListener(() => ToggleViews(true));
        clientViewButton.onClick.AddListener(() => ToggleViews(false));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ToggleViews(bool isCatalog) {
        ScreenUtilities.ToggleCanvasGroup(catalogManagerPanel, isCatalog);
        ScreenUtilities.ToggleCanvasGroup(clientViewPanel, !isCatalog);
    }
}
