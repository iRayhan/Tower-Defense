using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tank : MonoBehaviour
{

    private Transform target;
    private Turret targetTurret;

    [Header("General")]

    public float range = 30f;

    [Header("Use Bullets (default)")]

    public GameObject bulletPrefab;
    public float fireRate = 1f;

    public float shootDistance = 10f;

    [Header("Laser")]

    public bool useLaser = false;
    public float damageOverTime = 0.3f;
    public LineRenderer lineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    [Header("Setup Fields")]

    public string enemyTag = "Turret";

    public Transform partToRotate;
    public float turnSpeed = 10f;

    public Transform firePoint;

    public int worth = 100;
    public Slider health;
    public float healthValue;
    public float speed = 10f;

    private Vector3 dir;
    private float fireCountdown = 0f;




    private void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        health.value = healthValue;

        if (useLaser)
        {
            lineRenderer.enabled = false;
            impactEffect.Stop();
            impactLight.enabled = false;
        }
    }



    private void UpdateTarget()
    {

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;


        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy <= shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }

        }


        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetTurret = target.GetComponent<Turret>();
        }
        else
        {
            target = null;
        }


    }




    private void Update()
    {
        if (target == null)
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

        if (Vector3.Distance(transform.position, target.position) > shootDistance)
        {
            transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        }
        else
        {
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



    }









    private void LockOnTarget()
    {
        dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

    }





    private void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        TankBullet bullet = bulletGO.GetComponent<TankBullet>();

        if (bullet != null)
        {
            bullet.Seek(target);
        }


    }



    private void Laser()
    {

        targetTurret.TakeDamage(damageOverTime * Time.deltaTime);

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
        PlayerStats.Money += worth;
        TankWaveSpawner.tankCounter--;

        if(TankWaveSpawner.tankCounter < 0)
        {
            TankWaveSpawner.tankCounter = 0;
        }
        print("Tank: " + TankWaveSpawner.tankCounter);

        Destroy(gameObject);

    }




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
