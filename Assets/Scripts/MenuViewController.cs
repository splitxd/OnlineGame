using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class MenuViewController : MonoBehaviour
    {
        [SerializeField]
        private GameObject  mainMenuPanel;
        [SerializeField] 
        private TMP_Text serverInfoText;
        [SerializeField]
        private Button  hostButton;
        
        private void Start()
        {
            Game.Instance.menuViewController = this;
        }

        public void OnJoinServer(string serverInfo)
        {
            mainMenuPanel.SetActive(false);
            hostButton.gameObject.SetActive(false);
            serverInfoText.gameObject.SetActive(true);
            serverInfoText.text = serverInfo;
        }
    }
}