using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetItem : MonoBehaviour
{
    #region Variables

    public int weaponID;
    private Transform spawnPoint;
    #endregion Variables

    #region Unity Methods

    private void Start()
    {
        spawnPoint = GameObject.Find("SpawnPoint").transform;
    }

    #endregion Unity Methods

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<CurrentEquipWeapon>().weaponID = weaponID;
            
            other.GetComponent<CurrentEquipWeapon>().WeaponPref =
                Resources.Load("Prefabs/Weapon/"+ weaponID) as GameObject;
            // Debug.Log("Object rotation value" + other.GetComponent<CurrentEquipWeapon>().WeaponPref.transform.rotation );
            other.GetComponent<CurrentEquipWeapon>().equipWeapon();

            // 캐릭터 스폰포인트로 이동시키고 대기 맵 삭제시키기.(5,9,18)
            other.enabled = false;
            other.transform.position = spawnPoint.position;
            other.enabled =true;

            

        }
    }
    
}
