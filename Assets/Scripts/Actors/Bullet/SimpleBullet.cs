using System;
using System.Collections;
using UnityEngine;

namespace TopDownShooter
{
    public class SimpleBullet : BulletBase
    {
        [SerializeField] private MovementBase movement;

        private Vector3 direction;
        private int damage;

        public override void Init(Vector3 startPos, Vector3 direction, Vector3 targetPos, int damage, float speed)
        {
            this.direction = direction.normalized;
            this.damage = damage;

            movement.Init(speed);
        }

        public void Update()
        {
            Move();
        }

        private void Move() => movement.Move(direction);

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(damage);
            }

            Destroy(gameObject);
        }
    }
}