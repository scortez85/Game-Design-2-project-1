﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Enemy : NetworkBehaviour {
    [SyncVar]
    public float health, speed, attackDmg, attackSpeed;

    public Enemy()
    {
        speed = 3.0f;
        health = 150.0f;
        attackDmg = 25.0f;
        attackSpeed = 2.5f;
    }

    //sync some values to server 
    [Command]
    void CmdsyncToServer()
    {
        health = health;
        speed = speed;
        attackDmg = attackDmg;
    }

    void Update()
    {
        CmdsyncToServer();
    }
}
