using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// purpose: allows for setting behavior for the jumping state
// must be attatche to an animator state : https://www.youtube.com/watch?v=dYi-i83sq5g&t=272s
public class PlayerJumpBehaviour : StateMachineBehaviour
{
    private Transform playerTransform;
    public bool isSidescroller;
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

        if (isSidescroller) // use for sidescrollers
        {
            animator.gameObject.GetComponent<Rigidbody2D>().velocity += new Vector2 (0, jumpAccelleration); // set the initial jump velocity
        }

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (isGrounded)
        {
            animator.SetBool("isJumping", false); // tells the animator that we can go to a different state (We are done jumping)
        }
        else if (isSidescroller)
        {
            SideScrollerJump(animator);
        }
        else if (!isSidescroller)// only happens while we are jumping
        {
            TopDownJump(animator);
        }
    }
    void SideScrollerJump(Animator animator) // use for sidescrollers
    {
        GameObject go = animator.gameObject;
        Rigidbody2D rb = go.GetComponent<Rigidbody2D>();
        if (rb.velocity.y == 0) // if stop falling/jumping
        {
            isGrounded = Physics2D.Raycast(go.transform.position, Vector2.down, 0.5f); // use a raycast to figure out if we are on the ground
        }
        else if (!Input.GetButton("Jump")) // if we let go of the jump button
        {
            rb.velocity -= new Vector2(0,2 * jumpAccelleration * Time.deltaTime); // reduce the height of the jump (short jump)
        }
        DirectionalMovement(movementSpeed);
    }
    void TopDownJump(Animator animator) // use for top downs
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

        DirectionalMovement(movementSpeed); // totally copied from Player Walk, but maybe you will want to set values differently below
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
        if (isSidescroller)
        {
            inputVector.y = 0; // don't allow up/down movements in sidescrollers
        }
        playerTransform.Translate(inputVector * scaledSpeed); // moves the transform in the direction set above
    }
}
