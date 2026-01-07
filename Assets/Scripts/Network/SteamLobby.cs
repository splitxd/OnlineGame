// using System.Collections;
// using System.Collections.Generic;
// using DefaultNamespace;
// using Mirror;
// using Mirror.Examples.Pong;
// using Network;
// using Steamworks;
// using TMPro;
// using UnityEngine;
//
// public class SteamLobby : MonoBehaviour
// {
//     protected Callback<LobbyCreated_t> lobbyCreated;
//     protected Callback<GameLobbyJoinRequested_t> gameLobbyJoinRequested;
//     protected Callback<LobbyEnter_t> lobbyEntered;
//     
//     public ulong CurrentLobbyId;
//     private const string HostAddress = "HostAddress";
//     private NetworkManagerEnhanced networkManagerEnhanced;
//
//     public void Start()
//     {
//         if (!SteamManager.Initialized) return;
//         
//         networkManagerEnhanced = GetComponent<NetworkManagerEnhanced>();
//         
//         lobbyCreated = Callback<LobbyCreated_t>.Create(OnLobbyCreated);
//         gameLobbyJoinRequested = Callback<GameLobbyJoinRequested_t>.Create(OnJoinRequested);
//         lobbyEntered = Callback<LobbyEnter_t>.Create(OnLobbyEntered);
//     }
//
//     public void HostLobby()
//     {
//         SteamMatchmaking.CreateLobby(ELobbyType.k_ELobbyTypeFriendsOnly, networkManagerEnhanced.maxConnections);
//     }
//
//     private void OnLobbyCreated(LobbyCreated_t callback)
//     {
//         if (callback.m_eResult != EResult.k_EResultOK) { return;}
//
//         Debug.Log("LobbyCreated");
//         networkManagerEnhanced.StartHost();
//         
//         SteamMatchmaking.SetLobbyData(new CSteamID(callback.m_ulSteamIDLobby), HostAddress, SteamUser.GetSteamID().ToString());
//         SteamMatchmaking.SetLobbyData(new CSteamID(callback.m_ulSteamIDLobby), "name" , SteamFriends.GetPersonaName() + "'s lobby");
//     }
//
//     private void OnJoinRequested(GameLobbyJoinRequested_t callback)
//     {
//         Debug.Log("request join lobby");
//         SteamMatchmaking.JoinLobby(callback.m_steamIDLobby);
//     }
//
//     private void OnLobbyEntered(LobbyEnter_t callback)
//     {
//         CurrentLobbyId = callback.m_ulSteamIDLobby;
//         Game.Instance.menuViewController.OnJoinServer(SteamMatchmaking.GetLobbyData(new CSteamID(callback.m_ulSteamIDLobby), "name"));
//         
//         if (NetworkServer.active) {return;}
//         networkManagerEnhanced.networkAddress = SteamMatchmaking.GetLobbyData(new CSteamID(callback.m_ulSteamIDLobby), HostAddress);
//         
//         networkManagerEnhanced.StartClient();
//     }
// }