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

    public float Xaxis
    {
        get { return Input.GetAxisRaw("Horizontal"); }
    }

    public float Yaxis
    {
        get { return Input.GetAxisRaw("Down"); }
    }

}
