using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolPathBehaviour : StateMachineBehaviour
{
    public float speed = 1;
    public bool isLoop;
    private bool inReverse;
    public List<Transform> PathNodes;
    public Transform nextPos;
    private GameObject thisObject;
    private int i;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        thisObject = animator.gameObject;
        Transform paths = thisObject.transform.parent.Find("Paths");
        foreach (Transform path in paths)
        {
            PathNodes.Add(path);
        }
        nextPos = PathNodes[0];

        
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        navigate();
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

    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.blue;

        for (int i = 0; i < PathNodes.Count - 1; i++)
        {
            Transform curr = PathNodes[i];
            Transform next = PathNodes[i + 1];

            Gizmos.DrawLine(curr.position, next.position);
        }
    }
    
    private void setNextNode()
    {
        if (i < PathNodes.Count && !inReverse)
        {
            nextPos = PathNodes[i];
            i++;
        }
        else if (isLoop)
        {
            i = 0;
            nextPos = PathNodes[i];
            i++;
        }
        else if (!isLoop && i != 0)
        {
            i -= 2;
            nextPos = PathNodes[i];
            i--;
            inReverse = true;
        }
        else if (inReverse)
        {
            nextPos = PathNodes[i];
            i--;
            if (i < 0)
            {
                i = 0;
                inReverse = false;
            }
        }
        else
        {
            Debug.Log("Logic Error");
        }
        
    }

    private void navigate()
    {
        if(thisObject.transform.position == nextPos.position)
        {
            setNextNode();
        }
        
        float step = speed * Time.deltaTime;
        thisObject.transform.position = Vector3.MoveTowards(thisObject.transform.position, nextPos.position, step);

        
    }
}
