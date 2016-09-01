using UnityEngine;
using System.Collections;

public class GameStructure : MonoBehaviour {
    //public GameObject overLord;
    private Player[] players;
    private Player winningPlayer;
    private int winningKills, winningPickUps;

	// Use this for initialization
	void Start () {
        players = new Player[4];
        winningKills = 25;
        winningPickUps = 50;
        winningPlayer = null;
	}
	
	// Update is called once per frame
	void Update () {
	
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
}
