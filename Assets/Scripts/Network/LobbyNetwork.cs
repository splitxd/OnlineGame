using System.Collections.Generic;
using System.Linq;
using FishNet.Object;
using FishNet.Object.Synchronizing;
using Steamworks;
using UnityEngine;

namespace DefaultNamespace.Network
{
    public class LobbyNetwork : NetworkBehaviour
    {
        void Awake() => Game.Instance.lobbyNetwork = this;
        readonly SyncList<ReadyPlayer> readyPlayers = new SyncList<ReadyPlayer>();

        [ServerRpc]
        public void SendReadyToServer(bool isReady, CSteamID steamId)
        {
            var player = readyPlayers.FirstOrDefault(p => p.SteamId == steamId);
            if (player != null)
            {
                player.IsReady = isReady;
            }
            else
            {
                Debug.Log("Player to set ready Not Found");
            }
        }
    }
}