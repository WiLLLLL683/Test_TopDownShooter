using System;
using UnityEngine;

namespace TopDownShooter
{
    public class MultiDirectionWeapon : WeaponBase
    {
        [SerializeField] private Transform gunPoint;
        [SerializeField][Min(2)] private int directionsCount;
        [SerializeField][Min(1f)] private float radius;

        public override event Action OnAttack;

        private WeaponBonus config;
        private BulletFactory bulletFactory;
        private Vector3[] directions;
        private float timer;

        public override void Init(WeaponBonus config, BulletFactory bulletFactory)
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
            if (timer >= 0)
                return;

            CalculateDirections();

            for (int i = 0; i < directions.Length; i++)
            {
                bulletFactory.Create(config.bulletPrefab,
                    gunPoint.position,
                    directions[i],
                    targetPos,
                    config.damage,
                    config.bulletSpeed);
            }

            timer = 1 / config.shootRate;
            OnAttack?.Invoke();
        }

        private void CalculateDirections()
        {
            directions = new Vector3[directionsCount];
            int stepsCount = Mathf.Max(1, directionsCount - 1);
            float step = radius / stepsCount;
            float angleY = -radius / 2;

            for (int i = 0; i < directions.Length; i++)
            {
                directions[i] = Quaternion.Euler(0, angleY, 0) * gunPoint.forward;
                angleY += step;
            }
        }
    }
}