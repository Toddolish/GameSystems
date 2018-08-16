using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public Rigidbody rb;

    public float jumpHeight;

    public float rayDistance;

    
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
            return true; // is gorunded
        }
        return false; // not grounded
    }
    void Update()
    {
        Movement();
    }
    public void Movement()
    {
        float inputH = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        float inputV = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;

        Vector3 moveDir = new Vector3(inputH, 0f, inputV);
        Vector3 force = new Vector3(moveDir.x, rb.velocity.y, moveDir.z);

        
        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded())
        {
            // jump up
            force.y = jumpHeight;
        }

        rb.velocity = force;

        if(moveDir.magnitude > 0)
        {
            //rotate player to move direction
            transform.rotation = Quaternion.LookRotation(moveDir);
        }
    }
}
