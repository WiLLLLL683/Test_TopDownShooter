using UnityEngine;

namespace TopDownShooter
{
    public abstract class BulletBase: MonoBehaviour
    {
        public abstract void Init(Vector3 startPos, Vector3 direction, Vector3 targetPos, int damage, float speed);
    }
}