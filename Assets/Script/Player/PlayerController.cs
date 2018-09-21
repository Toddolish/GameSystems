using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    #region Player Variables
    [Header("PLAYER VARIABLES")]
    public bool rotateToMainCamera = false;
    public float moveSpeed;
    public Rigidbody rb;
    public float jumpHeight;
    public float rayDistance;
    private Vector3 moveDir;
    public bool isJumping;
    private Interactable interactObject;
    #endregion
    #region Weapon Variables
    [Header("WEAPON")]
    public Weapon currentWeapon;
    public bool rotateWeapon = false;
    public Weapon[] weapons;
    #endregion

    void Start()
    {
        rb.GetComponent<Rigidbody>();
    }
    private void OnTriggerEnter(Collider other)
    {
        interactObject = other.GetComponent<Interactable>();   
    }
    private void OnTriggerExit(Collider other)
    {
        interactObject = null;
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
    }
    public void Movement()
    {
        Vector3 camEuler = Camera.main.transform.eulerAngles;

        if (rotateToMainCamera)
        {
            moveDir = Quaternion.AngleAxis(camEuler.y, Vector3.up) * moveDir;
        }

        Vector3 force = new Vector3(moveDir.x, rb.velocity.y, moveDir.z);

        if (isJumping && IsGrounded())
        {
            // Jump up
            force.y = jumpHeight;
            isJumping = false;
        }

        rb.velocity = force;
        
        Vector3 euler = Camera.main.transform.eulerAngles;

        Quaternion playerRotation = Quaternion.AngleAxis(camEuler.y, Vector3.up);
        transform.rotation = playerRotation;

        if (rotateWeapon)
        {
            Quaternion weaponRotation = Quaternion.AngleAxis(camEuler.x, Vector3.right);
            currentWeapon.transform.localRotation = weaponRotation;
        }
    }
    public void DisableAllWeapons()
    {
        // Loop through every weapon
        foreach (Weapon weapon in weapons)
        {
            // Deactivate weapon's gameObject
            weapon.gameObject.SetActive(false);
        }
        // Select s and switches out the current weapon
    }
    public void SelectWeapon(int index)
    {
        // Check index is within range of weapons array
        if (index < 0 || index >= weapons.Length)
            return;

        DisableAllWeapons();

        // Enable weapon at index
        weapons[index].gameObject.SetActive(true);

        //set the currentWepaon
        currentWeapon = weapons[index];
    }
    public void Move(float inputH, float inputV)
    {
        moveDir = new Vector3(inputH, 0f, inputV) * Time.deltaTime;
        moveDir *= moveSpeed;
    }
    public void Attack()
    {
        currentWeapon.Attack();
    }
    public void Jump()
    {
        isJumping = true;
    }
    public void Interact()
    {
        // If interactable is found
        if(interactObject)
        {
            // Run interact
            interactObject.Interact();
        }
    }
}
