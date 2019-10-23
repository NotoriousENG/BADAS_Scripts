using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolBehaviour : StateMachineBehaviour {
    public float speed;
    private float waitTime;
    public float startWaitTime;
    private Transform moveSpot;
    public float minX, maxX, minY, maxY;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject pos = new GameObject("Pos");
        pos.transform.position = animator.transform.position;
        moveSpot = pos.transform;

        waitTime = startWaitTime;
        moveSpot.position = new Vector2(Random.Range(minX,maxX), Random.Range(minY,maxY));
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform enemyPos = animator.transform;
        float step = speed * Time.deltaTime;

        enemyPos.position = Vector2.MoveTowards(enemyPos.position, moveSpot.position, step);

        if (Vector2.Distance(enemyPos.position, moveSpot.position) < 0.2f)
        {
            if (waitTime <= 0 )
            {
                moveSpot.position = new Vector2(Random.Range(minX,maxX), Random.Range(minY,maxY));
                waitTime = startWaitTime;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }

    }

    
    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }

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