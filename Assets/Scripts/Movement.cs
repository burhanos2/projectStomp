using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour {

    private Rigidbody2D rb2d;

	void Awake ()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
	
	private void Move()
}
