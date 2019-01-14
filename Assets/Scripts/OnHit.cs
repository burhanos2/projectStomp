using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit {

    private PlayerInfo playerInfo = new PlayerInfo();

    private MonoBehaviour _mb = new MonoBehaviour();

    public void ExecuteEvents()
    {
        RemoveHP(1);

        if (playerInfo.Health > 0)
        {
            MakeInvincible(2);
            IncreaseSpeed(1.25f, 2);
        }
    }

    private void RemoveHP(int amount)
    {
        playerInfo.Health -= amount;
        CheckIfDead();
    }


    private void MakeInvincible(float waitTime)
    {
        
        if (!playerInfo.Invincible) // als de player niet invincible is
        {
            playerInfo.Invincible = true;
            _mb.StartCoroutine(Wait(waitTime));
            playerInfo.Invincible = false;
            return;
        }

        else if (playerInfo.Invincible) // als de player wel invincible is
        {
            playerInfo.Invincible = false;
            return;
        }
        return;
    }      
      
    private void IncreaseSpeed(float multiplier, float waitTime)
    {
        float oldSpeed = playerInfo.Speed;
        playerInfo.Speed *= multiplier;
        _mb.StartCoroutine(Wait(waitTime));

        playerInfo.Speed = oldSpeed;
    }

    private IEnumerator Wait(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
    

    private void CheckIfDead()
    {
        if (playerInfo.Health <= 0)
        {
            // kill player script wordt hier aangeroepen <<<<<<<<<<<<<<<<<<<<<<
        }
    }
}
