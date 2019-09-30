using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [HideInInspector]public List<Weapon> weapons;
    private Equipment equipment;

    private void Start() 
    {
        equipment = gameObject.GetComponent<Equipment>();
    }

    private void Update() 
    {
        if(Input.GetKeyDown("q"))
        {
            Weapon item = new Weapon();
            item.weaponName = "Sword";
            item.weaponClass = WeaponClass.Sword;
            item.power = 1f;

            AddWeapon(item);
            equipment.equippedWeapon = item;
            equipment.equipedName = item.weaponName;
            Debug.Log(equipment.equippedWeapon.weaponName);
        }
    }
    void AddWeapon(Weapon item)
    {
        weapons.Add(item);
    }
}
