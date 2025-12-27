using System.Collections;
using System.Collections.Generic;
using Mirror;
using Mirror.Examples.Pong;
using Steamworks;
using TMPro;
using UnityEngine;

public class SteamLobby : MonoBehaviour
{
    protected Callback<LobbyCreated_t> lobbyCreated;
    protected Callback<GameLobbyJoinRequested_t> gameLobbyJoinRequested;
    protected Callback<LobbyEnter_t> lobbyEntered;
    
    public ulong CurrentLobbyId;
    private const string HostAddress = "HostAddress";
    private NetworkManagerPong networkManagerPong;
    
    public GameObject hostbutton;
    public TMP_Text LobbyNameText;
    public TMP_Text DebugText;

    public void Start()
    {
        if (!SteamManager.Initialized) return;
        
        networkManagerPong = GetComponent<NetworkManagerPong>();
        
        lobbyCreated = Callback<LobbyCreated_t>.Create(OnLobbyCreated);
        gameLobbyJoinRequested = Callback<GameLobbyJoinRequested_t>.Create(OnJoinRequested);
        lobbyEntered = Callback<LobbyEnter_t>.Create(OnLobbyEntered);
    }

    public void HostLobby()
    {
        DebugText.text = "trying to host";
        DebugText.text += SteamManager.Initialized.ToString();
        SteamMatchmaking.CreateLobby(ELobbyType.k_ELobbyTypeFriendsOnly, networkManagerPong.maxConnections);
    }

    private void OnLobbyCreated(LobbyCreated_t callback)
    {
        if (callback.m_eResult != EResult.k_EResultOK) { return;}

        Debug.Log("LobbyCreated");
        networkManagerPong.StartHost();
        
        SteamMatchmaking.SetLobbyData(new CSteamID(callback.m_ulSteamIDLobby), HostAddress, SteamUser.GetSteamID().ToString());
        SteamMatchmaking.SetLobbyData(new CSteamID(callback.m_ulSteamIDLobby), "name" , SteamFriends.GetPersonaName() + "'s lobby");
    }

    private void OnJoinRequested(GameLobbyJoinRequested_t callback)
    {
        Debug.Log("request join lobby");
        SteamMatchmaking.JoinLobby(callback.m_steamIDLobby);
    }

    private void OnLobbyEntered(LobbyEnter_t callback)
    {
        hostbutton.SetActive(false);
        CurrentLobbyId = callback.m_ulSteamIDLobby;
        LobbyNameText.gameObject.SetActive(true);
        LobbyNameText.text = SteamMatchmaking.GetLobbyData(new CSteamID(callback.m_ulSteamIDLobby), "name");
        
        if (NetworkServer.active) {return;}
        networkManagerPong.networkAddress = SteamMatchmaking.GetLobbyData(new CSteamID(callback.m_ulSteamIDLobby), HostAddress);
        
        networkManagerPong.StartClient();
    }
}