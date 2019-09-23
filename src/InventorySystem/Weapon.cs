using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
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
=======
public enum WeaponClass { Sword, Axe, Lance }
public class Weapon : MonoBehaviour
{
    public string weaponName = "none";
    public WeaponClass weaponClass = WeaponClass.Sword;
    public float power = 1f;
    public float speed = 1f;

    void setClassStats()
    {
        switch (weaponClass)
        {
            case WeaponClass.Sword:
            {
                speed = 2f;
                break;
            }
            case WeaponClass.Axe:
            {
                speed = 1f;
                break;
            }
            case WeaponClass.Lance:
            {
                speed = 3f;
                break;
            }
>>>>>>> ba5f1e9873c8ceaab2407f84c9cb4de1a7a3f9cf
        }
    }
}
