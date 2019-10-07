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
        if (weapon != null && weapon.Speed > 0)
        {
            animator.SetFloat("attackMultiplier", weapon.Speed); // change attack speed to weapon speed
        }
        else 
        {
            animator.SetFloat("attackMultiplier", 1f); // default speed
        }
        createProjectile(animator);
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

    private void createProjectile(Animator animator)
    {
        if (getEquipedWeapon(animator).Projectile != null)
        {
            GameObject projSample = getEquipedWeapon(animator).Projectile; // get the projectile to create

            /* **IF YOU ARE NOT USING THE MOUSE USE THIS** */
            Vector3 dir = new Vector3(animator.GetFloat("lastHorizontal"), animator.GetFloat("lastVertical"), 0); // get the direction to send the projectile into if you are not using the mouse

            GameObject proj = Instantiate<GameObject>(projSample) as GameObject; // create a new instance of the projectile (A copy/new bullet)
            proj.transform.position = animator.gameObject.transform.position; // set the origin position to the player's position
            proj.SetActive(true);

            MoveProjectile moveProjectile = proj.GetComponent<MoveProjectile>(); // get ready to setup the movement behaviour

            /*  **IF YOU ARE USING THE MOUSE USE THIS** 
            Vector3 screenPos = Camera.main.WorldToScreenPoint(animator.gameObject.transform.position); // take into account the camera space if you are using the mouse
            dir = (Input.mousePosition - screenPos).normalized;
            */

            if (dir == new Vector3(0,0,0))
            {
                dir = new Vector3 (0,-1,0); // default to shooting down
            }
            moveProjectile.MoveDir = dir;
            moveProjectile.Shooter = animator.gameObject;

        }
    }
}
