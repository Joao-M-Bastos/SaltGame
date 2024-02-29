using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMachineController : MonoBehaviour
{

    #region References

    [SerializeField] PlayerScrpt player;

    #endregion

    #region States
    PlayerBaseState currentState;

    PlayerBaseState movingState = new MovingState_Player();
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        ChangeState(movingState);
    }

    public void ChangeState(PlayerBaseState nextState)
    {
        if (currentState != null) currentState.StopState(this, player);

        currentState = nextState;

        currentState.StartState(this, player);
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
