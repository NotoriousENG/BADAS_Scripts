using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 #if UNITY_EDITOR
 using UnityEditor;
 #endif
public class Weapon : MonoBehaviour
{
    public bool useLiteMode;
    [HideInInspector]
    public bool canKillNPCs;

    [HideInInspector]
    public float Speed = 1; // {get;set;}
    public float Power = 1; // {get;set;}
    [HideInInspector]
    public float attackRadius;
    
    [HideInInspector]
    public Vector3 HandleOffset;
    // weapon types : swing/stab/projectile

    [HideInInspector]
    public int attackAnimationToPlay = 0;
    public bool isProjectileWeapon;

    [HideInInspector] // HideInInspector makes sure the default inspector won't show these fields.
    public GameObject Projectile;

    private SpriteRenderer spriteRenderer; 
    private Animator parentAnimator;

    private void Start() 
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        parentAnimator = transform.root.GetComponent<Animator>(); 
    }
   private void Update() 
    {
        transform.localPosition = HandleOffset; // uncomment this for debugging, figure out your offset
        if (transform.parent.gameObject.tag.Equals("Hand"))
        {
            Animator parentAnimator = transform.parent.gameObject.GetComponent<Animator>();
            if (!useLiteMode)
            {
                parentAnimator = transform.parent.parent.gameObject.GetComponent<Animator>();
            }
            Vector2 lastDirs = new Vector2 (parentAnimator.GetFloat("lastHorizontal"), parentAnimator.GetFloat("lastVertical"));
            
            // we need to put the weapon behind the character when they are facing left or up 
            // (Assuming your characters are all right handed)
            Debug.Log(lastDirs);
            if (lastDirs.x < 0 || lastDirs.y > 0 && !(lastDirs.y < 0 || lastDirs.x > 0))
            {
                spriteRenderer.sortingLayerName = "BelowCharacters";
            }
            else 
            {
                spriteRenderer.sortingLayerName = "AboveCharacters";
            }
        }
        if (useLiteMode && transform.parent.gameObject.tag.Equals("Player"))
        {
            
        }
    } 
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag.Equals("Enemy") && other.TryGetComponent<Health>(out Health component) || other.tag.Equals("NPC") && canKillNPCs)
        {
            Health enemyHealth = other.gameObject.GetComponent<Health>(); // get the health component
            enemyHealth.damageHealth(Power, gameObject); // call the damage function inb the health script
        }
    }

    /* private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.tag.Equals("Enemy") && Input.GetButtonDown("Fire1") && other.TryGetComponent<Health>(out Health component))
        {
            Health enemyHealth = other.gameObject.GetComponent<Health>();
            enemyHealth.damageHealth(Power);
        }
    } */
}

 #if UNITY_EDITOR
 [CustomEditor(typeof(Weapon))] // allow the player to add a projectile if this is a projectile weapon
 public class RandomScript_Editor : Editor
 {
     public override void OnInspectorGUI()
     {
         DrawDefaultInspector(); // for other non-HideInInspector fields
 
         Weapon script = (Weapon)target;

         if (script.isProjectileWeapon) // if bool is true, show other fields
         {
             script.Projectile = EditorGUILayout.ObjectField("Projectile", script.Projectile, typeof(GameObject), true) as GameObject;
         }
         if (!script.useLiteMode)
         {
             script.Speed = EditorGUILayout.FloatField("Speed", script.Speed);
             script.HandleOffset = EditorGUILayout.Vector3Field("HandleOffset", script.HandleOffset);
             script.attackAnimationToPlay = EditorGUILayout.IntField("attackAnimationToPlay", script.attackAnimationToPlay);
         }
         else if (script.useLiteMode)
         {
             script.attackRadius = EditorGUILayout.FloatField("attackRadius", script.attackRadius);
         }
     }
 }
 #endif
