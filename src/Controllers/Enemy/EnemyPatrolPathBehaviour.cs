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
    private Animator anim;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        thisObject = animator.gameObject;
        if (PathNodes.Count ==0)
        {
            Transform paths = thisObject.transform.parent.Find("Paths"); // load in an empty named Paths that contains transforms
            foreach (Transform path in paths)
            {
                PathNodes.Add(path); // add every path to our list
            }
        }
        
        nextPos = PathNodes[0]; // the first target is the first transform

        anim = animator;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        navigate();
    }
    
    private void setNextNode()
    {
        nextPos = PathNodes[i]; // set the next position
        if (i < PathNodes.Count - 1) // if we are within bounds and going forwards
        {
            if (!inReverse)
            {
                i++; // increment the iterator for the next time this function is called
            }
            else 
            {
                i--; // decrement the iterator for the next time this function is called
                if (i == 0)
                {
                    inReverse = false;
                }
            }
        }
        else
        {
            if (isLoop)
            {
                i = 0;
            }
            else 
            {
                inReverse = true;
                i --;
            }
        }
    }

    private void navigate()
    {
        Vector2 dist = nextPos.position - thisObject.transform.position;
        dist.x = Mathf.Abs(dist.x);
        dist.y = Mathf.Abs(dist.y);

        Vector2 close = new Vector2 (0.1f,0.1f);

        if(dist.x < close.x && dist.y < close.y) // if we have reached this position
        {
            // Debug.Log("Made it");
            setNextNode(); // set the next position
        }
        
        float step = speed * Time.deltaTime;
        thisObject.transform.position = Vector3.MoveTowards(thisObject.transform.position, nextPos.position, step); // move towards the next position

        
        Vector2 moveDirs = (nextPos.position - thisObject.transform.position).normalized;
        EnemyAnimController animController = anim.gameObject.GetComponent<EnemyAnimController>();
        animController.inputVector = moveDirs;
        // Debug.Log(moveDirs);
    }
}
