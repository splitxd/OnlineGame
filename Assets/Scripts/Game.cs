using UnityEditor;
using UnityEngine;

namespace DefaultNamespace
{
    public class Game : MonoBehaviour
    {
        private static Game _instance;

        public static Game Instance { get { return _instance; } }
        
        private void Awake()
        {
            if (_instance != null && _instance != this)
            {
                Destroy(this.gameObject);
            } else {
                _instance = this;
            }
        }
        
        public ManualPlayerSpawner manualPlayerSpawner;
    }
}