using System;
using System.Collections;
using UnityEngine;

namespace TopDownShooter
{
    public class Pistol : WeaponBase
    {
        [SerializeField] private Transform gunPoint;

        public override event Action OnShoot;

        private WeaponConfig config;
        private BulletFactory bulletFactory;
        private float timer;

        public override void Init(WeaponConfig config, BulletFactory bulletFactory)
        {
            this.config = config;
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

            bulletFactory.Create(config.bulletPrefab, gunPoint, config.damage, config.bulletSpeed);
            timer = 1/config.shootRate;
        }
    }
}