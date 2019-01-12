using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit {

    private PlayerInfo playerInfo = new PlayerInfo();

    public void RemoveHP(int amount)
    {
        playerInfo.Health -=1;
        CheckIfDead();
    }


    public void MakeInvincible(bool value)
    {
        playerInfo.Invincible = value;
        
        if (!playerInfo.Invincible) // als de player niet invincible is
        {
            // hier komt de code wanneer de player niet invincible is (dus een coroutine die een aantal seconden duurt) <<<<<<<<<<<<<<<<<<<<<<
            playerInfo.Invincible = true;
        } else if (playerInfo.Invincible) // als de player wel invincible is
        {
            playerInfo.Invincible = false;
        }
    }
    /* \\\\\\\\\\ ik heb ff hulp nodig van iemand die een loop weet die wel in een script zonder MonoBehaviour kan//////////
      
      
    public void IncreaseSpeed(float multiplier, float waitDuration)
    {
        float oldSpeed = playerInfo.Speed;
        playerInfo.Speed *= multiplier;
        yield return StartCoroutine(SetOldSpeed(3)); <<<<<<<<<<<<<<<<<<<<<<
        
        playerInfo.Speed = oldSpeed;
    }

    private IEnumerator SetOldSpeed(float waitTime) <<<<<<<<<<<<<<<<<<<<<<
    {
        yield return new WaitForSeconds(waitTime);
        playerInfo.Speed = oldSpeed;
    }
    */

    private void CheckIfDead()
    {
        if (playerInfo.Health <= 0)
        {
            // kill player script wordt hier aangeroepen <<<<<<<<<<<<<<<<<<<<<<
        }
    }
}
