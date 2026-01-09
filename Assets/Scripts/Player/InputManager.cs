using FishNet.Object;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace DefaultNamespace.Player
{
    public class InputManager : NetworkBehaviour
    {
        private PlayerInput playerInput;
        private PlayerInput.OnFootActions footActions;
        private bool enableActions = false;

        private PlayerMovement playerMovement;
        
        private PlayerLook playerLook;

        public override void OnStartClient()
        {
            if (IsOwner)
                GetComponent<InputManager>().enabled = true;
        }
        
        void Awake()
        {
            playerInput = new PlayerInput();
            footActions = playerInput.OnFoot;
            
            playerMovement = GetComponent<PlayerMovement>();
            playerLook = GetComponent<PlayerLook>();
            
            footActions.Jump.performed += jump => playerMovement.Jump();
            //footActions.MenuOpen.performed += menu => SwitchMovementEnabled();

            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
        }

        public void AssignCamera(Camera cam)
        {
            playerLook.cam = cam;
        }

        private void SwitchMovementEnabled()
        {
            switch (enableActions)
            {
                case true:
                    Cursor.lockState = CursorLockMode.Locked;
                    Cursor.visible = false;
                    break;
                case false:
                    Cursor.lockState = CursorLockMode.Confined;
                    Cursor.visible = true;
                    break;
            }
        }

        void FixedUpdate()
        {
            if (!IsOwner)
                return;
            playerMovement.ProcessMove(footActions.Movement.ReadValue<Vector2>());
        }

        void LateUpdate()
        {
            if (!IsOwner)
                return;
            playerLook.ProcessLook(footActions.Look.ReadValue<Vector2>());
        }

        private void OnEnable()
        {
            footActions.Enable();
        }

        private void OnDisable()
        {
            footActions.Disable();
        }
    }
}