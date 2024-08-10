using System;
using System.Collections;
using UnityEngine;

namespace TopDownShooter
{
    public class LinearMovement : MovementBase
    {
        [Tooltip("units per second")]
        [SerializeField] private float moveSpeed;

        public override float MoveSpeed => moveSpeed;

        public override event Action OnMove;

        public override void SetSpeed(float moveSpeed)
        {
            this.moveSpeed = moveSpeed;
        }

        public override void Move(Vector3 direction)
        {
            transform.position += moveSpeed * Time.deltaTime * direction.normalized;
        }
    }
}