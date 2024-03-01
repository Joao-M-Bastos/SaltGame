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
        dir = Input.GetAxis("Horizontal");

        if (dir < 0 && LookingRight) Flip();
        if (dir > 0 && !LookingRight) Flip();
    }   

    public void Flip()
    {
        saltKnightAsset.transform.localRotation *= new Quaternion(1,-1,1,1);
        this.transform.Rotate(0,180,0);
        playerRB.velocity *= 0;
        lookingRight = !lookingRight;
    }
}
