using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerHud : MonoBehaviour {
    public GameObject teamIcon, weaponIcon;
    public GameObject teamText, weaponText, ammoText, deathText, killsText;

    public Texture[] teamIcons;

    public GameObject player;


    void Start () {
        player.GetComponent<Player>().setPlayerTeam("Blue");
        
	
	}
	
	// Update is called once per frame
	void Update () {
        //player = GameObject.FindGameObjectWithTag("Player");
        killsText.GetComponent<Text>().text = player.GetComponent<Player>().getPlayerKills().ToString();
        ammoText.GetComponent<Text>().text = player.GetComponent<Player>().getNumAmmo().ToString();
        deathText.GetComponent<Text>().text = player.GetComponent<Player>().getPlayerDeaths().ToString();
        teamText.GetComponent<Text>().text = player.GetComponent<Player>().getPlayerTeam();

    }
}
