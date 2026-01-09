using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using FishNet.Connection;
using FishNet.Object;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManualPlayerSpawner : NetworkBehaviour
{
    [SerializeField] private NetworkObject playerPrefab;

    private void Start()
    {
        Game.Instance.manualPlayerSpawner =  this;
    }

    [Server]
    public void SpawnPlayers(Scene scene)
    {
        Debug.Log("AT LEAST WE TRIED");
        if (playerPrefab == null)
        {
            Debug.LogWarning("Player prefab is not assigned and thus cannot be spawned.");
            return;
        }

        foreach (NetworkConnection client in ServerManager.Clients.Values)
        {
            if (!client.IsAuthenticated)
                continue;

            NetworkObject obj = NetworkManager.GetPooledInstantiated(playerPrefab,true);
            Spawn(obj, client, scene);
        }
    }
}
