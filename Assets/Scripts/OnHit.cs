using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHit {

    private PlayerInfo playerInfo = new PlayerInfo();
    private AdjustTime adjustTime = new AdjustTime();
    private Addscore addscore = new Addscore();

    private readonly float effectMultiplier = 1.25f;
    private readonly float durationOfEvents = 2;

    public void ExecuteDamage()
    {
        RemoveHP(1);

        if (playerInfo.Health > 0)
        {
            MakeInvincible(durationOfEvents);
            IncreasePlayerSpeed(effectMultiplier, durationOfEvents);
            SlowDown(effectMultiplier, durationOfEvents);
        }
    }

    private void SlowDown(float multiplier, float waitTime)
    {
        adjustTime.LimitedTimeSwitch(multiplier, waitTime);
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
            adjustTime.Wait(waitTime);
            playerInfo.Invincible = false;
        }

        else if (playerInfo.Invincible) // als de player wel invincible is
        {
            playerInfo.Invincible = false;
        }
        return;
    }      
      
    private void IncreasePlayerSpeed(float multiplier, float waitTime)
    {
        float oldSpeed = playerInfo.Speed; // keep old player speed in memory
        playerInfo.Speed *= multiplier;
        adjustTime.Wait(waitTime);

        playerInfo.Speed = oldSpeed; // reset old speed
    }    

    private void CheckIfDead()
    {
        if (playerInfo.Health <= 0)
        {
            // kill player script wordt hier aangeroepen <<<<<<<<<<<<<<<<<<<<<<
        }
    }
}
