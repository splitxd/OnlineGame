    using System;
    using System.Collections.Generic;
    using DefaultNamespace;
    using FishNet.Managing;
    using FishNet.Managing.Client;
    using FishNet.Managing.Scened;
    using FishNet.Object;
    using Steamworks;
    using TMPro;
    using UnityEngine;
    using UnityEngine.UI;

    public class MainMenuView : MonoBehaviour
    {
        public Transform readyMenuContainer;
        [SerializeField] private GameObject menuScreen, lobbyScreen;
        [SerializeField] private TMP_InputField lobbyInput;
        
        [SerializeField] private TMP_Text debugText;

        [SerializeField] private TextMeshProUGUI lobbyTitle, lobbyIDText;
        [SerializeField] private Button startGameButton;
        private void Awake() => Game.Instance.mainMenuView = this;

        private void Start()
        {
            OpenMainMenu();
            Game.Instance.debugText = debugText;
        }

        public void CreateLobby()
        {
            Game.Instance.mainMenuController.CreateLobby();
        }

        public void OpenMainMenu()
        {
            CloseAllScreens();
            menuScreen.SetActive(true);
        }

        public void OpenLobby()
        {
            CloseAllScreens();
            lobbyScreen.SetActive(true);
        }

        public void LobbyEntered(string lobbyName, bool isHost)
        {
            lobbyTitle.text = lobbyName;
            startGameButton.gameObject.SetActive(isHost);
            lobbyIDText.text = BootstrapManager.CurrentLobbyID.ToString();
            OpenLobby();
        }

        void CloseAllScreens()
        {
            menuScreen.SetActive(false);
            lobbyScreen.SetActive(false);
        }

        public void JoinLobby()
        {
            Game.Instance.mainMenuController.JoinLobby(lobbyInput.text);
        }

        public void LeaveLobby()
        {
            Game.Instance.mainMenuController.LeaveLobby();
            OpenMainMenu();
        }

        public void StartGame()
        {
            Game.Instance.mainMenuController.StartGame();
        }
        
        
        public void SetStartButtonActive()
        {
            startGameButton.interactable = true;
        }
    }
