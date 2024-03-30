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

    RightHand rightHand;
    Backpack backpack;

    [SerializeField] GameObject shildBox, saltExplosionCollider;

    PlayerChanges playerChanges;

    //Pointers
 
    public Rigidbody playerRB => rigidBody;

    public GameObject SaltKnightAsset => saltKnightAsset;

    public RightHand rightHandRB => rightHand;

    public InteractiveEntrance CurrentEntrance => currentEntrance;

    #endregion

    #region Values
    [SerializeField] int maxLife;
    [SerializeField] int currentLife;
    [SerializeField] int maxTiredness, tirednessRecover;
    [SerializeField] float currentTiredness, speed;

    bool lookingRight = true;

    float dir, explosionCoolown;

    [SerializeField] int nextScenePositionCode;

    //Pointers

    public float Speed => speed;

    public bool LookingRight => lookingRight;

    public float Direction => dir;

    public float CurrentTiredness => currentTiredness;

    #endregion

    void Awake()
    {
        FindFirstObjectByType<CinemachineVirtualCamera>().Follow = transform;
        rightHand = GetComponentInChildren<RightHand>();
        backpack = GetComponentInChildren<Backpack>();
        currentLife = maxLife;

        playerChanges = new PlayerChanges();

        backpack.SetPlayer(this, playerChanges);

        BaseSword.onPlayerHit += HitEnemyCallback;
    }

    private void OnLevelWasLoaded(int level)
    {
        MovePlayerToNextPoint();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out InteractiveEntrance entrance))
        {
            currentEntrance = entrance;
            nextScenePositionCode = entrance.GetNextPositionCode();
        }
    }

    public void MovePlayerToNextPoint()
    {
        foreach (LoadPlayerPosition position in FindObjectsByType<LoadPlayerPosition>(0))
        {
            if (position.Code == nextScenePositionCode)
                transform.position = position.transform.position;
        }

        currentEntrance = null;
        nextScenePositionCode = 0;
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out InteractiveEntrance entrance))
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

        Rest();
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

    public void HitEnemyCallback()
    {
        Debug.Log("Enemy killed");
    }

    #region Tiredness

    public void Rest()
    {
        if (CurrentTiredness < maxTiredness + playerChanges.GetMaxTiredness())
        {
            currentTiredness += (tirednessRecover + playerChanges.GetTirednessRecover()) * Time.deltaTime;
        }
    }

    public void AddTiredness(int value)
    {
        currentTiredness -= value;
    }

    public bool HaveEnouthTiredness(int value)
    {
        return currentTiredness - value < 0;
    }
    #endregion

    #region Sword
    public void ActivateSword()
    {
        rightHand.TryActivateSword(playerChanges.GetAttackSize());
    }
    #endregion

    #region Items

    public void ActivateItem(int slot)
    {
        backpack.UseItem(slot);
    }

    public void DeactivateItems()
    {
        backpack.DeactivateItems();
    }

    #endregion
}
