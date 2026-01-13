using DefaultNamespace.Network;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace DefaultNamespace
{
    [DefaultExecutionOrder(-100)]
    public class Game : MonoBehaviour
    {
        private static Game _instance;

        public static Game Instance => _instance;

        public ManualPlayerSpawner manualPlayerSpawner;
        public MenuViewController menuViewController;
        public MainMenuController mainMenuController;
        public BootstrapManager bootstrapManager;
        public BootstrapNetworkManager bootstrapNetworkManager;
        public MainMenuView mainMenuView;
        public LobbyNetwork lobbyNetwork;
        public ReadyMenuSpawner readyMenuSpawner;
        public TMP_Text debugText;
        
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            } else {
                _instance = this;
            }
            
            Init();
        }

        private void Init()
        {
            mainMenuController = new MainMenuController();
        }
    }
}