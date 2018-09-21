using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public PlayerController player;
    private int weaponIndex = 0;

    private void Start()
    {
        // Select the first weapon
        player.SelectWeapon(0);
    }

    void Update()
    {
        WeaponSwitch();
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");
        player.Move(inputH, inputV);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            player.Jump();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            player.Attack();
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            player.Interact();
        }
    }

    void WeaponSwitch()
    {
        int currentIndex = weaponIndex;

        // If Q is pressed && weaponIndex > 0
        if(Input.GetKeyDown(KeyCode.Q) && weaponIndex > 0)
        {
            // decrement current index
            currentIndex--;
        }
        //If E is pressed && weaponIndex <= Length
        if (Input.GetKeyDown(KeyCode.E) && weaponIndex <= player.weapons.Length)
        {
            // increment current index
            currentIndex++;
        }
        weaponIndex = currentIndex;
        // Select wepaonIndex
        player.SelectWeapon(weaponIndex);
    }
}
