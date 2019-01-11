using UnityEngine;

public class InputHandler
{
    private float axis;
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

    public float xAxis
    {
        get { return axis = Input.GetAxisRaw("Horizontal"); }
    }

}
