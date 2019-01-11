using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    private InputHandler handler;

    public float speed;

    private void Awake()
    {
        handler = new InputHandler();
    }

    private void Update()
    {
        float x = handler.xAxis * speed;
        transform.Translate(x, 0, 0);
    }

}
