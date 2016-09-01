using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player {

    private int kills, deaths, ammo;
    private float health, speed;
    private int teamID, killStreak, modelID;
    private List<PickUp> pickUps;

    public Player()
    {
        kills = 0;
        deaths = 0;
        ammo = 0;
        killStreak = 0;
        health = 100;
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

    public void OnCollisionEnter(Collider coll)
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

}
