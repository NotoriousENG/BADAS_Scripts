﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> Weapons;
    
    void AddWeapon(GameObject Weapon)
    {
        Weapons.Add(Weapon);
    }
}
