using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBehavior : StateMachineBehaviour
{
    private Attack attack;
    private AudioSource audio;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        attack = animator.gameObject.GetComponent<Attack>();
        audio = animator.gameObject.GetComponent<AudioSource>();
        audio.Play(); // play a sound to signify attacks
        // setup attack
        attack.SetWeapon(animator.gameObject.transform); // pass in just the player transform for now, more detail coming soon
        attack.Strike(); // deal damage
        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttacking", false); // set to false to exit this state 
    }
}
