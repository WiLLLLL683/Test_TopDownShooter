using System;
using UnityEngine;

namespace TopDownShooter
{
    public class BulletFactory
    {
        public BulletBase Create(BulletBase prefab, Vector3 startPos, Vector3 direction, Vector3 targetPos, int damage, float speed)
        {
            BulletBase bullet = UnityEngine.Object.Instantiate(prefab, startPos, Quaternion.LookRotation(direction, Vector3.up));
            bullet.Init(startPos, direction, targetPos, damage, speed);
            return bullet;
        }
    }
}