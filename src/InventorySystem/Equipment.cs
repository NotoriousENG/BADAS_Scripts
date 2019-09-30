using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : MonoBehaviour
{
    private Inventory inventory;
    public string equipedName = "none";
    [HideInInspector]public Weapon equippedWeapon;
    private bool isPlayer, navigateForward, navigateBack;

    private void Start() 
    {
        inventory = gameObject.GetComponent<Inventory>(); // can access an inventory
        if (gameObject.tag == "Player")
        {
            isPlayer = true;
        }   
    }

    private void Update() {
        if (isPlayer)
        {
            navigateForward = Input.GetKeyDown("s");
            navigateBack = Input.GetKeyDown("a");
            if (equippedWeapon != null)
            {
                equipedName = equippedWeapon.weaponName;
            }
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
        int capacity = inventory.weapons.Capacity;
        int index = inventory.weapons.IndexOf(equippedWeapon);
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
        equippedWeapon = inventory.weapons[index];
    }
}
