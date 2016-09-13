using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class playerShoot : NetworkBehaviour
{

    public Transform weaponPos;
    [SyncVar]
    RaycastHit hit;
    [SyncVar]
    public string objHit;


    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {

        //float horiz = Input.GetAxis("Horizontal");
        //float vert = Input.GetAxis("Vertical");



        Vector3 playerDir = transform.TransformDirection(Vector3.forward);
        Physics.Raycast(weaponPos.position, playerDir, out hit);
        Debug.DrawLine(weaponPos.position, hit.point, Color.cyan);

            //Vector3
            playerDir = transform.TransformDirection(Vector3.forward);
        if (Input.GetButtonDown("Jump"))
            if (Physics.Raycast(weaponPos.position, playerDir, out hit))
            {
                CmdShoot();
                objHit = hit.collider.name.ToString();
            }





    }
    [Command]
    void CmdShoot()
    {
        hit.collider.gameObject.GetComponent<Enemy>().setHitDamage(10);
    }

}
