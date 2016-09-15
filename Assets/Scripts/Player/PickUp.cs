using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PickUp : MonoBehaviour{

        //[SyncVar]
        public string pickUpName;
        //[SyncVar]
        public float pickUpTime, pickUpValue;
    public GameObject objBase;
    public float rotSpeed,yawSpeed;

    void Start()
    {
        switch (pickUpName)
        {
            case "Speed":
                pickUpTime = 150;
                pickUpValue = 1.75f;
                break;
            case "Damage":
                pickUpTime = 200;
                pickUpValue = 2.0f;
                break;
            case "Ammo":
                pickUpTime = 100;
                pickUpValue = 5.0f;
                break;
            default:
                pickUpTime = 100;
                pickUpValue = 1.0f;
                break;
        }
    }
   
    void Update()
    {
        objBase.transform.Rotate(yawSpeed * Time.deltaTime, rotSpeed * Time.deltaTime,0);
    }
    /*
    //private GameObject pickUp;
    [SyncVar]
    public string pickUpName;
    [SyncVar]
    public float pickUpTime, pickUpValue;

    void Start()
    {
        //PickUp item = new PickUp(pickUpName);
    }
    void Update()
    {
        pickUpTime = 50;
    }
   
    
    public PickUp(string name)
    {
        pickUpName = name;
        switch (name)
        {
            case "Speed":
                pickUpTime = 150;
                pickUpValue = 1.75f;
                break;
            case "Damage":
                pickUpTime = 200;
                pickUpValue = 2.0f;
                break;
            case "Ammo":
                pickUpTime = 100;
                pickUpValue = 5.0f;
                break;
            default:
                pickUpTime = 100;
                pickUpValue = 1.0f;
                break;
        }
    }
    public void addPickUp(GameObject game)
    {
        Object.Instantiate(game);
    }

    public void spawnPickUp()
    {

    }
	// Use this for initialization
	
	
	// Update is called once per frame
	void Update () {
	
	}
    */
}
