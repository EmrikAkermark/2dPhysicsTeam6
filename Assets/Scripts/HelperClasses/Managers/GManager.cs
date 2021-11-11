using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace HelperClasses.Managers
{
    public class GManager : MonoBehaviour
    {
        private static GameObject _player1;
        private static GameObject _player2;
        private static List<MonkeyBar> _monkeyBarsList;
        private static GameObject _environment;
        private static Camera _mainCamera;

        public static GManager Instance { get; private set; }
 
        // Use this for initialization
        void Awake () {
            if (Instance == null) {
                Instance = this;
            } else {
                Destroy (gameObject);  
            }
            DontDestroyOnLoad (gameObject);
            InitializeVariables();
        }

        private void InitializeVariables()
        {
            _monkeyBarsList = new List<MonkeyBar>();
            _player1 = GameObject.Find("Player 1");
            _player2 = GameObject.Find("Player 2");
            _environment = GameObject.FindWithTag("Environment");
            
            GameObject[] allMonkeyBars = GameObject.FindGameObjectsWithTag("MonkeyBar");
            foreach (var monkeyBar in allMonkeyBars)
            {
                _monkeyBarsList.Add(monkeyBar.GetComponent<MonkeyBar>()); 
            }
            
            GameObject cameraObject = GameObject.FindWithTag("MainCamera");
            _mainCamera = cameraObject.GetComponent<Camera>();
        }

        public static List<MonkeyBar> GetAllMonkeyBars()
        {
            return _monkeyBarsList;
        }
        
        public static GameObject GetEnvironment()
        {
            return _environment;
        }
        
        public static GameObject GetPlayer1()
        {
            return _player1;
        }
        
        public static GameObject GetPlayer2()
        {
            return _player2;
        }
        
        public static Camera GetCamera()
        {
            return _mainCamera;
        }
        

    }
 
}
