using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("PLAYER VARIABLES")]
    public bool rotateToMainCamera = false;
    public float moveSpeed;
    public Rigidbody rb;
    public float jumpHeight;
    public float rayDistance;

    [Header("WEAPON")]
    public Weapon currentWeapon;

    
    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }

    private void OnDrawGizmos()
    {
        Ray groundRay = new Ray(transform.position, Vector3.down);
        Gizmos.color = Color.red;
        Gizmos.DrawLine(groundRay.origin, groundRay.origin + groundRay.direction * rayDistance);
    }
    bool IsGrounded()
    {
        RaycastHit hit;
        Ray groundRay = new Ray(transform.position, Vector3.down);
        if (Physics.Raycast(groundRay, out hit, rayDistance))
        {
            return true; // Is gorunded
        }
        return false; // Not grounded
    }
    void Update()
    {
        Movement();
        // If fire button And weapon is allowed to fire
        if(Input.GetButtonDown("Fire1"))
        {
            // Fire the weapon
            currentWeapon.Attack();
        }
    }
    public void Movement()
    {
        float inputH = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float inputV = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 moveDir = new Vector3(inputH, 0f, inputV);
        
        Vector3 camEuler = Camera.main.transform.eulerAngles;

        if (rotateToMainCamera)
        {
            moveDir = Quaternion.AngleAxis(camEuler.y, Vector3.up) * moveDir;
        }

        Vector3 force = new Vector3(moveDir.x, rb.velocity.y, moveDir.z);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            // Jump up
            force.y = jumpHeight;
        }

        rb.velocity = force;
        
        Vector3 euler = Camera.main.transform.eulerAngles;

        Quaternion playerRotation = Quaternion.AngleAxis(camEuler.y, Vector3.up);
        Quaternion weaponRotation = Quaternion.AngleAxis(camEuler.x, Vector3.right);

        //currentWeapon.transform.localRotation = weaponRotation;
        transform.rotation = playerRotation;
    }

}
