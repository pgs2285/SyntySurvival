using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentEquipWeapon : MonoBehaviour
{
    #region Variables
    [HideInInspector] public int weaponID;
    private GameObject _weaponPref;

    public GameObject WeaponPref
    {
        get => _weaponPref;
        set => _weaponPref = value;
    }
    private GameObject _weaponEffect;
    public Transform weaponPos;

    #endregion Variables
    
    #region Properties

    public void equipWeapon()
    {
        Instantiate(_weaponPref, weaponPos.position, _weaponPref.transform.rotation, weaponPos);
        
    }
    #endregion Properties
}
