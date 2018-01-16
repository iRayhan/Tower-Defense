
using UnityEngine;
using UnityEngine.UI;

public class LifeUIScript : MonoBehaviour {
    public Slider life;

    private void Start()
    {
        life.value = PlayerStats.life;
    }

    private void Update()
    {
        life.value = PlayerStats.life;
    }

}
