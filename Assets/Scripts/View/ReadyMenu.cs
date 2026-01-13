using System;
using DefaultNamespace.Network;
using FishNet.Object;
using Steamworks;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ReadyMenu : NetworkBehaviour
    {
        [SerializeField] private TMP_Text playerNameText;
        [SerializeField] private Toggle readyMenuToggle;
        
        public override void OnStartClient()
        {
            ChangeReadyMenuName();
            Game.Instance.debugText.text += $"I own now ready menu? - {IsOwner}";
            Game.Instance.debugText.text += $"\nConnection of me - {ClientManager.Connection}";
            Game.Instance.debugText.text += $"\nConnection of owner - {gameObject.GetComponent<NetworkObject>().Owner}";
            Game.Instance.debugText.text += $"\nUser is Auntificated? - {ClientManager.Connection.IsAuthenticated}";
            readyMenuToggle.enabled = IsOwner;
            transform.SetParent(Game.Instance.mainMenuView.readyMenuContainer,false);
        }
        
        private void ChangeReadyMenuName()
        {
            playerNameText.text = SteamFriends.GetPersonaName();
        }

        public void OnToggleSwitched(bool isOn)
        {
            Debug.Log("readyMenuToggled");
            Game.Instance.mainMenuController.ToggleReady(isOn);
        }
    }
}