using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This script is used to draw Gizmos lines between every child's transforms of a gameObject (most likely an empty)
 * Useful for degugging AI patrol pathing 
 */
public class DrawTransformLines : MonoBehaviour
{
    private void OnDrawGizmos() // called in the editor only (useful for debug)
    {
        Gizmos.color = Color.blue; // every gizmos drawn from here on out in this script will be blue

        for (int i = 0; i < transform.childCount; i++) // go through every child
        {
            Transform curr = transform.GetChild(i); // the current child

            if (i+1 < transform.childCount) // if there is a child after this
            {
                Transform next = transform.GetChild(i+1); // get the next child
                Gizmos.DrawLine(curr.position, next.position); // draw a line between the current child and the next
            }
            else 
            {
                Transform next = transform.GetChild(0); // get the first child
                Gizmos.color = Color.red; // this line will be red
                Gizmos.DrawLine(curr.position, next.position); // draw a line between the current (last) child and the first
            }
            
        }
    }
}
