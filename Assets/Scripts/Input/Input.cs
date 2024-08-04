using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TopDownShooter
{
    public class Input: IInput
    {
        public event Action<Vector2> OnInputMove;
        public event Action<Vector2> OnPointerScreenPos;
        public event Action<Vector3> OnPointerWorldPos;
        public event Action OnInputShoot;

        private GameControls controls;
        private Camera mainCamera;

        public void Enable()
        {
            controls = new();
            mainCamera = Camera.main;

            controls.Enable();
            controls.Gameplay.Pointer.performed += PointerInput;
            controls.Gameplay.Shoot.performed += ShootInput;
        }

        public void Disable()
        {
            controls.Disable();
            controls.Gameplay.Pointer.performed -= PointerInput;
            controls.Gameplay.Shoot.performed -= ShootInput;
        }

        public void Update()
        {
            if (controls.Gameplay.Move.IsPressed())
            {
                MoveInput();
            }
        }

        private void MoveInput()
        {
            Vector2 direction = controls.Gameplay.Move.ReadValue<Vector2>();
            OnInputMove?.Invoke(direction);
        }

        private void PointerInput(InputAction.CallbackContext context)
        {
            Vector2 screenPosition = context.ReadValue<Vector2>();
            OnPointerScreenPos?.Invoke(screenPosition);

            if(Physics.Raycast(mainCamera.ScreenToWorldPoint(screenPosition), mainCamera.transform.forward, out RaycastHit hitInfo))
            {
                Vector3 worldPosition = hitInfo.point;
                OnPointerWorldPos?.Invoke(worldPosition);
            }
        }

        private void ShootInput(InputAction.CallbackContext context) => OnInputShoot?.Invoke();
    }
}
