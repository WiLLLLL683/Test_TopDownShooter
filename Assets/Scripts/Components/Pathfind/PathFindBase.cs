using UnityEngine;

namespace TopDownShooter
{
    public abstract class PathFindBase: MonoBehaviour
    {
        public abstract void SetTarget(Transform target);
        public abstract bool TryFindPath(out Vector3 nextCornerPosition);
    }
}