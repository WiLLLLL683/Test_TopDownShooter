using System;
using UnityEngine;

namespace TopDownShooter
{
    public abstract class MovementBase: MonoBehaviour
    {
        public abstract event Action OnMove;

        public abstract void Init(float moveSpeed);
        public abstract void Move(Vector3 direction);
    }
}