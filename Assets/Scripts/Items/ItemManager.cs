using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private PlayerWeaponManager playerWeapon;
    void Start()
    {
    }
    void Update()
    {
                
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            playerWeapon = collision.GetComponent<PlayerWeaponManager>();
            collision.GetComponent<PlayerWeaponManager>().inTrigger = true;

            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                StartCoroutine("wait");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            collision.GetComponent<PlayerWeaponManager>().inTrigger = false;
        }
    }

    IEnumerator wait()
    {
        if (playerWeapon.Weapon != null)
        {
            playerWeapon.dropWeapon();
        }
        yield return new WaitForSeconds(0.05f);
        playerWeapon.Weapon = gameObject;
        Destroy(gameObject);
    }
}
