using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class fpsCam : MonoBehaviour {

    public GameObject player,camera;
    private int camState = 0;
    private Vector3 thirdPer = new Vector3(0, 0.8f, -0.97f);
    private Vector3 firstPer = new Vector3(0, 0.75f, -0.095f);
    private Quaternion thirdRot = new Quaternion(1,1,1,1);
    private float myZ,myrotX;

    void Start () {
        myZ = thirdPer.z;
        transform.position = player.transform.position;
        transform.rotation = player.transform.rotation;
        
    }
	
	// Update is called once per frame
	void Update () {
        transform.position = player.transform.position;
        transform.rotation = player.transform.rotation;

        if (camState.Equals(0))
        {
            if (camera.transform.position.z < firstPer.z)
            {
                myZ = 1f;

            }
            else myZ = 0;
            if (camera.transform.rotation.x > 0)
                myrotX = -1;
            else myrotX = 0;

            

                
            //camera.transform.position = firstPer;
            //camera.transform.rotation = new Quaternion(0, 0, 0, 0);
            //camState = -1;
        }
        //camera.transform.Translate(0, 0, myZ * Time.deltaTime);
        //camera.transform.Rotate(myrotX * Time.deltaTime, 0, 0);


    }
}
