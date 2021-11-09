using System;
using UnityEngine;

namespace HelperClasses.New_Input_System
{
    [RequireComponent(typeof(PlayerController))]

    public class PlayerInput : MonoBehaviour
    {
        public enum PlayerSelection { None, Player1, Player2}; //Will be used to keep track of what's selected

        public PlayerSelection playerNumber;
        private InputMaster _controls;
        private PlayerController _playerController;
    
        private void Awake()
        {
            _controls = new InputMaster();
        }

        private void OnEnable()
        {
            _controls.Enable();

            switch (playerNumber)
            {
                case PlayerSelection.Player1:
                    _controls.Player1.Jump.performed += ctx => _playerController.Jump();
                    break;
                case PlayerSelection.Player2:
                    _controls.Player2.Jump.performed += ctx => _playerController.Jump();
                    break;
            }
        }
        private void OnDisable()
        {
            _controls.Disable();
        }
        
        void Start()
        {
            _playerController = GetComponent<PlayerController>();
            if (playerNumber == PlayerSelection.None)
            {
                Debug.LogError("You Forgot to Assign Player Number to the Player Input @PlayerInput.cs");
            }
        }

        void Update()
        {
            switch (playerNumber)
            {
                case PlayerSelection.Player1:
                    _playerController.SetMovementInput(_controls.Player1.Movement.ReadValue<Vector2>());
                    break;
                case PlayerSelection.Player2:
                    _playerController.SetMovementInput(_controls.Player2.Movement.ReadValue<Vector2>());
                    break;
            }
        }
    }
}
