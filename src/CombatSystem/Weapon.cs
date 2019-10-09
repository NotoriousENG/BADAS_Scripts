﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 #if UNITY_EDITOR
 using UnityEditor;
 #endif

public enum WeaponClass
{
    Swing, Shoot, Spin
}
public class Weapon : MonoBehaviour
{
    public float Speed = 1; // {get;set;}
    public float Power = 1; // {get;set;}
    public Vector3 HandleOffset;
    // weapon types : swing/stab/projectile

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
            Animator parentAnimator = transform.parent.parent.gameObject.GetComponent<Animator>();
            Vector2 lastDirs = new Vector2 (parentAnimator.GetFloat("lastHorizontal"), parentAnimator.GetFloat("lastVertical"));
            
            if (lastDirs.x < 0 || lastDirs.y > 0 && !(lastDirs.y < 0 || lastDirs.x > 0))
            {
                spriteRenderer.sortingLayerName = "Gameplay";
            }
            else 
            {
                spriteRenderer.sortingLayerName = "Foreground";
            }
        }
    } 
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag.Equals("Enemy"))
        {
            Health enemyHealth = other.gameObject.GetComponent<Health>();
            enemyHealth.damageHealth(Power);
        }
    }

    private void OnTriggerStay2D(Collider2D other) 
    {
        if (other.tag.Equals("Enemy") && Input.GetButtonDown("Fire1"))
        {
            Health enemyHealth = other.gameObject.GetComponent<Health>();
            enemyHealth.damageHealth(Power);
        }
    }
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
     }
 }
 #endif
