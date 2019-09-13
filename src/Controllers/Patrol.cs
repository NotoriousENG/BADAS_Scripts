using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour {

    public Transform[] pathNodes;
    public Transform pointA;
    public Transform pointB;
    public bool isRight = true;
    public float speed = 0.3f;
    private Vector3 pointAPosition;
    private Vector3 pointBPosition;
    // Use this for initialization
    void Start()
    {
        foreach(Transform pathNode in pathNodes)
        {
           Debug.Log(pathNode.position);
        }
        // pointAPosition = new Vector3(pointA.position.x, 0, 0);
        // pointBPosition = new Vector3(pointB.position.x, 0, 0);
    }

    void ApproachNode(Transform pathNode)
    {
        transform.position = Vector3.MoveTowards(transform.position, pathNode.position, speed);
    }

    // Update is called once per frame
    /* void Update()
    {
        Vector3 thisPosition = new Vector3(transform.position.x, 0, 0);
        if (isRight)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed);
            if (thisPosition.Equals(pointBPosition))
            {
                //Debug.Log ("Position b");
                isRight = false;
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, speed);
            if (thisPosition.Equals(pointAPosition))
            {
                //Debug.Log ("Position a");
                isRight = true;
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    } */
}