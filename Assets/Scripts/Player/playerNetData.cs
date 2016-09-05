using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class playerNetData : NetworkBehaviour
{
    [SyncVar]
    public int kills;

    [Command]
    void CmdSendValues()
    {

    }
}