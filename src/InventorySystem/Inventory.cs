using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> Weapons;

    void AddWeapon(GameObject weapon)
    {
        Weapons.Add(weapon);
    }
}
