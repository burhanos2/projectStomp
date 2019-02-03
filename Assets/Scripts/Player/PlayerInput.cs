using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public int playerNumber = 1;

    private readonly string interactButton = "Interact", jumpButton = "Jump", horizontalAxis = "Horizontal", verticalAxis = "Down";

    public bool GetInteractButton()
    {
        if (Input.GetButtonDown(interactButton + playerNumber))
        { return true; }
        return false;
    }
    //interact button ^

    public bool GetJumpButtonUp()
    {
        if (Input.GetButtonUp(jumpButton + playerNumber))
        { return true; }
        return false;
    }
    // jump button released ^

    public bool GetJumpButton()
    {
        if (Input.GetButton(jumpButton + playerNumber))
        { return true; }
        return false;
    }
    // jump button held down ^

    public bool GetJumpButtonDown()
    {
        if (Input.GetButtonDown(jumpButton + playerNumber))
        { return true; }
        return false;
    }
    // jump button pressed ^

    public float Xaxis
    {
        get { return Input.GetAxisRaw(horizontalAxis + playerNumber); }
    }
    // horizontal left joystick axis ^

    public float Yaxis
    {
        get { return Input.GetAxisRaw(verticalAxis + playerNumber); }
    }
    // vertical left joystick axis ^
}
