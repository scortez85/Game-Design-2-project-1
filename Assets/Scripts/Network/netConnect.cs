#if ENABLE_UNET

namespace UnityEngine.Networking
{
    [AddComponentMenu("Network/NetworkManagerHUD")]
    [RequireComponent(typeof(NetworkManager))]
    [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
    public class netConnect : MonoBehaviour
    {
        private NetworkManager manager;
        [SerializeField]
        private bool showGUI = true;
        [SerializeField]
        private int offsetX;
        [SerializeField]
        private int offsetY;
        public string clientType;

        // Runtime variable
        bool showServer = false;

        public void setClientType(string type)
        {
            clientType = type;
            Application.LoadLevel(1);
            //manager.StartHost();
        }
        void Awake()
        {
            DontDestroyOnLoad(gameObject);
            
            manager = GetComponent<NetworkManager>();
            manager.networkAddress = "192.168.0.5";//remember to set an ip address for us to connect
           // var ip = Network.player.ipAddress;
            //Debug.Log(ip);
            
        }

        public void HostLocalServer()
        {
            manager.StartHost();
        }
        public void ConnectLocalServer()
        {
            manager.StartClient();
        }

        void Update()
        {
            if (Application.loadedLevel.Equals(1))
            {
                if (!manager.isNetworkActive && clientType.Equals("Host"))
                    manager.StartHost();
                else if (!manager.isNetworkActive && clientType.Equals("Client"))
                    manager.StartClient();
            }
        }
        void OnGUI()
        {}
         
    }
};
#endif //ENABLE_UNET