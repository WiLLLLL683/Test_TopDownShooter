using System;
using System.Collections;
using UnityEngine;

namespace TopDownShooter
{
    public class Bullet : MonoBehaviour
    {
        [SerializeField] private MovementBase movement;

        private Vector3 direction;
        private int damage;

        public void Init(Vector3 direction, int damage, float speed)
        {
            this.direction = direction;
            this.damage = damage;

            movement.Init(speed);
        }

        public void Update()
        {
            movement.Move(direction);
        }

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