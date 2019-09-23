using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
<<<<<<< HEAD
    public List<GameObject> Weapons;
    
    void AddWeapon(GameObject Weapon)
    {
        Weapons.Add(Weapon);
=======
    public List<Weapon> weapons;

    void AddWeapon(Weapon item)
    {
        weapons.Add(item);
>>>>>>> ba5f1e9873c8ceaab2407f84c9cb4de1a7a3f9cf
    }
}
