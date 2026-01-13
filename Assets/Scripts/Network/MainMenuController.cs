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
            Game.Instance.bootstrapManager.LeaveLobby();
        }

        public void StartGame()
        {
            string[] scenesToClose = new string[] { "MainMenuScene" };
            Game.Instance.bootstrapNetworkManager.ChangeNetworkScene("MainScene", scenesToClose);
            Game.Instance.manualPlayerSpawner.SpawnPlayers(SceneManager.GetScene("MainScene"));
        }

        public void ToggleReady(bool ready)
        {
            Game.Instance.lobbyNetwork.SendReadyToServer(ready, SteamUser.GetSteamID());
        }

        public void LobbyEntered(string lobbyName, bool isHost)
        {
            Game.Instance.mainMenuView.LobbyEntered(lobbyName, isHost);
            Game.Instance.readyMenuSpawner.NeedToCreateReadyMenu();
        }
    }
}