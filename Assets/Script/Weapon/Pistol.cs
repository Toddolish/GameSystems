﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : Weapon
{
    
    void Update()
    {
        
    }

    public override void Attack()
    {
        // Instanciate a new bullet from prefabs named "bullet"
        GameObject clone = Instantiate(projectile, spawnPoint.position, spawnPoint.rotation);

        // Get the component from the new bullet
        Bullet newBullet = clone.GetComponent<Bullet>();

        // Tell the bullet to fire()
        newBullet.Fire(transform.forward);
    }
}
