using System;
using System.Collections;
using UnityEngine;

namespace TopDownShooter
{
    public class Pistol : WeaponBase
    {
        [SerializeField] private Transform gunPoint;
        [SerializeField] private int damage;
        [SerializeField] private int bulletSpeed;
        [SerializeField] private int shootDelay;

        public override event Action OnShoot;

        private BulletFactory bulletFactory;
        private float timer;

        public override void Init(BulletFactory bulletFactory)
        {
            this.bulletFactory = bulletFactory;
        }

        private void Update()
        {
            timer -= Time.deltaTime;
        }

        public override void Attack()
        {
            if (timer>= 0)
                return;

            bulletFactory.Create(gunPoint.position, gunPoint.forward, damage, bulletSpeed);
            timer = shootDelay;
        }
    }
}