﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Enemy : NetworkBehaviour {
    [SyncVar]
    public float health, speed, attackDmg, attackSpeed;
    public GameObject[] enemyCor;

    public Enemy()
    {
        speed = 3.0f;
        health = 150.0f;
        attackDmg = 25.0f;
        attackSpeed = 2.5f;
    }

    //sync some values to server 
    [Command]
    public void CmdsyncToServer(float damage)
    {
        health -= damage;
        speed = speed;
        attackDmg = attackDmg;
    }
    

    void Update()
    {
        if (health <= 0)
            Destroy(gameObject);
        //CmdsyncToServer();
    }
    public void setHitDamage(float damage)
    {
        if (!isServer)
            return;

        health -= damage;

        RpcDamage(damage);
    }
    [ClientRpc]
    void RpcDamage(float damage)
    {
        if (isLocalPlayer)
        health -= damage;
    }
    void Start()
    {
        enemyCor = GameObject.FindGameObjectsWithTag("enemyCor");
    }
    
}