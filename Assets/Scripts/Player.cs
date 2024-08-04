using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class Player : MonoBehaviour
    {
        [Tooltip("units per second")]
        [SerializeField] private float moveSpeed = 4f;
        [Tooltip("degrees per second")]
        [SerializeField] private float rotationSpeed = 180f;

        private IInput input;
        private Vector3 lookTargetPos;
        private bool haveLookTarget;

        public void Init(IInput input)
        {
            this.input = input;

            input.OnInputMove += Move;
            input.OnInputShoot += Shoot;
            input.OnPointerWorldPos += SetLookTarget;
        }

        private void OnDestroy()
        {
            input.OnInputMove -= Move;
            input.OnInputShoot -= Shoot;
            input.OnPointerWorldPos -= SetLookTarget;
        }

        private void Update()
        {
            LookAtTarget();
        }

        private void Move(Vector2 direction)
        {
            transform.position += moveSpeed * Time.deltaTime * new Vector3(direction.x, 0, direction.y).normalized;
        }

        private void Shoot()
        {
            Debug.Log("Shoot"); //TODO
        }

        private void SetLookTarget(Vector3 targetPosition)
        {
            haveLookTarget = true;
            targetPosition.y = transform.position.y;
            lookTargetPos = targetPosition;
        }

        private void LookAtTarget()
        {
            if (!haveLookTarget)
                return;

            Quaternion rotation = Quaternion.LookRotation(lookTargetPos - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
    }
}