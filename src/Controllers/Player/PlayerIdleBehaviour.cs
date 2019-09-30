using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// purpose: allows for setting behavior for the idle state
// must be attatche to an animator state : https://www.youtube.com/watch?v=dYi-i83sq5g&t=272s
public class PlayerIdleBehaviour : StateMachineBehaviour
{
    /* ***************
     * * PLEASE READ *
     * ***************
     * 
     * Yes, this script is empty, please see Player Walk Behavior first for an example,
     * this is in case you would like to add any aditional behavior to idle
     * e.g. https://www.youtube.com/watch?v=rYzc_Ubf0gg 
     * here sonic will leave the game and make the player lose a life if they stay in the idle state for a certain ammount of time
     * If you have something in mind feel free to add it here.
     */


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    
    /*
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    */

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    /*
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
    */
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
