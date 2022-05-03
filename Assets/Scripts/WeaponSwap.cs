using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSwap : MonoBehaviour
{
    
    // array for weapons
    private int[] weapons;
    public int currentWeapon = 0;
    private bool swapWeapon = false;
    
    // Update is called once per frame
    void Update()
    {
        int previousWeapon = currentWeapon;
        
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (currentWeapon >= transform.childCount - 1)
                currentWeapon = 0;
            else
                currentWeapon++;
        }
        
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            if (currentWeapon == 0)
                currentWeapon = transform.childCount - 1;
            else
                currentWeapon--;
        }

        if (previousWeapon != currentWeapon)
        {
            SelectWeapon();
        }
        
        
    }

    void SelectWeapon()
    {
        int i = 0;
        foreach (Transform weapon in transform)
        {
            if(i == currentWeapon)
                weapon.gameObject.SetActive(true);
            else
                weapon.gameObject.SetActive(false);
            i++;
        }
    }
}
