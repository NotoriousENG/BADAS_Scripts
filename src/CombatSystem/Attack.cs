using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Vector2 center;
    private float radius;
    private float damage;

    private void Update() 
    {
        SetWeapon();
    }

    void SetWeapon()
    {
        center = new Vector2(transform.position.x, transform.position.y);
        radius = 3f;
        damage = 1f;
    }

    void Strike()
    {
        Collider2D[] hits =  Physics2D.OverlapCircleAll(center, radius);
        foreach (Collider2D hit in hits)
        {
            Health health = hit.gameObject.GetComponent<Health>();
            health.damageHealth(damage);
        }
    }
}
