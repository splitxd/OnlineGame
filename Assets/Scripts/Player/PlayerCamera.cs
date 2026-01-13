using DefaultNamespace.Player;
using FishNet.Object;
using UnityEngine;
using FishNet.Managing.Scened;

public class PlayerCamera : NetworkBehaviour
{
    [SerializeField] private Camera _cameraPrefab;
    [SerializeField] private Transform _cameraHolder;
    [SerializeField] private InputManager inputManager;

    public override void OnStartClient()
    {
        if (IsOwner)
        {
            var cam = Instantiate(_cameraPrefab, _cameraHolder.position, _cameraHolder.rotation, _cameraHolder);
            inputManager.AssignCamera(cam);
        }
            
    }
}