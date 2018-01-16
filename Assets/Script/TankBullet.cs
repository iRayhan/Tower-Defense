using UnityEngine;

public class TankBullet : MonoBehaviour
{

    private Transform target;
    public GameObject impactEffect;

    public string enemyTag = "Turret";

    public float speed = 70f;
    public float explosionRadius = 10f;

    public float damage = 0.2f;



    public void Seek(Transform _target)
    {
        target = _target;
    }



    void Update()
    {

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {

            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);

    }



    private void HitTarget()
    {

        GameObject effectIns = Instantiate(impactEffect, transform.position, transform.rotation);

        Destroy(effectIns, effectIns.GetComponent<AudioSource>().clip.length);

        if(explosionRadius > 0)
        {
            Explode();
        }
        else
        {
            Damage(target);
        }

        




        Destroy(gameObject);



    }




    private void Explode()
    {
        Collider[] collider = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider collide in collider)
        {
            if (collide.tag.Equals(enemyTag))
            {
                Damage(collide.transform);
            }
        }
    }



    private void Damage(Transform turret)
    {
        Turret t = turret.GetComponent<Turret>();

        if (t != null)
        {
            t.TakeDamage(damage);
        }


    }




    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }


}
