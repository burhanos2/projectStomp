using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadCheck : MonoBehaviour{
    //  private OnHit _onHit;
    public GameObject opponent; // calm down just testing for now
    private void Awake()
    {
      //  _onHit = new OnHit();
    }

    // add it to the player head
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "PlayerFeet")
        {
            Debug.Log(opponent.name + " has landed a hit!");
           // _onHit.ExecuteDamage(); 
        }
    }
}
