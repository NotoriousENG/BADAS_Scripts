using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> Weapons; // the weapons this gameObject has access to
    // set in inspecter for default weapons

    void AddWeapon(GameObject weapon) // call from a script or eventTrigger to add a new weapon
    {
        Weapons.Add(weapon);
    }
}
