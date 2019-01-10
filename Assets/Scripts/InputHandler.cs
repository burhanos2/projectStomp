using UnityEngine;

public class InputHandler {

    public float[] xAxis;

    private void Awake()
    {
        xAxis = new float[3];

    }


    void Update ()
    {
        float xAxisMovement1 = Input.GetAxisRaw("Horizontal1") * Time.deltaTime;
        float xAxisMovement2 = Input.GetAxisRaw("Horizontal2") * Time.deltaTime;
        float xAxisMovement3 = Input.GetAxisRaw("Horizontal3") * Time.deltaTime;
        float xAxisMovement4 = Input.GetAxisRaw("Horizontal4") * Time.deltaTime;

        xAxis[0] = xAxisMovement1;
        xAxis[1] = xAxisMovement2;
        xAxis[2] = xAxisMovement3;
        xAxis[3] = xAxisMovement4;
    }
}
