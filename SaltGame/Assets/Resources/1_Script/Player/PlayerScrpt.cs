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
    [SerializeField] ParticleSystem saltExplosionParticule;

    private InteractiveEntrance currentEntrance;

    [SerializeField] GameObject saltKnightAsset;

    RightHand rightHand;
    Backpack backpack;

    [SerializeField] GameObject shildBox, saltExplosionCollider;

    PlayerChanges playerChanges;
    PlayerMachineController playerMachineController;

    //Pointers
 
    public Rigidbody playerRB => rigidBody;

    public GameObject SaltKnightAsset => saltKnightAsset;

    public RightHand RightHand => rightHand;

    public PlayerMachineController PlayerMachineControllerinstance => playerMachineController;

    public InteractiveEntrance CurrentEntrance => currentEntrance;

    #endregion

    #region Values
    [SerializeField] int maxLife;
    [SerializeField] int currentLife;
    [SerializeField] int maxEnergy, energyRecover;
    [SerializeField] float currentEnergy, speed;

    bool lookingRight = true;

    float dir, explosionCoolown;

    [SerializeField] int nextScenePositionCode;

    //Pointers

    public float Speed => speed;

    public bool LookingRight => lookingRight;

    public float Direction => dir;

    public float CurrentEnergy => currentEnergy;

    public int CurrentLife => currentLife;

    #endregion

    void Start()
    {
        FindFirstObjectByType<CinemachineVirtualCamera>().Follow = transform;
        rightHand = GetComponentInChildren<RightHand>();
        backpack = GetComponentInChildren<Backpack>();
        playerMachineController = GetComponentInChildren<PlayerMachineController>();

        playerChanges = new PlayerChanges();

        backpack.SetPlayer(this, playerChanges);

        BaseSword.onPlayerHit += HitEnemyCallback;

        ReSetValues();
    }

    public void ReSetValues()
    { 
        currentLife = maxLife;
        FullRest();
        CanvasManager.GetInstance().UpdadeLifeText(currentLife);
    }

    private void OnLevelWasLoaded(int level)
    {
        if (!GameManager.GetInstance().IsLoadedInScene())
            MovePlayerToNextPoint();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out InteractiveEntrance entrance))
        {
            currentEntrance = entrance;
            SetPositionCode(entrance.GetNextPositionCode());
        }
    }

    public void SetPositionCode(int value)
    {
        nextScenePositionCode = value;
    }

    public void MovePlayerToNextPoint()
    {
        foreach (LoadPlayerPosition position in FindObjectsByType<LoadPlayerPosition>(0))
        {
            if (position.Code == nextScenePositionCode)
                transform.position = position.transform.position;
        }

        currentEntrance = null;
        SetPositionCode(0);
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
    }

    public void TakeAHit()
    {
        SaltExplosion();
        LoseLife(1);
    }

    public void LoseLife(int value)
    {
        currentLife -= value;
        CanvasManager.GetInstance().UpdadeLifeText(currentLife);

        if(currentLife <= 0)
        {
            GameManager.GetInstance().GameOver();
            ReSetValues();
            playerMachineController.ChangeState(playerMachineController.movingState);
        }
    }

    public IEnumerator ChangePlace()
    {
        CanvasManager.GetInstance().Refade(1);
        yield return new WaitForSeconds(1f);
        MovePlayerToNextPoint();
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

    #region Colliders

    public void SetShildCollider(bool value)
    {
        shildBox.SetActive(value);
    }

    public void SetExplosionCollider(bool value)
    {
        saltExplosionParticule.Play();
        saltExplosionCollider.SetActive(value);
    }

    public void SaltExplosion()
    {
        explosionCoolown = 0.1f;
        SoundManager.GetInstance().SaltExplosionSFDX();
        SetExplosionCollider(true);
    }
    public void HitEnemyCallback()
    {
        Debug.Log("Enemy killed");
    }

    #endregion

    #region Energy

    public void FullRest()
    {
        currentEnergy = maxEnergy + playerChanges.GetMaxEnergy();
    }

    public void Rest()
    {
        if (CurrentEnergy < maxEnergy + playerChanges.GetMaxEnergy())
            Tired((energyRecover + playerChanges.GetEnergyRecover()) * Time.deltaTime * -1);
        else 
            currentEnergy = maxEnergy + playerChanges.GetMaxEnergy();
    }

    public void Tired(float value)
    {
        currentEnergy -= value;
        //spend energy Feedback
    }

    public bool HaveEnouthEnergy(int value)
    {
        if (currentEnergy - value > 0)
            return true;

        //Dont have energy Feedback
        return false;

    }
    #endregion

    #region Sword
    public void ActivateSword()
    {
        int swordEnergySpend = rightHand.GetSwordEnergyCost();
        if (HaveEnouthEnergy(swordEnergySpend))
        {
            Tired(swordEnergySpend);
            rightHand.TryActivateSword(playerChanges.GetAttackSize(), playerChanges.GetAttackSpeed());
        }
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
