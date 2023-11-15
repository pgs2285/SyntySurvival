using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentEquipWeapon : MonoBehaviour
{
    #region Variables
    [HideInInspector] public int weaponID;
    private GameObject _weaponPref;
    private Animator animator;

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
        
        Instantiate(_weaponPref, weaponPos.position, weaponPos.rotation, weaponPos);   
        
    }
    #endregion Properties
    #region Unity Methods

    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            animator.SetTrigger("Attack");
            Debug.Log("Attack");
        }
    }
    #endregion Unity Methods
}
