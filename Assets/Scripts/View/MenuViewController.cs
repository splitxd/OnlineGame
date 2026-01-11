using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace
{
    public class MenuViewController : MonoBehaviour
    {
        [SerializeField]
        private GameObject  menuLobbyContent;
        
        private void Start()
        {
            Game.Instance.menuViewController = this;
        }
        
    }
}