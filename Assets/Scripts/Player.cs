using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {
    [SyncVar]
    public int kills, deaths, ammo;
    [SyncVar]
    public float health, speed;
    [SyncVar]
    private string teamID;
    [SyncVar]
    private int killStreak, modelID;
    [SyncVar]
    private List<PickUp> pickUps;



    public Player()
    {
        kills = 0;
        deaths = 0;
        ammo = 0;
        killStreak = 0;
        speed = 2.5f;
        pickUps = new List<PickUp>();
    }
    public int getPlayerKills()
    {
        return kills;
    }
    public int getNumPickUps()
    {
        return pickUps.Count;
    }

    public void OnCollisionEnter(Collision coll)//had to change from collider to collision
    {
        if(coll.gameObject.tag.Equals("PickUp"))
        {
            GameObject.Destroy(coll.gameObject);
            pickUpSticks(coll.gameObject.name);
        }
    }

    public void pickUpSticks(string name)
    {
        PickUp pickedUp = new PickUp(name);
        pickUps.Add(pickedUp);
    }


    void Start()
    {
    }

    void Update()
    {
        //kills += 1; this was a test and only a test

        if (isLocalPlayer)
            return;//this sends values only to other players


        CmdsyncToServer();
        
    }

    //sync some values to server 
    [Command]
    void CmdsyncToServer()
    {
        kills = kills;
        deaths = deaths;
        ammo = ammo;
        health = health;
        speed = speed;
        teamID = teamID;
        killStreak = killStreak;
        modelID = modelID;
        pickUps = pickUps;
    }

    }
