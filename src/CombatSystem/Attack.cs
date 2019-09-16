using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private Vector2 center;
    private float radius;
    private float damage;

    public void SetWeapon(Transform attacker)
    {
        center = new Vector2(attacker.position.x, attacker.position.y);
        radius = 3f;
        damage = 1f;
    }

    public void Strike()
    {
        Collider2D[] hits =  Physics2D.OverlapCircleAll(center, radius);
        foreach (Collider2D hit in hits)
        {
            Health health = hit.gameObject.GetComponent<Health>();
            if (health != null) // if the object has health
            {
                health.damageHealth(damage);
            }
        }
    }
}
