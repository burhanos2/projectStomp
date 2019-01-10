using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour {

    private Rigidbody2D rb2d;
    private InputHandler inputHandler;
    private Vector2 direction;

    [SerializeField]
    private float speed;

	void Awake ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        inputHandler = GetComponent<InputHandler>();
    }

    private void Update()
    {
        // xAxis var is temporary!!!
        Vector2 direction = new Vector2(inputHandler.xAxis[0], 0);
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        rb2d.AddForce(direction, ForceMode2D.Force);
    }
}
