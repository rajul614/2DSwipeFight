using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundEntryState : MeleeBaseState
{
    public override void OnEnter(StateMachine _stateMachine)
    {
        base.OnEnter(_stateMachine);
        nextState = new GroundComboState();
        //Attack
        attackIndex = 1;
        duration = 0.5f;
        animator.SetTrigger("Attack" + attackIndex);
        Debug.Log("Player Attack " + attackIndex + " Fired!");
        
    }

    public override void OnUpdate()
    {
        base.OnUpdate();

        // dont like reliance on Time. Should use animation time here? 
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
