﻿﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// purpose: to set variables for the animator to allow for clean transitions between player actions
public class PlayerAnimController : MonoBehaviour
{
    /* 
     * In Unity 5, you can actually use the animator and add a script for each state (: 
     * This is much cleaner than other approaches and requires less homemade code
     * A friend showed me this and it changed my life: https://www.youtube.com/watch?v=dYi-i83sq5g&t=272s
     * of course, you can do whatever you'd like (:
     */
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetFloat("lastVertical", -1f); // default to facing down
    }

    // Update is called once per frame
    void Update()
    {
        /* 
         * Use Player Input to set animator variables for a blend tree
         * I highly reccomend using a blend tree instead of having a seperate 
         * animator state for each directional movement
         * (tutorial) : https://www.youtube.com/watch?v=32VXj5BB7wU
         */

        /* 
         * get magnitude of movement 
         * (Hypotenuse:  x^2 + y^2 = h^2) 
         * there probably is a built that does the same job
         */
        
        animator.SetFloat("moveMagnitude", Mathf.Sqrt(Mathf.Pow(Input.GetAxis("Horizontal"), 2) + Mathf.Pow(Input.GetAxis("Vertical"), 2))); 

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("isJumping", true); // set to false in PlayerJumpBehaviour
        }

        if (Input.GetButtonDown("Fire1"))
        {
            animator.SetBool("isAttacking", true); // set to false in PlayerAttackBehaviour
        }

        SetWeaponAnimatorParameter();

        /* 
         * all other functions, movement, jumping, attacking, etc. 
         * can be called from the animator
         * i.e. attatch PlayerWalkBehaviour to your walking state
         */
    }

    public void SetWeaponAnimatorParameter()
    {
        animator.SetInteger("Attack", gameObject.GetComponentInChildren<Weapon>().attackAnimationToPlay);
    }
    public void ForceIdle()
    {
        animator.SetFloat("lastHorizontal", 0);
        animator.SetFloat("lastVertical", 0);
        animator.SetFloat("moveMagnitude", 0);
    }
}
