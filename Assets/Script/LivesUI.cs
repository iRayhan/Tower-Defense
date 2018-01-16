using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class LivesUI : MonoBehaviour {


    public TextMeshProUGUI livesText;
    

    void Update () {
        livesText.text = "Tank : " + (TankWaveSpawner.tankCounter).ToString();
	}
}
