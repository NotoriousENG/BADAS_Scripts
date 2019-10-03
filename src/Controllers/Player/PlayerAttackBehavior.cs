using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBehavior : StateMachineBehaviour
{
    private AudioSource audio;
    private float defaultSpeed;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audio = animator.gameObject.GetComponent<AudioSource>();
        audio.Play(); // play a sound to signify attacks
        Weapon weapon = getEquipedWeapon(animator);
        defaultSpeed = animator.speed;
        animator.speed = weapon.Speed; // change attack speed to weapon speed
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttacking", false); // set to false to exit this state 
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.speed = defaultSpeed; // return animator speed to default
    }

    private Weapon getEquipedWeapon(Animator animator)
    {
        Transform hand = animator.gameObject.transform.Find("Hand");
        for (int i = 0; i < hand.childCount; i++)
        {

            GameObject child = hand.GetChild(i).gameObject;
            if (child.tag.Equals("Weapon"))
            {
                Weapon wep = child.GetComponent<Weapon>();
                return wep;
            }
        }
        return null;
    }
}
