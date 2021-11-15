using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace HelperClasses.New_Input_System
{
    [RequireComponent(typeof(PlayerController))]

    public class PlayerInput : MonoBehaviour
    {
        public enum PlayerSelection { None, Player1, Player2}; //Will be used to keep track of what's selected

        public PlayerSelection playerNumber;
        private InputMaster _controls;
        //private InputAction _shootInput;
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
                    _controls.Player1.Shoot.performed += ctx => _playerController.Shoot();
                    _controls.Player1.Jump.canceled += ctx => _playerController.JumpChargeCanceled();
					_controls.Player1.Dash.performed += ctx => _playerController.Dash();

                    //_controls.Player1.Shoot.started += ctx => _playerController.Shoot();
                    //_controls.Player1.Shoot.canceled += ctx => _playerController.DoneShooting();


                    break;
                case PlayerSelection.Player2:
                    _controls.Player2.Jump.performed += ctx => _playerController.Jump();
                    _controls.Player2.Shoot.performed += ctx => _playerController.Shoot();
                    _controls.Player2.Jump.canceled += ctx => _playerController.JumpChargeCanceled();
					_controls.Player2.Dash.performed += ctx => _playerController.Dash();
          
                    //_controls.Player2.Shoot.started += ctx => _playerController.Shoot();
                    //_controls.Player2.Shoot.canceled += ctx => _playerController.DoneShooting();

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
