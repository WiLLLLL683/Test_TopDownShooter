using System;
using UnityEngine;
using UnityEngine.VFX;

namespace TopDownShooter
{
    public class RocketBullet : BulletBase
    {
        [SerializeField] private MovementBase movement;
        [SerializeField] private ExplosionVFX explosionVFX;
        [SerializeField] private float explosionRadius = 2f;
        [SerializeField] private float targetThreshold = 0.1f;

        private Vector3 targetPos;
        private int damage;

        public override void Init(Vector3 startPos, Vector3 direction, Vector3 targetPos, int damage, float speed)
        {
            this.targetPos = targetPos;
            this.damage = damage;

            movement.SetSpeed(speed);
        }

        public void Update()
        {
            Move();
            CheckIsInTarget();
        }

        private void Move()
        {
            Vector3 direction = (targetPos - transform.position).normalized;
            movement.Move(direction);
        }

        private void CheckIsInTarget()
        {
            float distanceToTarget = (targetPos - transform.position).magnitude;

            if (distanceToTarget <= targetThreshold)
            {
                Explode();
            }
        }

        private void Explode()
        {
            Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i].gameObject.TryGetComponent(out IDamageable damageable))
                {
                    damageable.TakeDamage(damage);
                }
            }

            ExplosionVFX explosion = Instantiate(explosionVFX, transform.position, Quaternion.identity);
            explosion.Play(explosionRadius);
            Destroy(gameObject);
        }
    }
}