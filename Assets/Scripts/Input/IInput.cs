using System;
using System.Linq;
using UnityEngine;

namespace TopDownShooter
{
    public interface IInput
    {
        event Action<Vector2> OnInputMove;
        event Action<Vector2> OnPointerScreenPos;
        event Action<Vector3> OnPointerWorldPos;
        event Action OnInputShoot;

        void Enable();
        void Disable();
    }
}
