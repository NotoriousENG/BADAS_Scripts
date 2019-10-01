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
        getAttackAnimator(animator).SetBool("isPlaying", true);
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttacking", false); // set to false to exit this state 
        getAttackAnimator(animator).SetBool("isPlaying", false);
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        getAttackAnimator(animator).SetBool("isPlaying", false);
    }

    private Animator getAttackAnimator(Animator animator)
    {
        Transform hand = animator.gameObject.transform.Find("Hand");
        for (int i = 0; i < hand.childCount; i++)
        {

            GameObject child = hand.GetChild(i).gameObject;
            if (child.tag.Equals("Weapon"))
            {
                Animator childAnim = child.GetComponent<Animator>();
                return childAnim;
            }
        }
        return null;
    }
}
