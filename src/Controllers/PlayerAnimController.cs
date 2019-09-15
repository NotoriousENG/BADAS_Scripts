using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimController : MonoBehaviour
{
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // Use Player Input to set animator variables
        animator.SetFloat("moveHorizontal", Input.GetAxis("Horizontal"));
        animator.SetFloat("moveVertical", Input.GetAxis("Vertical"));

        Debug.Log(new Vector2 (Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        if (Mathf.Abs(Input.GetAxis("Horizontal")) < 0.01 && Mathf.Abs(Input.GetAxis("Vertical")) < 0.01)
        {
            animator.SetBool("isWalking", false);
        }
        else
        {
            animator.SetBool("isWalking", true);
        }

        if (Input.GetButtonDown("Jump"))
        {
            animator.SetBool("isJumping", true); // set to false in PlayerJumpBehaviour
        }
        

        /* 
         * all other functions, movement, jumping, attacking, etc. 
         * can be called from the animator
         */
    }
}
