using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    

    public float speed = 10f;
    public float health = 100;
    public int worth = 50;

    public float shootDistance = 0.5f;

    public GameObject deathEffect;

    private Transform target;
    private int wavePointIndex = 0;

    public float hitWaitTime = 0.3f;
    public float deadTime = 0.5f;

    private bool run = false;
    private bool hit = false;
    private bool dead = false;

    private Vector3 dir;
    private Vector3 move;

    private GameObject spawnPoint1;
    private GameObject spawnPoint2;
    private GameObject spawnPoint3;

    private bool way1, way2, way3 = false;

    //private Animator anim;





    private void Start()
    {
        //anim = GetComponent<Animator>();

        spawnPoint1 = GameObject.Find("SpawnPoint_1");
        spawnPoint2 = GameObject.Find("SpawnPoint_2");
        spawnPoint3 = GameObject.Find("SpawnPoint_3");


        if (transform.position.Equals(spawnPoint1.transform.position))
        {
            way1 = true;
            target = Waypoints1.points[0];
        }
        else if (transform.position.Equals(spawnPoint2.transform.position))
        {
            way2 = true;
            target = Waypoints2.points[0];
        }
        else if (transform.position.Equals(spawnPoint3.transform.position))
        {
            way3 = true;
            target = Waypoints3.points[0];
        }

        
    }





    private void Update()
    {
        dir = target.position - transform.position;

        
        transform.LookAt(target);


        /*
        if (hit == false)
        {
            
            if (anim.GetCurrentAnimatorStateInfo(0).IsName("isOnhit"))
            {
                anim.SetBool("isRunning", true);
            }
            

            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        }
        else
        {
            transform.Translate(dir.normalized * -Time.deltaTime, Space.World);
        }
        */

        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);





        if (Vector3.Distance(transform.position, target.position) <= shootDistance)
        {
            GetNextWaypoint();
        }


    }




    public void TakeDamage(float amount)
    {

        /*
        hit = true;
        
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("isRunning"))
        {
            anim.SetBool("isOnHit", true);
            //hit = false;
        }
        */

        health -= amount;

        if(health <= 0)
        {
            Die();
        }

    }






    private IEnumerator GetHit()
    {



        yield return new WaitForSecondsRealtime(hitWaitTime);

        hit = false;

    }








    private void Die()
    {
        dead = true;

        /*
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("isOnHit"))
        {
            anim.SetBool("isDead", true);
        }
        */

        PlayerStats.Money += worth;

        GameObject effect = Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(effect, 5f);

        Destroy(gameObject);

    }




    private void GetNextWaypoint()
    {

        if (way1)
        {
            if (wavePointIndex >= Waypoints1.points.Length - 1)
            {
                EndPath();
                return;
            }

            wavePointIndex++;
            target = Waypoints1.points[wavePointIndex];
        }

        else if (way2)
        {
            if (wavePointIndex >= Waypoints2.points.Length - 1)
            {
                EndPath();
                return;
            }

            wavePointIndex++;
            target = Waypoints2.points[wavePointIndex];
        }
        
        else if (way3)
        {
            if (wavePointIndex >= Waypoints3.points.Length - 1)
            {
                EndPath();
                return;
            }

            wavePointIndex++;
            target = Waypoints3.points[wavePointIndex];
        }

        
    }


    private void EndPath()
    {
        PlayerStats.life -= 0.1f;
        PlayerStats.Lives--;
        
        Destroy(gameObject);
    }


}
