using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        }
    }
}
