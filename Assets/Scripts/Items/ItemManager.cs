using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private PlayerWeaponManager playerWeapon;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = true;
    }
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.name == "Player")
        {
            playerWeapon = collision.GetComponent<PlayerWeaponManager>();
            playerWeapon.inTrigger = true;

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
            playerWeapon.inTrigger = false;
        }
    }

    IEnumerator wait()
    {
        if (playerWeapon.Weapon != null)
        {
            playerWeapon.dropWeapon();
        }
        yield return new WaitForSeconds(0.005f);
        playerWeapon.Weapon = gameObject;
    }
}
