using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    public Animator anim;

    public override void Interact()
    {
        // Toggle and Animate Door
        bool Open = anim.GetBool("open");
        anim.SetBool("open", !Open);
    }
}
