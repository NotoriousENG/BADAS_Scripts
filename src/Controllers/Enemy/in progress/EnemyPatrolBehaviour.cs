using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolBehaviour : StateMachineBehaviour {
    public float speed;
    private Vector3 origin;
    private float waitTime;
    public float startWaitTime = 1;
    private Transform moveSpot;
    public float radius;
    private Animator anim;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        origin = animator.transform.position;
        anim = animator;
        GameObject pos = new GameObject("Pos");
        pos.transform.position = animator.transform.position;
        moveSpot = pos.transform;

        waitTime = startWaitTime;
        moveSpot.position = randPos();
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
                moveSpot.position = randPos();
                waitTime = startWaitTime;
            }
            else
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