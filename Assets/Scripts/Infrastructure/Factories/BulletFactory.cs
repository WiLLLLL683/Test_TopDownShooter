using System;
using UnityEngine;

namespace TopDownShooter
{
    public class BulletFactory
    {
        public Bullet Create(Bullet prefab, Transform gunPoint, int damage, float speed)
        {
            Bullet bullet = UnityEngine.Object.Instantiate(prefab, gunPoint.position, Quaternion.LookRotation(gunPoint.forward, Vector3.up));
            bullet.Init(gunPoint.forward, damage, speed);
            return bullet;
        }
    }
}