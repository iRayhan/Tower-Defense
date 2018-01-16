using System.Collections;
using UnityEngine;

public class TankWaveSpawner : MonoBehaviour
{

    public GameObject tankPrefabA;
    public GameObject tankPrefabB;
    public GameObject tankPrefabC;

    public GameObject spawnPoint1;
    public GameObject spawnPoint2;
    public GameObject spawnPoint3;
    public GameObject spawnPoint4;
    public GameObject spawnPoint5;
    public GameObject spawnPoint6;
    public GameObject spawnPoint7;



    public float timeBetweenWaves = 2f;
    public int tankLimit = 5;

    private float countdown;

    public static float tankCounter = 0;


    
    private void Update()
    {
        if (countdown <= 0f)
        {
            SpawnWave();
            countdown = timeBetweenWaves + tankCounter;
        }

        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);

        //waveCountdownTimer.text = string.Format("{0:00.00}", countdown);

    }
    



    private void SpawnWave()
    {

        

        if( tankCounter >= 0 && tankCounter < tankLimit )
        {
            SpawnTank();
        }

        

    }
    



    private void SpawnTank()
    {

        int rand = Random.Range(0, 3);

        int spawnIndex = Random.Range(-20, 20);



        if (spawnIndex >= -20 && spawnIndex < -15)
        {


            if (rand == 0)
            {
                Instantiate(tankPrefabA, spawnPoint1.transform.position, spawnPoint1.transform.rotation);
            }
            else if (rand == 1)
            {
                Instantiate(tankPrefabB, spawnPoint1.transform.position, spawnPoint1.transform.rotation);
            }
            else
            {
                Instantiate(tankPrefabC, spawnPoint1.transform.position, spawnPoint1.transform.rotation);
            }

        }

        else if (spawnIndex >= -15 && spawnIndex < -10)
        {
            if (rand == 0)
            {
                Instantiate(tankPrefabA, spawnPoint2.transform.position, spawnPoint2.transform.rotation);
            }
            else if (rand == 1)
            {
                Instantiate(tankPrefabB, spawnPoint2.transform.position, spawnPoint2.transform.rotation);
            }
            else
            {
                Instantiate(tankPrefabC, spawnPoint2.transform.position, spawnPoint2.transform.rotation);
            }


        }

        else if (spawnIndex >= -10 && spawnIndex < -5)
        {
            if (rand == 0)
            {
                Instantiate(tankPrefabA, spawnPoint3.transform.position, spawnPoint3.transform.rotation);
            }
            else if (rand == 1)
            {
                Instantiate(tankPrefabB, spawnPoint3.transform.position, spawnPoint3.transform.rotation);
            }
            else
            {
                Instantiate(tankPrefabC, spawnPoint3.transform.position, spawnPoint3.transform.rotation);
            }


        }

        else if (spawnIndex >= 0 && spawnIndex < 5)
        {
            if (rand == 0)
            {
                Instantiate(tankPrefabA, spawnPoint4.transform.position, spawnPoint4.transform.rotation);
            }
            else if (rand == 1)
            {
                Instantiate(tankPrefabB, spawnPoint4.transform.position, spawnPoint4.transform.rotation);
            }
            else
            {
                Instantiate(tankPrefabC, spawnPoint4.transform.position, spawnPoint4.transform.rotation);
            }


        }

        else if (spawnIndex >= 5 && spawnIndex < 10)
        {

            if (rand == 0)
            {
                Instantiate(tankPrefabA, spawnPoint5.transform.position, spawnPoint5.transform.rotation);
            }
            else if (rand == 1)
            {
                Instantiate(tankPrefabB, spawnPoint5.transform.position, spawnPoint5.transform.rotation);
            }
            else
            {
                Instantiate(tankPrefabC, spawnPoint5.transform.position, spawnPoint5.transform.rotation);
            }

        }

        else if (spawnIndex >= 10 && spawnIndex < 15)
        {

            if (rand == 0)
            {
                Instantiate(tankPrefabA, spawnPoint6.transform.position, spawnPoint6.transform.rotation);
            }
            else if (rand == 1)
            {
                Instantiate(tankPrefabB, spawnPoint6.transform.position, spawnPoint6.transform.rotation);
            }
            else
            {
                Instantiate(tankPrefabC, spawnPoint6.transform.position, spawnPoint6.transform.rotation);
            }

        }

        else if (spawnIndex >= 15 && spawnIndex < 20)
        {
            if (rand == 0)
            {
                Instantiate(tankPrefabA, spawnPoint7.transform.position, spawnPoint7.transform.rotation);
            }
            else if (rand == 1)
            {
                Instantiate(tankPrefabB, spawnPoint7.transform.position, spawnPoint7.transform.rotation);
            }
            else
            {
                Instantiate(tankPrefabC, spawnPoint7.transform.position, spawnPoint7.transform.rotation);
            }

        }



        tankCounter++;


    }


}
