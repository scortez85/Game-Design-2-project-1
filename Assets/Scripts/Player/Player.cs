using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;

public class Player : NetworkBehaviour {
    public GameObject netman;
    [SyncVar]
    public int kills, deaths, ammo, killStreak, numOfPickups;
    [SyncVar]
    public float health, speed, damage, damageMultiplier, attackSpeed, speedTimer, damageTimer;
    [SyncVar]
    public string teamID,playerName;
    [SyncVar]
    public List<string> pickUps;



    public Player()
    {
        kills = 0;
        deaths = 0;
        ammo = 0;
        killStreak = 0;
        speed = 2.5f;
        attackSpeed = 1.5f;
        health = 100.0f;
        pickUps = new List<string>();
        teamID = "Blue";
        speedTimer = 0;
        damageTimer = 0;
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
            pickUpSticks(coll.gameObject.GetComponent<PickUp>().pickUpName);
            if (coll.gameObject.GetComponent<PickUp>().pickUpName.Equals("Speed"))
            {
                speedTimer = coll.gameObject.GetComponent<PickUp>().pickUpTime;
                GetComponent<PlayerMove>().speedMultiplier = coll.gameObject.GetComponent<PickUp>().pickUpValue;
            }
            else if (coll.gameObject.GetComponent<PickUp>().pickUpName.Equals("Damage"))
            {
                damageTimer = coll.gameObject.GetComponent<PickUp>().pickUpTime;
                damageMultiplier = coll.gameObject.GetComponent<PickUp>().pickUpValue;
            }

        }
    }

    public void pickUpSticks(string name)
    {
        pickUps.Add(name);

        for (int k=0;k<pickUps.Count-1;k++)
        {
            if (pickUps[k].Equals(pickUps[k+1]))
            {
                pickUps.Remove(name);
            }

                
        }
    }
    public void removePickup(string name)
    {
        for (int k=0;k<pickUps.Count;k++)
        {
            if (pickUps[k].Equals(name))
            {
                pickUps.Remove(name);
                if (name.Equals("Speed"))
                GetComponent<PlayerMove>().speedMultiplier = 0;
                if (name.Equals("Damage"))
                    damageMultiplier = 0;
            }
        }
    }


    void Start()
    {
    }

    void Update()
    {
        if (speedTimer > 0)
            speedTimer--;
        if (damageTimer > 0)
            damageTimer--;

        //remove pickup
        if (speedTimer.Equals(0))
            removePickup("Speed");
        if (damageTimer.Equals(0))
            removePickup("Damage");
        //GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        //kills += 1; this was a test and only a test
        //send value from local network manager to player then update host/server
        if (isLocalPlayer)
            playerName = GameObject.FindGameObjectWithTag("netManager").GetComponent<netConnect>().playerName;
        //else playerName = players[1].GetComponent<Player>().netman.GetComponent<netConnect>().playerName;
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
        teamID = "Blue";
        killStreak = killStreak;
        numOfPickups = numOfPickups;
        pickUps = pickUps;
//        playerName = GetComponent<NetworkManager>().GetComponent<netConnect>().playerName;
    }



    }
