using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimController : MonoBehaviour
{
    private GameObject player;
    private bool isVisible;
    private Animator animator;
    public float visionRadius = 0;
    private float distance = -1;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("distance", distance); 
        if (isVisible)
        {
            distance = (player.transform.position - transform.position).magnitude;
        }
        else 
        {
            distance = -1;
        }

    }
    private void OnBecameVisible() 
    {
        isVisible = true;
    }
    private void OnBecameInvisible() 
    {
        isVisible = false;
    }
}
