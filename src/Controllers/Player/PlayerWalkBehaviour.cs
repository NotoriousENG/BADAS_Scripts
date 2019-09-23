using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// purpose: allows for setting behavior for the walking state
// must be attatche to an animator state : https://www.youtube.com/watch?v=dYi-i83sq5g&t=272s
public class PlayerWalkBehaviour : StateMachineBehaviour
{
    /* 
     * I highly reccomend using a blend tree instead of having a seperate 
     * animator state for each directional movement
     * (tutorial) : https://www.youtube.com/watch?v=32VXj5BB7wU
     */
    public float speed = 3.5f;
    private Transform playerTransform;
    private Rigidbody2D rigidbody;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerTransform = animator.gameObject.transform; // store in variable for easier typing
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
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

}
