using UnityEngine;
using System.Collections;

public class Player {

    private int kills, deaths, ammo;
    private float health, speed;
    private int teamID, killStreak, modelID;
    private PickUp[] pickUps;

    public Player()
    {
        kills = 0;
        deaths = 0;
        ammo = 0;
        killStreak = 0;
        health = 100;
        speed = 2.5f;
        pickUps = new PickUp[99];
    }
}
