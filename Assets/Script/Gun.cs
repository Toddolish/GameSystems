using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GameObject bullet;
    public Transform spawnPoint;
    public KeyCode fireButton;
    void Start()
    {

    }
    
    void Update()
    {
        if (Input.GetKeyDown(fireButton))
        {
            //instanciate a new bullet from prefabs named "bullet"
            GameObject clone = Instantiate(bullet, transform.position, transform.rotation);
            //get the component from the new bullet
            Bullet newBullet = clone.GetComponent<Bullet>();
            //tell the bullet to fire()
            newBullet.Fire(transform.forward);
        }
    }
}
