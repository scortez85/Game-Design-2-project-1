using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class testNetTrafic : NetworkBehaviour
{

    /*
    [ClientRpc]
    void PrintText(string text)
    {
        Debug.Log(text);
    }
    @RPC
    */
    [SyncVar]
    public int health;


    [ClientRpc]
    void RpcDamage(int amount)
    {
        Debug.Log("Took damage:" + amount);
    }

    public void TakeDamage(int amount)
    {
        //if (!isServer)
          //  return;

        health -= amount;
        RpcDamage(amount);

    }
    void Update()
    {
        //Debug.Log(health);
    }
    void OnGUI()
    {
        if (isLocalPlayer)
            return;

        //GUI.Label(new Rect(0, 0, 128, 32), health.ToString());
    }
}