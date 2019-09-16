using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<Weapon> weapons;

    void AddWeapon(Weapon item)
    {
        weapons.Add(item);
    }
}
