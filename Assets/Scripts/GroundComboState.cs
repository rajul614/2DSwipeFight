using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundComboState : MeleeBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);

        //Attack
        attackIndex = 2;
        duration = 0.5f;
        animator.SetTrigger("Attack" + attackIndex);
        nextState = new GroundFinisherState();
        Debug.Log("Player Attack " + attackIndex + " Fired!");
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        // if state timer is over only then go to next state
        if (fixedtime >= duration)
        {
            if (shouldCombo)
            {
                stateMachine.SetNextState(nextState);
            }
            else
            {
                stateMachine.SetNextStateToMain();
            }
        }
    }


}
