using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedCheck : MonoBehaviour
{
    protected LayerMask GroundMask;

    [SerializeField]
    private Vector3 vectorOffset = new Vector3(0,0,0);

    protected const float CheckHeight = 0.55f;

    public bool Grounded {   get { return DoGroundCheck(); }   }

    void Awake()
    {
        GroundMask = LayerMask.GetMask("Ground");
    }

    public bool DoGroundCheck()
    {
        Debug.DrawRay(transform.localPosition + vectorOffset, -transform.up * CheckHeight, Color.cyan, 0f);
        //
        if (Physics2D.Raycast(transform.localPosition + vectorOffset, -transform.up, CheckHeight, GroundMask))
        {
                return true;
        }
        else
        {
                return false;
        }
    }
}
