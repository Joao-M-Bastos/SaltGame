using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportEnemy : BaseEnemy
{
    [SerializeField] int distace;
    [SerializeField] GameObject preTPMash, posTPMash;

    bool hasAlreadyTeleported, isCharching;
    float chargeTime = 2;
    
    public override void OnDie()
    {
        //throw new System.NotImplementedException();
    }

    public override void SpecialMove()
    {
        if(chargeTime > 0)
        {
            chargeTime -= Time.deltaTime;
            return;
        }    

        preTPMash.SetActive(false);
        posTPMash.SetActive(true);

        hasAlreadyTeleported = true;
        isCharching = false;

        transform.position += transform.forward * distace * 1.5f;

        transform.Rotate(0, 180, 0);
    }

    private void Update()
    {
        if (!hasAlreadyTeleported && DistanceFromPlayer() < distace)
        {
            isCharching = true;
            SpecialMove();
        }
    }

    private void FixedUpdate()
    {
        if(!isCharching)
            MoveFoward();
    }
}
