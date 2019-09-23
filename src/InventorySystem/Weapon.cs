using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponClass
{
    Swing, Shoot, Spin
}
public class Weapon : MonoBehaviour
{
    // If you want do some OOP, use this
    /* // default constructor
    public Weapon(){}

    // constuctor
    public Weapon(string weaponName, WeaponClass _weaponClass, float range, float speed, float power, bool isMultiHitter)
    {
        WeaponName = weaponName;
        weaponClass = _weaponClass;
        Range = range;
        Speed = speed;
        Power = power;
        IsMultiHitter = isMultiHitter;
    }
    // properties */
    // public WeaponClass weaponClass; // {get; set;}
    public float Range; // {get; set;}
    public float Speed; // {get;set;}
    public float Power; // {get;set;}
    public bool IsMultiHitter; //{get;set;}
    public Vector3 HandleOffset;

   /*  private void Update() 
    {
        transform.localPosition = HandleOffset; // uncomment this for debugging, figure out your offset
    } */
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag.Equals("Enemy"))
        {
            Health enemyHealth = other.gameObject.GetComponent<Health>();
            enemyHealth.damageHealth(Power);
        }
    }
}
