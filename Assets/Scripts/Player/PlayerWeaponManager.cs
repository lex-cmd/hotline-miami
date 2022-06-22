using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public GameObject Weapon;
    public Weapon currentWeapon;
    public bool inTrigger = false;

    void Start()
    {
    }
    
    void Update()
    {
        WeaponManager();
        TakeWeapon();
    }

    private void TakeWeapon()
    {

    }

    void WeaponManager()
    {
        if (Weapon != null)
        {
            currentWeapon = Weapon.GetComponent<Weapon>();
            Weapon.transform.position = gameObject.transform.position;

            if (Input.GetKeyDown(KeyCode.Mouse1) && !inTrigger)
            {
                dropWeapon();
            }
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                currentWeapon.Action(GetComponent<CharacterMovement>().mousePosition);
            }
        }
    }

    public void dropWeapon()
    {
        if (Weapon != null)
        {
            Instantiate(Weapon.gameObject, transform.position, Quaternion.identity);
            if (!inTrigger)
                Weapon = null;
        }
        else
        {
            Debug.Log("weapon is null");
        }
    }
}
