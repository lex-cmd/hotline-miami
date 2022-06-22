using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotAction : MonoBehaviour
{
    private Enemy enemy;
    private GameObject player;
    public GameObject Bullet;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Action();
    }

    private void Action()
    {

    }
}
