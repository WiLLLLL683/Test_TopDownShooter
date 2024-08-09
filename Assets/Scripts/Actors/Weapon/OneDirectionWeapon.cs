using System;
using System.Collections;
using UnityEngine;

namespace TopDownShooter
{
    public class OneDirectionWeapon : WeaponBase
    {
        [SerializeField] private Transform gunPoint;

        public override event Action OnAttack;

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

        public override void Attack(Vector3 targetPos)
        {
            if (timer>= 0)
                return;

            bulletFactory.Create(config.bulletPrefab,
                gunPoint.position,
                gunPoint.forward,
                targetPos,
                config.damage,
                config.bulletSpeed);

            timer = 1/config.shootRate;
            OnAttack?.Invoke();
        }
    }
}