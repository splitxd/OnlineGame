using System;
using FishNet.Managing.Scened;
using Steamworks;
using UnityEngine;

namespace DefaultNamespace.Network
{
    public class MainMenuController
    {
        public void CreateLobby()
        {
            if (!SteamAPI.Init())
            {
                Debug.LogError("Steamworks not initialized.");
                return;
            }
            BootstrapManager.CreateLobby();
        }
        
        public void JoinLobby(string lobbyInput)
        {
            CSteamID steamID = new CSteamID(Convert.ToUInt64(lobbyInput));
            BootstrapManager.JoinByID(steamID);
        }

        public void LeaveLobby()
        {
            BootstrapManager.LeaveLobby();
        }

        public void StartGame()
        {
            string[] scenesToClose = new string[] { "MainMenuScene" };
            BootstrapNetworkManager.ChangeNetworkScene("MainScene", scenesToClose);
            Game.Instance.manualPlayerSpawner.SpawnPlayers(SceneManager.GetScene("MainScene"));
        }
    }
}