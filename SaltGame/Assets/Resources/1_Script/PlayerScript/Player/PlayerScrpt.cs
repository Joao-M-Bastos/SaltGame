using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScrpt : MonoBehaviour
{
    [SerializeField] float speed;
    public float Speed => speed;

    [SerializeField] Rigidbody rigidBody;
    public Rigidbody playerRB => rigidBody;

    [SerializeField] bool lookingRight;
    public bool LookingRight => lookingRight;

    [SerializeField] GameObject saltKnightAsset;

    float dir;
    public float Direction => dir;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (CanFlip()) Flip();
        
    }

    private bool CanFlip()
    {
        dir = Input.GetAxis("Horizontal");

        if (dir < 0 && LookingRight) return true;
        if (dir > 0 && !LookingRight) return true;
        return false;
    }

    public void Flip()
    {
        this.transform.Rotate(0,180,0);

        if(lookingRight)
            saltKnightAsset.transform.Rotate(0, -70, 0);
        else
            saltKnightAsset.transform.Rotate(0, 70, 0);

        playerRB.velocity *= 0;
        lookingRight = !lookingRight;
    }
}
