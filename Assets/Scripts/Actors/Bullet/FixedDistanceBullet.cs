using System;
using UnityEngine;

namespace TopDownShooter
{
    public class FixedDistanceBullet : BulletBase
    {
        [SerializeField] private MovementBase movement;
        [SerializeField] private float maxDistance = 7f;

        private Vector3 direction;
        private Vector3 startPos;
        private int damage;

        public override void Init(Vector3 startPos, Vector3 direction, Vector3 targetPos, int damage, float speed)
        {
            this.direction = direction.normalized;
            this.startPos = startPos;
            this.damage = damage;

            movement.Init(speed);
        }

        public void Update()
        {
            Move();
            CheckDistance();
        }

        private void Move() => movement.Move(direction);

        private void CheckDistance()
        {
            float distanceFromStart = (transform.position - startPos).magnitude;
            if (distanceFromStart >= maxDistance)
            {
                Destroy(gameObject);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}