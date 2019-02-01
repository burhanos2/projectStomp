using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum Facing { Left, Right, Neutral };


public class PlayerInfo : MonoBehaviour
{

    private readonly bool invincible;
    private readonly float speed;
    private int health;
    private readonly int maxHealth = 3;
    private int score;
    

    public int Score
    { get; set; }

    public bool Invincible
    { get; set; }

    public float Speed
    { get; set; }

    public int Health
    {
        get { return health; }

        set
        {
            if (value < maxHealth)
            {
                health = health - value;
            }
            else if(value == maxHealth)
            {
                health = maxHealth;
            }
            else
            {
                return;
            }
        }
    }

    private void Awake()
    {
        Speed = 5;
        Health = maxHealth;
    }
}
