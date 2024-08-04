using System;
using System.Collections;
using UnityEngine;

namespace TopDownShooter
{
    public class Bullet : MonoBehaviour
    {
        private Vector3 direction;
        private int damage;
        private float speed;

        public void Init(Vector3 direction, int damage, float speed)
        {
            this.direction = direction;
            this.damage = damage;
            this.speed = speed;
        }

        public void Update()
        {
            Move(direction);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(damage);
            }

            Destroy(gameObject);
        }

        private void Move(Vector3 direction)
        {
            transform.position += speed * Time.deltaTime * direction.normalized;
        }
    }
}