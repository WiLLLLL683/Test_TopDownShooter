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
        [SerializeField] private float smoothTime;

        private EnemyConfig config;
        private Transform target;
        private ScoreService scoreService;
        private Vector3 velocity = Vector3.zero;

        public void Init(EnemyConfig config, Transform target, ScoreService scoreService)
        {
            this.config = config;
            this.target = target;
            this.scoreService = scoreService;

            health.Init(config.health);
            pathFind.SetTarget(target);

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
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime, config.moveSpeed);
        }

        private void Die()
        {
            scoreService.AddPoints(config.pointsForKill);
            Destroy(gameObject);
        }
    }
}