using System.Linq;
using DefaultNamespace;
using FishNet.Connection;
using FishNet.Managing.Scened;
using FishNet.Object;
using UnityEngine;

public class BootstrapNetworkManager : NetworkBehaviour
{
    private void Awake() => Game.Instance.bootstrapNetworkManager = this;

    public void ChangeNetworkScene(string sceneName, string[] scenesToClose)
    {
        CloseScenes(scenesToClose);

        SceneLoadData sld = new SceneLoadData(sceneName);
        NetworkConnection[] conns = ServerManager.Clients.Values.ToArray();
        SceneManager.LoadConnectionScenes(conns, sld);
    }

    [ServerRpc(RequireOwnership = false)]
    void CloseScenes(string[] scenesToClose)
    {
        CloseScenesObserver(scenesToClose);
    }

    [ObserversRpc]
    void CloseScenesObserver(string[] scenesToClose)
    {
        foreach (var sceneName in scenesToClose)
        {
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName);
        }
    }
    
}