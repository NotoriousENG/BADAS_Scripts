using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBehavior : StateMachineBehaviour
{
    private AudioSource audio;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audio = animator.gameObject.GetComponent<AudioSource>();
        audio.Play(); // play a sound to signify attacks
        
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttacking", false); // set to false to exit this state 
    }
}
