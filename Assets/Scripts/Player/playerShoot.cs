using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class playerShoot : NetworkBehaviour
{

    public Transform weaponPos;
    public AudioSource sfxSource;
    public AudioClip shootSfx;
    private Animator ani;
    private hashId hashID;

    [SyncVar]
    RaycastHit hit;
    [SyncVar]
    public string objHit;


    void Start()
    {
        sfxSource = GetComponent<AudioSource>();
        ani = GetComponent<Animator>();
        hashID = GetComponent<hashId>();
    }

    // Update is called once per frame
    void Update()
    {
        ani.SetBool(hashID.isShooting, false);

        //float horiz = Input.GetAxis("Horizontal");
        //float vert = Input.GetAxis("Vertical");



        Vector3 playerDir = transform.TransformDirection(Vector3.forward);
        Physics.Raycast(weaponPos.position, playerDir, out hit);
        Debug.DrawLine(weaponPos.position, hit.point, Color.cyan);

        //if (Input.GetButton("Attack"))
            //Debug.Log(Input.GetButton("Attack"));
            //Vector3
            playerDir = transform.TransformDirection(Vector3.forward);
        if (Input.GetButtonDown("Fire1"))
            if (Physics.Raycast(weaponPos.position, playerDir, out hit))
            {
                ani.SetBool(hashID.isShooting, true);

                CmdShoot();
                objHit = hit.collider.name.ToString();
            }
            else ani.SetBool(hashID.isShooting, false);





    }
    [Command]
    void CmdShoot()
    {
        sfxSource.clip = shootSfx;
        sfxSource.Play();
        if (hit.collider.gameObject.tag.Equals("Enemy"))
            hit.collider.gameObject.GetComponent<Enemy>().setHitDamage(10);
    }

}
