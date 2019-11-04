using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimController : MonoBehaviour
{
    public float nakedAttackPower = 1; // the damage dealt on collision
    private GameObject player;
    [HideInInspector]
    public bool isVisible;
    private Animator animator;
    public float respawnRadius = 0;
    private float distance = -1;
    [HideInInspector]
    private Vector3 StartPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // load in the player
        animator = gameObject.GetComponent<Animator>(); // load in the attatched animator
        StartPos = gameObject.transform.position; // store the original position of this gameObject
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("distance", distance); // set an animator float variable for 
        distance = (player.transform.position - transform.position).magnitude; // how far away this object is from the player
        
        /*
         * if the enemy is visible (in either the main camera OR the scene camera in the editor)
         * AND the enemy is far enough away
         */
        if (!isVisible && distance > respawnRadius) 
        {
            distance = -1; // the enemy is very far away
            animator.gameObject.transform.position = StartPos; // reset the enemy to it's original position
        }

    }
    private void OnBecameVisible() // when the gameobject is visible from the camera (or scene preview)
    {
        isVisible = true;
    }
    private void OnBecameInvisible() // when the gameobject is invisible from the camera (and scene preview)
    {
        isVisible = false;
    }

    private void OnTriggerEnter2D(Collider2D other) // when this object enters another trigger
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            if (other.gameObject.TryGetComponent<Health>(out Health component)) // if you are using my health script
            {
                other.gameObject.GetComponent<Health>().damageHealth(nakedAttackPower, gameObject); // damage the player
            }
            DisableAnimator(); // stop moving for 1 second
        }
        else if (other.gameObject.tag.Equals("Weapon"))
        {
            DisableAnimator(); // stop moving for 1 second
        }
    }

    void DisableAnimator()
    {
        animator.enabled = false;
        Invoke("EnableAnimator", 1f); // Enable the animator in 1 second
    }
    void EnableAnimator()
    {
        animator.enabled = true;
    }
}
