using UnityEngine;
using System.Collections;

public class GameStructure : MonoBehaviour {
    //public GameObject overLord;
    private Player[] players;
    private Player winningPlayer;
    private int winningKills, winningPickUps;

    //steve added stuff
    public GameObject[] playerList;

	// Use this for initialization
	void Start () {
        players = new Player[4];
        winningKills = 25;
        winningPickUps = 50;
        winningPlayer = null;
	}
	
	// Update is called once per frame
	void Update () {
        playerList = GameObject.FindGameObjectsWithTag("Player");
	
	}

    public Player playerWins()
    {
        for(int i = 0; i < players.Length; i++)
        {
            if(players[i].getPlayerKills() == winningKills || players[i].getNumPickUps() == winningPickUps)
            {
                winningPlayer = players[i];
            }
            else
            {
                winningPlayer = null;
            }
        }
        return winningPlayer;
    }

    void OnGUI()
    {
        for (int k=0;k<playerList.Length;k++)
        {
            GUI.Label(new Rect(10, 10 + (k * 32), 256, 32), "Player: " + playerList[k].name + " kills: " + playerList[k].GetComponent<Player>().kills.ToString());
        }
    }
}
