using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimController : MonoBehaviour
{
    public float nakedAttackPower = 1;
    private GameObject player;
    [HideInInspector]
    public bool isVisible;
    private Animator animator;
    public float visionRadius = 0;
    private float distance = -1;
    [HideInInspector]
    public Vector3 StartPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = gameObject.GetComponent<Animator>();
        StartPos = gameObject.transform.position;
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

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Player"))
        {
            other.gameObject.GetComponent<Health>().damageHealth(nakedAttackPower);
            DisableAnimator();
        }
        else if (other.gameObject.tag.Equals("Weapon"))
        {
            DisableAnimator();
        }
    }

    void DisableAnimator()
    {
        animator.enabled = false;
        Invoke("EnableAnimator", 1f);
    }
    void EnableAnimator()
    {
        animator.enabled = true;
    }
}
