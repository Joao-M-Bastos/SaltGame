using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScrpt : MonoBehaviour
{

    #region References

    [SerializeField] Rigidbody rigidBody;

    private InteractiveEntrance currentEntrance;

    [SerializeField] GameObject saltKnightAsset;

    //Pointers
 
    public Rigidbody playerRB => rigidBody;

    public InteractiveEntrance CurrentEntrance => currentEntrance;

    #endregion

    #region Values

    [SerializeField] float speed;

    [SerializeField] bool lookingRight;

    float dir;

    int nextScenePositionCode;

    //Pointers

    public float Speed => speed;

    public bool LookingRight => lookingRight;

    public float Direction => dir;

    #endregion

    void Awake()
    {
        FindFirstObjectByType<CinemachineVirtualCamera>().Follow = transform;
        DontDestroyOnLoad(this);
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

        FindFirstObjectByType<CinemachineVirtualCamera>().Follow = transform;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent<InteractiveEntrance>(out InteractiveEntrance entrance))
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
