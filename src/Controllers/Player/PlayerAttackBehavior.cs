using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackBehavior : StateMachineBehaviour
{
    public bool useLiteMode;
    public bool useMouse;
    private float attackOffset;
    private GameObject ColliderObject;
    private AudioSource audio;
    private float defaultSpeed;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        audio = animator.gameObject.GetComponent<AudioSource>();
        audio.Play(); // play a sound to signify attacks
        Weapon weapon = getEquipedWeapon(animator);
        defaultSpeed = animator.speed;
        if (weapon != null && weapon.Speed > 0 && !useLiteMode)
        {
            animator.SetFloat("attackMultiplier", weapon.Speed); // change attack speed to weapon speed
        }
        else 
        {
            animator.SetFloat("attackMultiplier", 1f); // default speed
        }
        createProjectile(animator);

        if (useLiteMode)
        {
            ColliderObject = weapon.gameObject;
            attackOffset = weapon.attackOffset;
            ColliderObject.transform.localPosition = getColliderPos(animator); // set the pos of the collider
            ColliderObject.SetActive(true); // turn on the collider
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool("isAttacking", false); // set to false to exit this state 
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.speed = defaultSpeed; // return animator speed to default
        if (useLiteMode)
        {
            ColliderObject.SetActive(false); // turn off the collider
        }
    }

    private Weapon getEquipedWeapon(Animator animator)
    {
        /*
         * Get the weapon from the player's hand
         * Player
         *      |-> Hand
         *          |-> Weapon
         */
        
        Transform hand = null;
        if (useLiteMode)
        {
            hand = animator.gameObject.transform; // the hand is the gameObject
        }
        else 
        {
            hand = animator.gameObject.transform.Find("Hand"); // the hand is a child of the gameObject
        }
        
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
        if (getEquipedWeapon(animator) != null &&  getEquipedWeapon(animator).isProjectileWeapon)
        {
            Vector3 dir; // create dir variable
            GameObject projSample = getEquipedWeapon(animator).Projectile; // get the projectile to create

            GameObject proj = Instantiate<GameObject>(projSample) as GameObject; // create a new instance of the projectile (A copy/new bullet)
            proj.transform.position = animator.gameObject.transform.position; // set the origin position to the player's position
            proj.SetActive(true);

            MoveProjectile moveProjectile = proj.GetComponent<MoveProjectile>(); // get ready to setup the movement behaviour

            /*  **IF YOU ARE USING THE MOUSE THIS SETS THE DIR VALUES*/
            if (useMouse)
            {
                Vector3 screenPos = Camera.main.WorldToScreenPoint(animator.gameObject.transform.position); // take into account the camera space if you are using the mouse
                dir = (Input.mousePosition - screenPos).normalized;
            }
            /* **IF YOU ARE NOT USING THE MOUSE THIS SETS THE DIR VALUES */
            else 
            {
                dir = new Vector3(animator.GetFloat("lastHorizontal"), animator.GetFloat("lastVertical"), 0); // get the direction to send the projectile into if you are not using the mouse
            }
            
            if (dir == new Vector3(0,0,0))
            {
                dir = new Vector3 (0,-1,0); // default to shooting down
            }
            moveProjectile.MoveDir = dir;
            moveProjectile.Shooter = animator.gameObject;

        }
    }
    private Vector3 getColliderPos(Animator animator)
    {
        Vector2 dirs = new Vector2 (animator.GetFloat("lastHorizontal"), animator.GetFloat("lastVertical"));
        if (dirs.x != 0) // don't divide by zero lol
        {
            dirs.x = dirs.x / Mathf.Abs(dirs.x); // get direction faacing i.e. (-1,0) is left
        }
        if (dirs.y != 0)
        {
            dirs.y = dirs.y / Mathf.Abs(dirs.y);
        }
        
        return dirs * attackOffset; // get the position of the collider as a Vector3
    }

}

