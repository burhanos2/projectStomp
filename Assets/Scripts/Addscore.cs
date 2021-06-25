using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Addscore : MonoBehaviour
{

    [SerializeField]

    private Text textScore;
    private PlayerInfo playerInfo;
    [SerializeField]
    private GameObject player;

    private bool needsUpwardMomentum = false;
    private Vector3 tsOld = new Vector3();
    private Vector3 tsNew = new Vector3();

    void Awake()
    {
        playerInfo = player.GetComponent<PlayerInfo>();
        SetScore();
    }


    void Update()
    {
        CastRay();
        if(needsUpwardMomentum){
            CheckUpwardMomentum();
        }
    }

    // ==== Raycast to check underneat the player (Co-editor LoneDragon)
    private void CastRay(){
        // variables
        RaycastHit2D hit;
        GameObject currentHit;
        // hit information
        hit = Physics2D.Raycast(new Vector3(transform.position.x, transform.position.y - 0.501f, transform.position.z), Vector3.down);
        // get the Gameobject
        currentHit = hit.collider.gameObject;
        // get diference inbetween the 2 points
        float diference = currentHit.transform.position.y - transform.position.y;
        // check if close enough to actualy hit the target
        if (currentHit.tag == "Player" && (diference + 1) > -0.02f && !needsUpwardMomentum) 
        {
            playerInfo.Score++;
            SetScore();
            needsUpwardMomentum = true;
        }
    }

    // ==== check if the player has moved up (Co-editor LoneDragon)
    private void CheckUpwardMomentum(){
        tsOld = tsNew;
        tsNew = transform.position;
        if (tsNew.y > tsOld.y){
            needsUpwardMomentum = false;
        }
    }
    

    private void SetScore()
    {
        textScore.text = "" + playerInfo.Score;
    }
    
}
