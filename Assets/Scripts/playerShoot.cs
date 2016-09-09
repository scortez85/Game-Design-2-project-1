using UnityEngine;
using System.Collections;

public class playerShoot : MonoBehaviour {
    private Vector3 playerAim;
    public RaycastHit hit;
	void Start () {
        //playerAim = transform.forward;
        Vector3 playerDir = transform.TransformDirection(Vector3.forward);
        Physics.Raycast(transform.position, playerDir, out hit);
        Debug.DrawLine(transform.position, hit.point, Color.cyan);
    }
	
	// Update is called once per frame
	void Update () {
        //if (RaycastHit)
        {
            
        }
	}
}
