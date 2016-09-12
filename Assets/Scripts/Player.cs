using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {
    public GameObject netman;
    [SyncVar]
    public int kills, deaths, ammo, killStreak, modelID;
    [SyncVar]
    public float health, speed, attackSpeed;
    [SyncVar]
    public string teamID,playerName;
    [SyncVar]
    public List<PickUp> pickUps;



    public Player()
    {
        kills = 0;
        deaths = 0;
        ammo = 0;
        killStreak = 0;
        speed = 2.5f;
        attackSpeed = 1.5f;
        health = 100.0f;
        pickUps = new List<PickUp>();
        teamID = "Blue";
    }
    public int getPlayerKills()
    {
        return kills;
    }
    public int getNumPickUps()
    {
        return pickUps.Count;
    }
    public int getNumAmmo()
    {
        return ammo;
    }
    public int getPlayerDeaths()
    {
        return deaths;
    }
    public string getPlayerTeam()
    {
        return teamID;
    }
    public void setPlayerTeam(string team)
    {
        teamID = team;
    }
    public void setNumAmmo(int num)
    {
        ammo = num;
    }
    public void setPlayerHealth(float num)
    {
        health += num;
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
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        //kills += 1; this was a test and only a test
        //send value from local network manager to player then update host/server
        if (isLocalPlayer)
            playerName = netman.GetComponent<netConnect>().playerName;//GameObject.FindGameObjectWithTag("netManager").GetComponent<netConnect>().playerName;
        else playerName = players[1].GetComponent<Player>().netman.GetComponent<netConnect>().playerName;
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
        playerName = playerName;
    }



    }
