using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class enemySpawn : NetworkBehaviour
{

    public GameObject enemy;
    [SyncVar]
    private int numToSpawn, spawnRate, numOfEnemies, totalEnemies, spawnTime;

    public void setSpawnRate(int num)
    {
        if (isServer)
            return;
        spawnRate = num;
        RpcSetRate(num);
    }

    void Start()
    {
        numToSpawn = 3;
        spawnRate = 50;
    }



    [ClientRpc]
    void RpcSetRate(int num)
    {
        if (isLocalPlayer)
            spawnRate = num;
    }



    // Update is called once per frame
    void Update()
    {

       

        if (numOfEnemies < numToSpawn * 1.5)
        {
            GameObject enemySpawn = (GameObject)Instantiate(enemy, transform.position, Quaternion.identity);
            enemySpawn.GetComponent<Rigidbody>().velocity = Vector3.forward;
            NetworkServer.Spawn(enemySpawn);
            totalEnemies += numOfEnemies;

        }
        numOfEnemies = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (isLocalPlayer)
            setSpawnRate(20);

    }
    void OnGUI()
    {
        // GUI.Label(new Rect(10, 10, 128, 32), "Spawn rate :" + spawnRate.ToString());
        //GUI.Label(new Rect(10, 32, 128, 32), "Num to spawn :" + numToSpawn.ToString());
    }
   
}
