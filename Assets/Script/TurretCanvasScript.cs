using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretCanvasScript : MonoBehaviour {

    public GameObject TurretCanvas;

    private int counter = 0;



    private void Start()
    {
        TurretCanvas.SetActive(true);
    }


    public void ShowOrHide()
    {

        if(counter % 2 == 0)
        {
            TurretCanvas.SetActive(true);
        }
        else
        {
            TurretCanvas.SetActive(false);
        }

        counter++;
    }

}
