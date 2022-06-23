using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeaponManager : MonoBehaviour
{
    public GameObject Weapon;
    public Weapon currentWeapon;
    public bool inTrigger = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        Weapon = null;
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
            spriteRenderer = Weapon.GetComponent<SpriteRenderer>();
            spriteRenderer.enabled = false;


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
            Instantiate(Weapon, transform.position, Quaternion.identity);
            spriteRenderer.enabled = true;

            Destroy(Weapon);

            if (!inTrigger)
            {
                Weapon = null;
                currentWeapon = null;
            }
        }
        else
        {
            Debug.Log("weapon is null");
        }
    }
}
