using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCheck : MonoBehaviour{
    private OnHit _onHit;

    private void Awake()
    {
        _onHit = new OnHit();
    }

    // add it to the player head
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PlayerFeet")
        {
            Debug.Log("a foot has hit a head");
            _onHit.ExecuteDamage();
        }
    }
}
