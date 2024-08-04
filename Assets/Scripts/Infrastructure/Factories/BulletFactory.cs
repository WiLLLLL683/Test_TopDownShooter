using System;
using UnityEngine;

namespace TopDownShooter
{
    public class BulletFactory
    {
        private Bullet prefab;

        public BulletFactory(Bullet prefab)
        {
            this.prefab = prefab;
        }

        public Bullet Create(Vector3 position, Vector3 direction, int damage, float speed)
        {
            Bullet bullet = UnityEngine.Object.Instantiate(prefab, position, Quaternion.LookRotation(direction, Vector3.up));
            bullet.Init(direction, damage, speed);
            return bullet;
        }
    }
}