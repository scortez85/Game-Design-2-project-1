using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class spawnPlayer : MonoBehaviour {

    // Use this for initialization
    public GameObject player1, player2;
	void Awake () {
        //test
        GameObject player = (GameObject)Instantiate(player1, new Vector3(0, 0, 0),new Quaternion(0,0,0,0));
        //GetComponent<NetworkManager>().playerPrefab = player1;
        //GetComponent<NetworkManager>().playerPrefab = player2;
        //GetComponent<NetworkManager>().OnServerAddPlayer(ClientScene.,0);
        //NetworkServer.Spawn(GetComponent<NetworkManager>().spawnPrefabs[2]);
        //end test\
        NetworkServer.Spawn(player);


    }
  


    // Update is called once per frame
    void Update () {
        NetworkServer.Spawn(player1);
    }
}
