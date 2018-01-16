using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour {

    private Transform target;

    private Enemy targetEnemy;
    private Tank targetTank;

    private bool isTank = false;

    [Header("General")]

    public float range = 15f;

    [Header("Use Bullets (default)")]

    public GameObject bulletPrefab;
    public float fireRate = 1f;

    [Header("Laser")]

    public bool useLaser = false;
    public float damageOverTime = 0.2f;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    [Header("Setup Fields")]

   
    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public Transform firePoint;


    public Slider  health;
    public float healthValue;


    private float fireCountdown = 0f;





    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        health.value = healthValue;
    }



    private void UpdateTarget()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if(distanceToEnemy <= shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

        }


        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;

            if (target.GetComponent<Enemy>())
            {
                isTank = false;
                targetEnemy = target.GetComponent<Enemy>();
            }
            else 
            {
                isTank = true;
                targetTank = target.GetComponent<Tank>();
            }

            
        }
        else
        {
            target = null;
        }


    }




    private void Update()
    {
        if(target == null)
        {

            if (useLaser)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                    impactEffect.Stop();
                    impactLight.enabled = false;
                }
            }

            return;

        }


        LockOnTarget();



        if (useLaser)
        {
            Laser();
        }
        else
        {
            if (fireCountdown <= 0f)
            {
                Shoot();
                fireCountdown = 1f / fireRate;

            }

            fireCountdown -= Time.deltaTime;
        }

        

    }




    private void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    }





    private void Shoot()
    {
        GameObject bulletGO = (GameObject) Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet != null)
        {
            bullet.Seek(target);
        }

        
    }



    private void Laser()
    {

        if (isTank)
        {
            targetTank.TakeDamage(damageOverTime * Time.deltaTime);
        }
        else
        {
            targetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        }

        

        if (!lineRenderer.enabled)
        {
            lineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, target.position);

        Vector3 dir = firePoint.position - target.position;

        impactEffect.transform.position = target.position + dir.normalized;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);


    }



    public void TakeDamage(float amount)
    {

        health.value -= amount;

        if (health.value <= 0)
        {
            Die();
        }

    }



    private void Die()
    {

        Destroy(gameObject);

    }




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
