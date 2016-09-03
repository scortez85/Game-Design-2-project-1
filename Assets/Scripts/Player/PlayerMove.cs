using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerMove : NetworkBehaviour {

    public GameObject bulletPrefab;
    public Transform bulletSpawn;
    
	void Start () {
        gameObject.name = "Obi 1";
	
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLocalPlayer)
            return;
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            CmdFire();
        }

        float x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        float z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);
	}
    [Command]
    void CmdFire()
    
    {
        GameObject bullet = (GameObject)Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        bullet.GetComponent<Rigidbody>().velocity = transform.forward * 6.0f;

        NetworkServer.Spawn(bullet);
        //NetworkServer.SendToAll(numOfBullets);
        
        Destroy(bullet, 2);
        bullets++;
    }
    [SyncVar]
    public int bullets;
    
    public override void OnStartLocalPlayer()
    {
        base.OnStartLocalPlayer();
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
    
}
