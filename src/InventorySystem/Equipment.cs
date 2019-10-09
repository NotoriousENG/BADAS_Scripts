
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Equipment : MonoBehaviour
{
    private Inventory inventory;
    public GameObject equippedWeapon;
    private GameObject wep;
    private Animator animator;
    public Image UI_Image; // use to map to a UI element

    // private bool isPlayer, navigateForward, navigateBack;

    private void Start() 
    {
        animator = gameObject.GetComponent<Animator>();
        inventory = gameObject.GetComponent<Inventory>(); // can access an inventory
        EquipWeapon(1);
    }
    public void EquipWeapon(int step)
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
        UI_Image.sprite = wep.GetComponent<SpriteRenderer>().sprite; // change image in UI
    }
}
