using UnityEngine;

public class InputHandler
{
    public bool GetInteractButton()
    {
        if (Input.GetButtonDown("Interact"))
        { return true; }
        return false;
    }
    //interact button ^

    public bool GetJumpButtonUp()
    {
        if (Input.GetButtonUp("Jump"))
        { return true; }
        return false;
    }
    // jump button released ^

    public bool GetJumpButton()
    {
        if (Input.GetButton("Jump"))
        { return true; }
        return false;
    }
    // jump button held down ^

    public bool GetJumpButtonDown()
    {
        if (Input.GetButtonDown("Jump"))
        { return true; }
        return false;
    }
    // jump button pressed ^

    public float Xaxis
    {
        get { return Input.GetAxisRaw("Horizontal"); }
    }
    // horizontal left joystick axis ^

    public float Yaxis
    {
        get { return Input.GetAxisRaw("Down"); }
    }
    // vertical left joystick axis ^
}
