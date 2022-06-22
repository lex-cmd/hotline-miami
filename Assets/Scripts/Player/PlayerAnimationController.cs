using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;

    private GameObject player;
    private PlayerWeaponManager playerWeapon;

    int weaponID = 0;
    void Start()
    {
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
        playerWeapon = player.GetComponent<PlayerWeaponManager>();
    }

    void Update()
    {
        //WeaponAnimation(playerWeapon.currentWeapon);
        animator.SetInteger("weapons", weaponID);
    }

    void WeaponAnimation(Weapon weapon)
    {
        switch (weapon.WeaponName)
        {
            case "Null":
                weaponID = 0;
                break;
            case "Pistol":
                weaponID = 1;
                break;
            case "UZI":
                weaponID = 2;
                break;
            default:

                break;
        }
    }
}
