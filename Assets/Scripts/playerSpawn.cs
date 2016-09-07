using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class playerSpawn : ClientScene {

	// Use this for initialization
	void Start () {
        ClientScene.AddPlayer(0);
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
