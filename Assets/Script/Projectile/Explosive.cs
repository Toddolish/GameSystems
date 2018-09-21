using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : Projectile
{
    [Header("Explosive Variables")]
    public float damageRadius = 5f;
    
    void Update()
    {

    }

    public override void OnCollisionEnter(Collision collision)
    {
        Effects();
        Explode();
    }
    void Explode()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, damageRadius);
        foreach(var hit in hits)
        {
            Destroy(this.gameObject);
            Enemy e = hit.GetComponent<Enemy>();
            if(e)
            {
                //Note(Manny): you can calculate falloff damage here
                //e.DealDamage(damage);
            }
        }
    }
    void Effects()
    {
        Instantiate(impactPrefab, transform.position, transform.rotation);
    }
}
