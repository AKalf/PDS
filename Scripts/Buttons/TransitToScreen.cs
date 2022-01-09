
using UnityEngine;
using UnityEngine.UI;

public class TransitToScreen : MonoBehaviour{
    [SerializeField]
    private Screen_Base screenToOpen = null;

    private Button button = null;
    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(() =>Screen_Manager.OpenScreenAndCloseAllOthers(screenToOpen));
    }

}
