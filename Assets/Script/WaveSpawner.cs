using System.Collections;
using UnityEngine;
using TMPro;

public class WaveSpawner : MonoBehaviour {

    public Transform enemyPrefabA;
    public Transform enemyPrefabB;
    public Transform enemyPrefabC;

    public Transform spawnPoint1;
    public Transform spawnPoint2;
    public Transform spawnPoint3;


    public float timeBetweenWaves = 10f;
    public float gapBetweenEnemies = 5f;
    public int waveIndex = 0;

    public TextMeshProUGUI waveCountdownTimer;

    private float countdown;
    

    

    



    private void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves+waveIndex;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        waveCountdownTimer.text = string.Format("{0:00.00}", countdown);

    }



    private IEnumerator SpawnWave()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();

            yield return new WaitForSeconds(gapBetweenEnemies);
        }

        

        yield return null;

    }



    private void SpawnEnemy()
    {
        int rand = Random.Range(0, 3);

        int spawnIndex = Random.Range(-10, 5);

        if(spawnIndex >= -10 && spawnIndex < -5)
        {
            if (rand == 0)
            {
                Instantiate(enemyPrefabA, spawnPoint1.position, spawnPoint1.rotation);
            }
            else if (rand == 1)
            {
                Instantiate(enemyPrefabB, spawnPoint1.position, spawnPoint1.rotation);
            }
            else
            {
                Instantiate(enemyPrefabC, spawnPoint1.position, spawnPoint1.rotation);
            }
        }

        else if(spawnIndex >= -5 && spawnIndex < 0)
        {
            if (rand == 0)
            {
                Instantiate(enemyPrefabA, spawnPoint2.position, spawnPoint2.rotation);
            }
            else if (rand == 1)
            {
                Instantiate(enemyPrefabB, spawnPoint2.position, spawnPoint2.rotation);
            }
            else
            {
                Instantiate(enemyPrefabC, spawnPoint2.position, spawnPoint2.rotation);
            }
        }
        else
        {
            if (rand == 0)
            {
                Instantiate(enemyPrefabA, spawnPoint3.position, spawnPoint3.rotation);
            }
            else if (rand == 1)
            {
                Instantiate(enemyPrefabB, spawnPoint3.position, spawnPoint3.rotation);
            }
            else
            {
                Instantiate(enemyPrefabC, spawnPoint3.position, spawnPoint3.rotation);
            }
        }


        


        
    }


}
