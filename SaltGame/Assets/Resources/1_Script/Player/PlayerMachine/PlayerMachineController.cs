using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class PlayerMachineController : MonoBehaviour
{

    #region References

    [SerializeField] PlayerScrpt player;

    #endregion

    #region States
    PlayerBaseState currentState;

    readonly public PlayerBaseState movingState = new MovingState_Player();
    readonly public PlayerBaseState combatState = new CombatStatePlayer();
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(movingState);
    }


    public void ChangeStateByID(int nextState)
    {
        if (currentState != null) currentState.StopState(this, player);

        switch (nextState)
        {
            case 0: currentState = movingState;
                break; 
            case 1: currentState = combatState; 
                break;
        }

        currentState.StartState(this, player);
    }

    public void ChangeState(PlayerBaseState nextState)
    {
        if (currentState != null) currentState.StopState(this, player);

        currentState = nextState;

        currentState.StartState(this, player);
    }

    public int GetStateID()
    {
        int id = 0;

        if (currentState == combatState)
            id = 1;

        return id;
    }

    // Update is called once per frame
    void Update()
    {
        currentState.UpdateState(this, player);
    }

    private void FixedUpdate()
    {
        currentState.FixedState(this, player);
    }
}
