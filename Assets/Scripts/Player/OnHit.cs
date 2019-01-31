using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnHit : MonoBehaviour {

    private PlayerInfo playerInfo;
    private Movement movement;
    private Rigidbody2D rb2d;


    private void Awake()
    {
        playerInfo = GetComponent<PlayerInfo>();
        movement = GetComponent<Movement>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void ExecuteDamage()
    {
        Camera.main.GetComponent<ScreenShake>().Shake(0.2f, 4);
        KnockBack(3);
        RemoveHP(1);        
    }

    private void RemoveHP(int amount)
    {
        playerInfo.Health -= amount;
  //     SoundManager.Instance.Play(/* sound effect damage */);
        if (playerInfo.Health <= 0)
        {
            CheckIfDead();
        }
    }   

    private void CheckIfDead()
    {
  //       SoundManager.Instance.Play(/* sound effect death */);
        // disable player sprite and load animation here
        Invoke("StopScene", 3);
    }

    private void KnockBack(float force)
    {
        float randomNumber = Random.Range(0, 1);

        if (randomNumber == 0)
        {
            rb2d.AddForce(new Vector3(-force, force, 0), ForceMode2D.Impulse);
        }
        else if (randomNumber == 1)
        {
            rb2d.AddForce(new Vector3(force, force, 0), ForceMode2D.Impulse);
        }
    }
    
    private void StopScene()
    {
        SceneManager.LoadScene("Results");
    }
}
