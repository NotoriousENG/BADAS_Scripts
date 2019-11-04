using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolAreaBehaviour : StateMachineBehaviour {
    public float speed = 1;
    private Vector3 origin;
    private float waitTime;
    public float startWaitTime = 1;
    private Transform moveSpot;
    public float radius = 2;
    private Animator anim;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        origin = animator.transform.position; // store the origin where the patrol begins
        anim = animator;
        GameObject pos = new GameObject("Pos");
        pos.transform.position = animator.transform.position;
        moveSpot = pos.transform; // moveSpot is set to a transform

        waitTime = startWaitTime;
        moveSpot.position = randPos(); // set to a random position
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform enemyPos = animator.transform;
        float step = speed * Time.deltaTime;

        enemyPos.position = Vector2.MoveTowards(enemyPos.position, moveSpot.position, step); // move towards this position

        if (Vector2.Distance(enemyPos.position, moveSpot.position) < 0.2f) // if we have reached the position
        {
            // get a new position after idling for a bit
            
            if (waitTime <= 0 ) 
            {
                moveSpot.position = randPos();
                waitTime = startWaitTime;
            }
            else // be idle
            {
                waitTime -= Time.deltaTime;
            }
        }

    }
    public Vector3 randPos()
    {
        return origin + new Vector3 (Random.Range(-1 * radius, radius), Random.Range( -1 * radius, radius), 0);
    }
}