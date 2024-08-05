using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace TopDownShooter
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private HealthBase health;
        [SerializeField] private PathFindBase pathFind;
        [SerializeField] private MovementBase movement;
        [SerializeField] private AimBase aim;
        [SerializeField] private int damage;
        [SerializeField] private LayerMask attackLayer;

        private EnemyConfig config;
        private ScoreService scoreService;

        public void Init(EnemyConfig config, Transform target, ScoreService scoreService)
        {
            this.config = config;
            this.scoreService = scoreService;

            health.Init(config.health);
            pathFind.SetTarget(target);
            movement.Init(config.moveSpeed);
            //TODO aim.Init();

            health.OnDeath += Die;
        }

        private void OnDestroy()
        {
            health.OnDeath -= Die;
        }

        private void Update()
        {
            if (pathFind.TryFindPath(out Vector3 targetPosition))
            {
                MoveAlongPath(targetPosition);
                aim.SetLookTarget(targetPosition);
            }
        }

        private void MoveAlongPath(Vector3 targetPosition)
        {
            Vector3 direction = targetPosition - transform.position;
            movement.Move(direction);
        }

        private void Die()
        {
            scoreService.AddPoints(config.pointsForKill);
            Destroy(gameObject);
        }

        private void OnCollisionEnter(Collision collision)
        {
            if (!attackLayer.Contains(collision.gameObject.layer))
                return;

            if (collision.gameObject.TryGetComponent(out IDamageable damageable))
            {
                damageable.TakeDamage(damage);
            }
        }
    }
}