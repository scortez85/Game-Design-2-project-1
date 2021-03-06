﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerMove : NetworkBehaviour
{
    [SyncVar]
    public float speed, speedMultiplier, turning;
    private string playerState;
    private hashId hashID;
    public GameObject projectile, projectileSpawn,cameraRig,playerHud;
    private Animator ani;
    
    

    //test
    //public GameObject player1, player2;
        //end test

    void Start()
    {
        if (isLocalPlayer)
        {
            gameObject.name = "localPlayer";
        
        
        
        GameObject cameras = (GameObject)Instantiate(cameraRig, transform.position, transform.rotation);
        GameObject hud = (GameObject)Instantiate(playerHud, transform.position, transform.rotation);
        hud.GetComponent<playerHud>().player = gameObject;
        cameras.GetComponent<fpsCam>().player = gameObject;
        ani = GetComponent<Animator>();
        hashID = GetComponent<hashId>();
        speed = 2f;
        turning = 50f;
            //gameObject.name = "localPlayer";
        }
        else gameObject.name = "netPlayer";

    }

    void Update()
    {
        //speed = .6f;
        if (!isLocalPlayer)
            return;
        
        //fire/use weapon
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //CmdFight();
        }
        float vert = Input.GetAxis("Vertical");
        float horiz = Input.GetAxis("Horizontal");
        float turn = Input.GetAxis("Turning");
        float pitch = Input.GetAxis("Pitch");

        if (!vert.Equals(0))
        {
            //transform.Translate(0, 0, vert * Time.deltaTime * (speed + speedMultiplier));
            ani.SetFloat(hashID.speed, 5.5f);
        }
        else
            ani.SetFloat(hashID.speed, 0f);
       // if (!horiz.Equals(0))
       if (!turning.Equals(0))
        {
            //transform.Rotate(0, turn * turning * Time.deltaTime, 0);
        }

        //move and rotate player
        transform.Translate(horiz * speed *  Time.deltaTime, 0, vert * Time.deltaTime * (speed + speedMultiplier));
        transform.Rotate(pitch * turning * Time.deltaTime, turn * turning * Time.deltaTime, 0);
    }

    [Command]
    void CmdFight()
    {
        GameObject myProjectile = (GameObject)Instantiate(projectile, projectileSpawn.transform.position, projectileSpawn.transform.rotation);
        myProjectile.GetComponent<Rigidbody>().velocity = transform.forward * 6.0f;
        NetworkServer.Spawn(GetComponent<NetworkManager>().spawnPrefabs[2]);
        NetworkServer.Spawn(myProjectile);//send obj to server 
        Destroy(myProjectile, 4);//destroy in 4 sec
    }
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        //add stuff to local player
    }

    //void OnCollisionEnter(Collision col)
    void OnTriggerEnter(Collider col)
    {
        //Debug.Log("hit" + col.name);
        if (col.tag.Equals("teleporter") )
        {
         

                transform.position = col.gameObject.GetComponent<telePort>().targetPos;
        }

    }

}