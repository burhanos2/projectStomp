using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class OnHit : MonoBehaviour {

    private PlayerInfo playerInfo;
    private Rigidbody2D rb2d;
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        playerInfo = GetComponent<PlayerInfo>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void ExecuteDamage()
    {
        RemoveHP(1);     
        Camera.main.GetComponent<ScreenShake>().Shake(0.2f, 4);
    }

    private void RemoveHP(int amount)
    {
        playerInfo.Health = amount;
        // SoundManager.Instance.Play(/* sound effect damage */);
        if (playerInfo.Health <= 0)
        {
            CheckIfDead();
        }
    }   

    private void CheckIfDead()
    {
        // SoundManager.Instance.Play(/* sound effect death */);
        animator.Play("Death");
        Invoke("StopScene", 0.667f);
    }

    public void KnockBack(float force)
    {
        float randomNumber = Random.Range(0, 2);
        float randomVelocityFactor = Random.Range(0.5f, 1f);

        if (randomNumber == 0)
        {
            rb2d.AddForce(new Vector3(-force * randomVelocityFactor, force, 0), ForceMode2D.Impulse);
        }
        else if (randomNumber == 1)
        {
            rb2d.AddForce(new Vector3(force * randomVelocityFactor, force, 0), ForceMode2D.Impulse);
        }
    }
    
    private void StopScene()
    {
        SceneManager.LoadScene("Results");
    }
}
