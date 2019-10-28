using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChicken : MonoBehaviour
{
    public Vector3 moveDir = new Vector3 (1,0,0);
    public float speed = 10;
    private bool isMoving;

    private void Update() 
    {
        if (isMoving)
        {
            Move();
        }
    }
    void Move()
    {
        transform.Translate(moveDir * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        isMoving = true;
    }

    private void OnBecameInvisible() 
    {
        if (isMoving)
        {
            Destroy(gameObject);
        }
    }


}
