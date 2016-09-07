using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class spawnPlayer : MonoBehaviour {

    // Use this for initialization
    public GameObject player1, player2;
	void Awake () {
        //test
        GameObject player = (GameObject)Instantiate(player1, new Vector3(0, 0, 0),new Quaternion(0,0,0,0));
        GetComponent<NetworkManager>().playerPrefab = GameObject.FindGameObjectWithTag("Player");
        //GetComponent<NetworkManager>().OnServerAddPlayer(ClientScene.,0);
        NetworkServer.Spawn(GetComponent<NetworkManager>().spawnPrefabs[2]);
        //end test


    }
  


    // Update is called once per frame
    void Update () {
	
	}
}
