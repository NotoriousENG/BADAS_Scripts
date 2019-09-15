using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpBehaviour : StateMachineBehaviour
{
    private Transform playerTransform;
    public float jumpAccelleration = 7f;
    public float gAccelleration = 9.8f;
    public float movementSpeed = 3.5f;
    private float tempAccelleration = 0f;
    private bool isGrounded;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerTransform = animator.gameObject.transform;
        
        tempAccelleration = jumpAccelleration; // tempAccelleration = positive float (Jumping)
        isGrounded = false;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isGrounded)
        {
            animator.SetBool("isJumping", false);
        }

        else
        {
            playerTransform.position -= new Vector3(0,0,tempAccelleration * Time.deltaTime);
            playerTransform.position = animator.gameObject.transform.position;

            tempAccelleration -= gAccelleration * Time.deltaTime; // total accelleration is affected by gravity
            Debug.Log("playerTransform.position: "+ playerTransform.position);
            if (playerTransform.position.z > -0.999 && tempAccelleration < 0) // failsafe to make zpos 0 if falling and close to ground
            {
                playerTransform.position = new Vector3 (playerTransform.position.x,playerTransform.position.y,Mathf.Abs(playerTransform.position.z - playerTransform.position.z));
                isGrounded = true;
            }
            
            DirectionalMovement(movementSpeed);
        }
    }

    void DirectionalMovement(float speed)
    {
        /* adjust speed by the time it took to complete the last frame (time.deltaTime) */
        float scaledSpeed = speed * Time.deltaTime; 

        /* 
         * store the player input and scale it for use in the below movement (transform.translate function) 
         * normalized makes sure that walking diagonaly is not faster than moving horizontally or vertically
         */
        Vector3 inputVector = new Vector3( (Input.GetAxis("Horizontal")) , (Input.GetAxis("Vertical")), 0).normalized ;

        playerTransform.Translate(inputVector * scaledSpeed); // moves the transform in the direction set above
    }

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
