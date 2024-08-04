using UnityEngine;

namespace TopDownShooter
{
    public abstract class AimBase: MonoBehaviour
    {
        public abstract void SetLookTarget(Vector3 targetPosition);
    }
}