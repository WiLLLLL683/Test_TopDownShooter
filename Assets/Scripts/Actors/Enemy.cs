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

        private EnemyConfig config;
        private ScoreService scoreService;

        public void Init(EnemyConfig config, Transform target, ScoreService scoreService)
        {
            this.config = config;
            this.scoreService = scoreService;

            health.Init(config.health);
            pathFind.SetTarget(target);
            movement.Init(config.moveSpeed);

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
    }
}