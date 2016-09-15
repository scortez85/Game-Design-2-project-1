using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Enemy : NetworkBehaviour {
    [SyncVar]
    public float health, speed, attackDmg, attackSpeed;
    public GameObject[] enemyCor;
    public NavMeshAgent agent;

    public Enemy()
    {
        speed = 3.0f;
        health = 150.0f;
        attackDmg = 25.0f;
        attackSpeed = 2.5f;
    }

    //sync some values to server 
    [Command]
    public void CmdsyncToServer(float damage)
    {
        health -= damage;
        speed = speed;
        attackDmg = attackDmg;
    }
    

    void Update()
    {
        agent.speed = speed;

        if (health <= 0)
            Destroy(gameObject);
        //CmdsyncToServer();
    }
    public void setHitDamage(float damage)
    {
        if (!isServer)
            return;

        health -= damage;

        RpcDamage(damage);
    }
    [ClientRpc]
    void RpcDamage(float damage)
    {
        if (isLocalPlayer)
        health -= damage;
    }
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyCor = GameObject.FindGameObjectsWithTag("enemyCor");
        agent.SetDestination(enemyCor[0].transform.position);
    }

    void OnTriggerEnter(Collider col)
    {
        //Debug.Log("hit" + col.name);
        if (col.tag.Equals("teleporter"))
        {
            Debug.Log("hit");

            transform.position = col.gameObject.GetComponent<telePort>().targetPos;
        }
    }

}
