using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GirlHero_Roll : StateMachineBehaviour
{
    public GirlHero girlHero;
    public Health health;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        girlHero = GameObject.Find("GirlHero").GetComponent<GirlHero>();
        health = girlHero.playHealth;
        health.invincible = true;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        health.invincible = false;
    }
}
