using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Base Variables")]
    public float speed;
    public int damage;
    public float knockbackDistance;
    public float travelTime;
    public GameObject impactPrefab;
    public ParticleSystem travelParticle;
    public Rigidbody rigid;

    void Update()
    {
    }

    public virtual void Bullet(Vector3 direction)
    {
        // Add a force in the given 'direction' variable and use impulse
        rigid.AddForce(direction * speed, ForceMode.Impulse);
    }

    public virtual void OnCollisionEnter(Collision collision)
    {
        // Get the Enemy component from it
        Enemy enemy = collision.gameObject.GetComponent<Enemy>();
        // If it is indeed an Enemy
        if (enemy)
        {
            // Deal damage to the Enemy
            //enemy.DealDamage(damage);
            // Destroy the bullet
            Destroy(gameObject);
        }
    }
}
