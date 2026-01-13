using System.Collections;
using FishNet.Connection;
using FishNet.Object;
using UnityEngine;
using FishNet.Managing.Scened;

namespace DefaultNamespace
{
    public class ReadyMenuSpawner : NetworkBehaviour
    {
        [SerializeField] private NetworkObject readyMenuPrefab;
        private bool needCreateMenu = false;
        NetworkObject networkObject;
        
        void Awake() => Game.Instance.readyMenuSpawner = this;

        public override void OnStartClient()
        {
            base.OnStartClient();
            SpawnReadyMenuServerRpc();
        }

        public void NeedToCreateReadyMenu()
        {
            needCreateMenu = true;
        }

        [ObserversRpc]
        private void SpawnReadyMenuServerRpc()
        {
            if (!needCreateMenu)
                return;
            
            var conn = ClientManager.Connection;
            if (!conn.IsAuthenticated)
            {
                Debug.Log("Not authenticated user tried to spawn ready menu");
                return;
            }
            
            networkObject = NetworkManager.GetPooledInstantiated(readyMenuPrefab, true);
            Spawn(networkObject, conn, SceneManager.GetScene("MainMenuScene"));
            
            networkObject.GetComponent<NetworkObject>().GiveOwnership(conn,true);
            
            SpawnReadyMenuObserverRpc();
        }

        [ObserversRpc]
        private void SpawnReadyMenuObserverRpc()
        {
            Game.Instance.mainMenuView.SetStartButtonActive();
            needCreateMenu = false;
        }
    }
}