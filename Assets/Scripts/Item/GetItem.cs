using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    #region Variables

    public int weaponID;
    #endregion Variables
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CurrentEquipWeapon>().weaponID = weaponID;
            other.GetComponent<CurrentEquipWeapon>().WeaponPref =
                Resources.Load("Prefabs/Weapon/"+ weaponID) as GameObject;
            other.GetComponent<CurrentEquipWeapon>().equipWeapon();
        }
    }
    
}
