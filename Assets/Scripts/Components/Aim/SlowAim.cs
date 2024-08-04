using System;
using System.Collections;
using UnityEngine;

namespace TopDownShooter
{
    public class SlowAim : AimBase
    {
        [Tooltip("degrees per second")]
        [SerializeField] private float rotationSpeed = 180f;
        [SerializeField] private bool freezeX;
        [SerializeField] private bool freezeY;
        [SerializeField] private bool freezeZ;

        private Vector3 lookTargetPos;
        private bool haveLookTarget;

        public override void SetLookTarget(Vector3 targetPosition)
        {
            haveLookTarget = true;

            if (freezeX)
            {
                targetPosition.x = transform.position.x;
            }

            if (freezeY)
            {
                targetPosition.y = transform.position.y;
            }

            if (freezeZ)
            {
                targetPosition.z = transform.position.z;
            }

            lookTargetPos = targetPosition;
        }

        private void Update()
        {
            LookAtTarget();
        }

        private void LookAtTarget()
        {
            if (!haveLookTarget)
                return;

            Quaternion rotation = Quaternion.LookRotation(lookTargetPos - transform.position);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotation, Time.deltaTime * rotationSpeed);
        }
    }
}