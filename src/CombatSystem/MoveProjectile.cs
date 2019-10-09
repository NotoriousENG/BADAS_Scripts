using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{
    public Vector3 MoveDir; // the direction to move towards e.g. (-1,0,0) is left
    public float speed = 1; // the speed of movement
    public float Power = 1; // the power of the projectile
    [HideInInspector]
    public GameObject Shooter;

    void Start()
    {
        Animator animator = gameObject.GetComponent<Animator>(); // to setup animations
        if (animator != null)
        {
            setAnimatorVariables(animator);
        }
    }
    // Update is called once per frame
    void Update()
    {
        Move();

    }
    private void Move()
    {
        transform.position += new Vector3(MoveDir.x * speed * Time.deltaTime,
                                            MoveDir.y * speed * Time.deltaTime,
                                                MoveDir.z * speed * Time.deltaTime);
    }

    private void setAnimatorVariables(Animator animator)
    {
        // used to setup animations 
        // e.g. facing directions for arrows
        animator.SetFloat("moveX", MoveDir.x);
        animator.SetFloat("moveY", MoveDir.y);
    }
    private void OnBecameInvisible() // when the object exits the game and scene camera
    {
       killObj();
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag.Equals("Enemy"))
        {
            Health enemyHealth = other.gameObject.GetComponent<Health>();
            enemyHealth.damageHealth(Power);
            killObj();
        }
        else if (other.gameObject != Shooter && other.gameObject.tag != "Weapon")
        {
            killObj();
        }
        
    }

    private void killObj()
    {
        gameObject.SetActive(false);
        Destroy(gameObject);
    }
}
