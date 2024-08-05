using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace TopDownShooter
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent navMeshAgent;
        [SerializeField] private HealthBase health;

        private EnemyConfig config;
        private Transform target;
        private ScoreService scoreService;

        public void Init(EnemyConfig config, Transform target, ScoreService scoreService)
        {
            this.config = config;
            this.target = target;
            this.scoreService = scoreService;

            health.Init(config.health);

            health.OnDeath += Die;
        }

        private void OnDestroy()
        {
            health.OnDeath -= Die;
        }

        private void Update()
        {
            MoveToTarget();
        }

        private void MoveToTarget()
        {
            if (target == null)
                return;

            navMeshAgent.SetDestination(target.position);
        }

        private void Die()
        {
            scoreService.AddPoints(config.pointsForKill);
            Destroy(gameObject);
        }
    }
}