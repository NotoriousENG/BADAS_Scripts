using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// purpose: allows for setting behavior for the jumping state
// must be attatche to an animator state : https://www.youtube.com/watch?v=dYi-i83sq5g&t=272s
public class PlayerSideScrollJumpBehaviour : StateMachineBehaviour
{
    private Transform playerTransform;
    private Rigidbody2D rigidbody;
    public float jumpAccelleration = 10f;
    public float movementSpeed = 3.5f;
    [HideInInspector]
    public float distToGround;
    private bool check;
    private BoxCollider2D collider2D;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        rigidbody = animator.gameObject.GetComponent<Rigidbody2D>();
        playerTransform = animator.gameObject.transform;
        collider2D = animator.gameObject.GetComponent<BoxCollider2D>();
        
        rigidbody.AddForce(new Vector2(0,jumpAccelleration * rigidbody.mass * 9.81f));
        //distToGround = playerTransform.gameObject.GetComponent<Collider2D>().bounds.extents.y;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetFloat("moveVertical", rigidbody.velocity.y);
        if (IsGrounded() && check)
        {
            animator.SetBool("isJumping", false); // tells the animator that we can go to a different state (We are done jumping)
        }

        else // only happens while we are jumping
        {
            if (rigidbody.velocity.y > 1)
            {
                check = true;
            }
            DirectionalMovement(movementSpeed); // totally copied from Player Walk, but maybe you will want to set values differently below
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
        Vector3 inputVector = new Vector3( (Input.GetAxis("Horizontal")) , 0, 0).normalized ;

        playerTransform.Translate(inputVector * scaledSpeed); // moves the transform in the direction set above
    }

    private bool IsGrounded()
    {
        var hit = Physics2D.Raycast(playerTransform.position, Vector2.down, /*distToGround +*/ 0.1f);
        Collider2D[] res = new Collider2D[10];
        ContactFilter2D cf = new ContactFilter2D();
        cf.NoFilter();
        var b = collider2D.OverlapCollider(cf, res) >= 1;
        return (rigidbody.velocity.normalized.y <= 0) && b;
    }
}
