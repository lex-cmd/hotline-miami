using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UZIWeapon : Weapon
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public override void Action(Vector3 direction)
    {
        Debug.DrawLine(transform.position, direction, Color.red, 10f, false);
        Debug.Log(WeaponName + " is shoting");
    }
}
