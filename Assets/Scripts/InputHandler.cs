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
    //interact button ^

    public bool GetJumpButtonUp()
    {
        if (Input.GetButtonUp("Jump") == true)
        { return true; }
        return false;
    }

    public bool GetJumpButton()
    {
        if (Input.GetButton("Jump") == true)
        { return true; }
        return false;
    }

    public bool GetJumpButtonDown()
    {
        if (Input.GetButtonDown("Jump") == true)
        { return true; }
        return false;
    }
    // jump button ^

    public float Move(float axis)
    {
        axis = Input.GetAxisRaw("Horizontal");
        return axis;
    }
}
