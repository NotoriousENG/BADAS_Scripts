using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float capacity = 3f;
    public float current;

    private Color Red = new Color(255,0,0,255);
    private Color Default = new Color (255,255,255,255);
    private SpriteRenderer spriteRenderer;
    private float blinkTime = .25f;
    private float waitTime = 1f;

    private void Awake() 
    {
        current = capacity; // on awake, have full health
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
    }

    private void Update() 
    {
        if (spriteRenderer.color == Red &&  Time.timeSinceLevelLoad > waitTime)
        {
            spriteRenderer.color = Default;
        }
    }
    public void damageHealth(float damage)
    {
        current -= damage; // take damage (Negative Values Heal)
        spriteRenderer.color = Red; // RGBA -> Red
        waitTime = Time.timeSinceLevelLoad + blinkTime;

        if (current <= 0) // health is depleted
        {
            Kill();
        }
        
    }

    private void Kill() // call when health is depleted
    {
        gameObject.SetActive(false); // disable game object
        Destroy(gameObject);
    }
}
