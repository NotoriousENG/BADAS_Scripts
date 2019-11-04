using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTransformLines : MonoBehaviour
{
    private void OnDrawGizmos() 
    {
        Gizmos.color = Color.blue;

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform curr = transform.GetChild(i);

            if (i+1 < transform.childCount)
            {
                Transform next = transform.GetChild(i+1);
                Gizmos.DrawLine(curr.position, next.position);
            }
            else 
            {
                Transform next = transform.GetChild(0);
                Gizmos.color = Color.red;
                Gizmos.DrawLine(curr.position, next.position);
            }
            
        }
    }
}
