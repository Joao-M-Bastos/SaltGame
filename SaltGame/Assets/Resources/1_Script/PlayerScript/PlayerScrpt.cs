using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerScrpt : MonoBehaviour, HitCallback
{

    #region References

    [SerializeField] Rigidbody rigidBody;

    private InteractiveEntrance currentEntrance;

    [SerializeField] GameObject saltKnightAsset;

    [SerializeField] BaseSword currentSword;

    [SerializeField] GameObject shildBox, saltExplosionCollider;

    //Pointers
 
    public Rigidbody playerRB => rigidBody;

    public InteractiveEntrance CurrentEntrance => currentEntrance;

    #endregion

    #region Values
    [SerializeField] int maxLife;
    [SerializeField] int currentLife;
    [SerializeField] float speed;
    [SerializeField] bool lookingRight;

    float dir, explosionCoolown;

    int nextScenePositionCode;

    //Pointers

    public float Speed => speed;

    public bool LookingRight => lookingRight;

    public float Direction => dir;

    #endregion

    void Awake()
    {
        FindFirstObjectByType<CinemachineVirtualCamera>().Follow = transform;
        currentLife = maxLife;
    }

    private void OnLevelWasLoaded(int level)
    {
        foreach(LoadPlayerPosition position in FindObjectsOfType<LoadPlayerPosition>())
        {
            if (position.Code == nextScenePositionCode)
                transform.position = position.transform.position;
        }

        currentEntrance = null;
        nextScenePositionCode = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out InteractiveEntrance entrance))
        {
            currentEntrance = entrance;
            nextScenePositionCode = entrance.GetNextPositionCode();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent<InteractiveEntrance>(out InteractiveEntrance entrance))
        {
            currentEntrance = null;
            nextScenePositionCode = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (CanFlip()) Flip();

        if (saltExplosionCollider.activeSelf)
        {
            if (explosionCoolown > 0)
                explosionCoolown -= Time.deltaTime;
            else SetExplosionCollider(false);
        }
    }

    public void TakeAHit()
    {
        SaltExplosion();
        LoseLife(1);
    }

    private void LoseLife(int value)
    {
        currentLife -= value;
    }

    public void SaltExplosion()
    {
        explosionCoolown = 0.1f;
        SetExplosionCollider(true);
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

    
    public void SetShildCollider(bool value)
    {
        shildBox.SetActive(value);
    }
    public void SetExplosionCollider(bool value)
    {
        saltExplosionCollider.SetActive(value);
    }

    public void HitOtherCallback()
    {

    }

    #region Sword
    public void ActivateSword()
    {
        currentSword.ActivateSwordCollider();
    }


    #endregion
}
