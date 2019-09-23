
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    private Inventory inventory;
    public GameObject equippedWeapon;
    private GameObject wep;

    private bool isPlayer, navigateForward, navigateBack;

    private void Start() 
    {
        inventory = gameObject.GetComponent<Inventory>(); // can access an inventory
        EquipWeapon(1);
        if (gameObject.tag == "Player")
        {
            isPlayer = true;
        }   
    }

    private void Update() {
        if (isPlayer)
        {
            navigateForward = Input.GetKeyDown("1");
            navigateBack = Input.GetKeyDown("2");
        }


        if (navigateBack)
        {
            EquipWeapon(-1);
        }
        else if (navigateForward)
        {
            EquipWeapon(1);
        }
    }
    void EquipWeapon(int step)
    {
        int capacity = inventory.Weapons.Capacity;
        int index = inventory.Weapons.IndexOf(equippedWeapon); // get index
        Debug.Log("Index: " + index);

        /*  if we are on item 9 going to item 10 (nonexistent) 
        in a 10 capacity list (0...9), loop back to start */
        if(index + step >= capacity) 
        {
            index = 0;
        }
        // if we are trying to reach a negative index (does not exist)
        else if (index + step < 0 )
        {
            index = capacity - 1; // go to last item in the list
        }
        else
        {
            index = index + step;
        }

        if (equippedWeapon != null)
        {
            Destroy(wep); // destroy the weapon
        }

        equippedWeapon = inventory.Weapons[index]; // set the equipped weapon
        wep = Instantiate(equippedWeapon); // make a copy of the weapon for this gameObject 

        wep.transform.SetParent(gameObject.transform.Find("Hand")); // parent the weapon to this gameObject's transform
        wep.transform.localPosition = Vector3.zero + wep.GetComponent<Weapon>().HandleOffset;
        wep.SetActive(true);
    }
}
