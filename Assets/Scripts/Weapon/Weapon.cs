using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    // Start is called before the first frame update
    public float fireRate;
    public float damage;
    public string WeaponName;
    public bool inSlot;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        inSlot = false;
    }

    // Update is called once per frame
    void Update()
    {
        spriteRenderer.enabled = inSlot;
    }

    public abstract void Action(Vector3 direction);
}
