using System;
using UnityEngine;

namespace TopDownShooter
{
    public abstract class MovementBase: MonoBehaviour
    {
        public abstract float MoveSpeed { get; }

        public abstract event Action OnMove;

        public abstract void SetSpeed(float moveSpeed);
        public abstract void Move(Vector3 direction);
    }
}