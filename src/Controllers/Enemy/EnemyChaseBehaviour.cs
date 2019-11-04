using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseBehaviour : StateMachineBehaviour
{
    private Transform playerPos;
    public float speed;
    private Animator anim;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform; // load in the player's position
        anim = animator;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform enemyPos = animator.transform;
        float step = speed * Time.deltaTime;
        enemyPos.position = Vector2.MoveTowards(enemyPos.transform.position, playerPos.position, step); // move towards the player
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        Vector2 lineToObject = (anim.transform.position - other.transform.position).normalized;
        anim.transform.position = Vector2.MoveTowards(anim.transform.position, -1 * lineToObject, speed * Time.deltaTime); // don't get too stuck on objects (barely noticeable)
    }
}
