using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float capacity = 3f;
    public float current;

    private void Awake() 
    {
        current = capacity; // on awake, have full health
    }

    public void damageHealth(float damage)
    {
        current -= damage; // take damage (Negative Values Heal)

        if (current <= 0) // health is depleted
        {
            Kill();
        }
    }

    private void Kill() // call when health is depleted
    {
        gameObject.SetActive(false); // disable game object
    }
}
