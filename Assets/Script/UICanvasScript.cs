
using UnityEngine;

public class UICanvasScript : MonoBehaviour {

    public GameObject uiCanvasScript;
    
    

    private void Start()
    {
        uiCanvasScript.SetActive(false);
    }


    public void Show()
    {
        uiCanvasScript.SetActive(true);
    }

    public void Hide()
    {
        uiCanvasScript.SetActive(false);
    }


}
