using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource sound;

    // Singleton instance.
    public static SoundManager Instance = null;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        // Dont destroy when switching scenes 
        DontDestroyOnLoad(gameObject);
    }

    public void PlayOneShot(AudioClip clip)
    {
        sound.clip = clip;
        sound.PlayOneShot(clip);
    }
}