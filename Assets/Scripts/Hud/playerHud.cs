using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerHud : MonoBehaviour {
    public GameObject teamIcon, weaponIcon;
    public GameObject teamText, weaponText, ammoText, deathText, killsText;

    public Texture[] teamIcons;

    public GameObject player;


    void Start () {
        
	
	}
	
	// Update is called once per frame
	void Update () {
        player = GameObject.FindGameObjectWithTag("Player");
        if (!player.Equals(null))
        {
            killsText.GetComponent<Text>().text = player.GetComponent<Player>().kills.ToString();
            ammoText.GetComponent<Text>().text = player.GetComponent<Player>().ammo.ToString();
            deathText.GetComponent<Text>().text = player.GetComponent<Player>().deaths.ToString();

        }

    }
}
