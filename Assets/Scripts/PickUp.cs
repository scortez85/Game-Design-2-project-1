using UnityEngine;
using System.Collections;

public class PickUp {
    //private GameObject pickUp;
    private string pickUpName;

    public PickUp(string name)
    {
        pickUpName = name;
    }
    public void addPickUp(GameObject game)
    {
        Object.Instantiate(game);
    }

    public void spawnPickUp()
    {

    }
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
