using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            if (value <= maxHealth)
            {
                health = value;
            }
            else { return; }
        }
    }

    private void Awake()
    {
        Speed = 3;
        Health = maxHealth;
    }

}
