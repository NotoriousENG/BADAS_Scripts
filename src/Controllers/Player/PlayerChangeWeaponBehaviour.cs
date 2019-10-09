using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 * Add this to an animator state to allow the player to change weapons by pressing '1' or '2'
 */
public class PlayerChangeWeaponBehaviour : StateMachineBehaviour
{
    private Equipment equipment;
    // private float waitTime;
    private bool navigateBack, navigateForward;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        equipment = animator.gameObject.GetComponent<Equipment>();    
        // waitTime = Time.timeSinceLevelLoad + .5f;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
        navigateForward = Input.GetKeyDown("1");
        navigateBack = Input.GetKeyDown("2");
        
        

        if (navigateBack)
        {
            equipment.EquipWeapon(-1);
        }
        else if (navigateForward)
        {
            equipment.EquipWeapon(1);
        }
    }
}
