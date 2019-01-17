using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Addscore : MonoBehaviour {

    [SerializeField]

    private Text textScore;
    private PlayerInfo playerInfo;
    [SerializeField]
    private GameObject player;


    
    void Awake () {
        playerInfo = player.GetComponent<PlayerInfo>();
	}
	
	
	void Update () {
        SetScore();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "head")
        {
            playerInfo.Score++;
        }
    }

    private void SetScore()
    {
        textScore.text = "" + playerInfo.Score;
    }
   
}
