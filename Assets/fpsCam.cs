using UnityEngine;
using System.Collections;

public class fpsCam : MonoBehaviour {

    public GameObject player;
	void Start () {
        
        
    }
	
	// Update is called once per frame
	void Update () {
        player = GameObject.FindGameObjectWithTag("Player");
        transform.position = player.transform.position;
        transform.rotation = player.transform.rotation;
    }
}
