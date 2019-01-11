using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler
{

    public bool GetInteractButton()
    {
        if (Input.GetButtonDown("Interact") == true)
        { return true; }
        return false;
    }

    public bool GetJumpButton()
    {
        if (Input.GetButtonDown("Jump") == true)
        { return true; }
        return false;
    }

    public float Move(float axis)
    {
        axis = Input.GetAxisRaw("Horizontal");
        return axis;
    }
}
