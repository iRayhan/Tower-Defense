using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    private bool gameOver = false;

	void Update () {

        if (gameOver)
        {
            return;
        }

        if(PlayerStats.Lives <= 0)
        {
            EndGame();
        }
		
	}

    private void EndGame()
    {
        print("GameOver");

        gameOver = true;
    }
}
