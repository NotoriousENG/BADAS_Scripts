using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolBehaviour : StateMachineBehaviour {

    // public Transform[] pathNodes;
    private Transform enemyTransform;
    // public Transform pointA;
    // public Transform pointB;
    public bool isRight = true;
    public float speed = 0.3f;
    private Vector3 pointAPosition;
    private Vector3 pointBPosition;
    
    

    

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        enemyTransform = animator.gameObject.transform;
        /* foreach(Transform pathNode in pathNodes)
        {
           Debug.Log(pathNode.position);
           ApproachNode(pathNode);
        } */
        pointAPosition = new Vector3(-3.52f,0,0); // pointA.position.x, 0, 0);
        pointBPosition = new Vector3(3.24f,0,0); // pointB.position.x, 0, 0);
        
    }

    /* void ApproachNode(Transform pathNode)
    {
        enemyTransform.position = Vector3.MoveTowards(enemyTransform.position, pathNode.position, speed);
    } */


    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector3 thisPosition = new Vector3(enemyTransform.position.x, 0, 0);
        if (isRight)
        {
            enemyTransform.position = Vector3.MoveTowards(enemyTransform.position, pointBPosition, speed);
            if (thisPosition.Equals(pointBPosition))
            {
                //Debug.Log ("Position b");
                isRight = false;
                animator.gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        else
        {
            enemyTransform.position = Vector3.MoveTowards(enemyTransform.position, pointAPosition, speed);
            if (thisPosition.Equals(pointAPosition))
            {
                //Debug.Log ("Position a");
                isRight = true;
                animator.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
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