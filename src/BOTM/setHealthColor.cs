using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class setHealthColor : MonoBehaviour
{
    public bool isBlue;
    private CombatMode combatMode;
    private Health playerHealth;
    public List<GameObject> children;

    private void Start() 
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        combatMode = player.GetComponent<CombatMode>();
        playerHealth = player.GetComponent<Health>();
    }
    private void Update() 
    {
        if (isBlue.Equals(combatMode.isBlue))
        {
            SetChildren();       
        }
        else
        {
            DisableAll();
        }
    }

    private void SetChildren()
    {
        foreach (GameObject child in children)
        {
            Int32.TryParse(child.name, out int num);
            if (num <= playerHealth.current)
            {
                child.SetActive(true);
            }
            else
            {
                child.SetActive(false);
            }
        }
    }

    private void DisableAll()
    {
        foreach (GameObject child in children)
        {
            child.SetActive(false);
        }
    }

}
