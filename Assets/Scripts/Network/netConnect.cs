using UnityEngine.UI;
#if ENABLE_UNET

namespace UnityEngine.Networking
{
    [AddComponentMenu("Network/NetworkManagerHUD")]
    [RequireComponent(typeof(NetworkManager))]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public class netConnect : MonoBehaviour
    {
        private NetworkManager manager;
        public GameObject clientNameText;
       // [SerializeField]
        //private bool showGUI = true;
        //[SerializeField]
        //private int offsetX;
        //[SerializeField]
        //private int offsetY;
        public string clientType;
        //public GameObject player1;
        //[SyncVar]
        public string playerName;

        // Runtime variable
        bool showServer = false;
        public void setClientName(string letter)
        {
            if (!letter.Equals("Del"))
                playerName += letter;
            else if (letter.Equals("Del"))
                playerName = "";

            clientNameText.GetComponent<Text>().text = playerName;
            /*
            else if (letter.Equals("Space"))
                playerName += " ";
                */
        }
        public void setClientType(string type)
        {
            clientType = type;
            //Application.LoadLevel(1);
            //manager.StartHost();
        }
        public void startMatch()
        {
            Application.LoadLevel(1);

            /*
            if (clientType.Equals("Host"))
            {
                //manager.StartHost();

            }
            else
            {
                Application.LoadLevel(1);
                //manager.StartClient();

            }
            */
        }
        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            
            manager = GetComponent<NetworkManager>();
            //manager.networkAddress = "192.168.0.5";//remember to set an ip address for us to connect
            
           // var ip = Network.player.ipAddress;
            //Debug.Log(ip);
            
        }


        void Update()
        {
            
            //assign names
            //GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            //if (players.Length>0 && Application.loadedLevel>0)
            //players[0].GetComponent<Player>().playerName = playerName;
            //for (int k=0;k<players.Length;k++)
            {
                //if (players[k].name.Equals("localPlayer"))
                    //players[k].GetComponent<Player>().name = playerName;
            }
            if (Application.loadedLevel.Equals(0))
                manager.networkAddress = GetComponent<optionsData>().netIp;
            
            if (Application.loadedLevel.Equals(1))
            {
                if (!manager.isNetworkActive && clientType.Equals("Host"))
                    manager.StartHost();
               
                else if (!manager.isNetworkActive && clientType.Equals("Client"))
                    manager.StartClient();
            }
            
        }
        void OnGUI()
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            for (int k = 0; k < players.Length; k++)
            {
                //GUI.Label(new Rect(10, 10 + (32 * k), 128, 32),players[k].name + " : " + players[k].GetComponent<Player>().playerName);
            }
            //GUI.Label(new Rect(10, 10, 128, 64), manager.networkAddress);
        }
         
    }
};
#endif //ENABLE_UNET