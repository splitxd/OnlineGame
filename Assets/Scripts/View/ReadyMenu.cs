using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class ReadyMenu : MonoBehaviour
    {
        [SerializeField] private TMP_Text playerNameText;
        [SerializeField] private Toggle readyMenuToggle;
        
        public bool PlayerIsReady => readyMenuToggle.isOn;
        
        public void ChangeReadyMenuName(string newName)
        {
            playerNameText.text = newName;
        }
    }
}