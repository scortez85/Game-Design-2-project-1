using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class spawnPlayer : NetworkManager {

    // Use this for initialization
    public GameObject player1, player2;
	void Awake () {
        //test
        //GameObject player = (GameObject)Instantiate(player1, new Vector3(0, 0, 0),new Quaternion(0,0,0,0));
        //GetComponent<NetworkManager>().playerPrefab = GameObject.FindGameObjectWithTag("Player");
        //GetComponent<NetworkManager>().OnServerAddPlayer(0,player);
        //NetworkServer.Spawn(GetComponent<NetworkManager>().spawnPrefabs[2]);
        //end test


    }
    public override void OnServerAddPlayer(NetworkConnection conn, short playerControllerId)
    {
        base.OnServerAddPlayer(conn, playerControllerId);
        GameObject player = (GameObject)Instantiate(player1, new Vector3(0, 0, 0), new Quaternion(0, 0, 0, 0));
        NetworkServer.AddPlayerForConnection(conn, player, playerControllerId);
    }


    // Update is called once per frame
    void Update () {
	
	}
}
