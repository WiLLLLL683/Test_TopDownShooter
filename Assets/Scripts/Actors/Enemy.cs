using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace TopDownShooter
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private HealthBase health;
        [SerializeField] private float smoothTime;

        private EnemyConfig config;
        private Transform target;
        private ScoreService scoreService;
        private NavMeshPath path;
        private Vector3 velocity = Vector3.zero;

        private const float cornerCheckTolerance = 0.6f;
        private int nextCorner;

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
            FindPath();
            MoveAlongPath();
        }


        private void FindPath()
        {
            if (target == null)
                return;

            path = new();
            if (!NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path))
            {
                path = null;
            }
            nextCorner = 0;
        }

        private void MoveAlongPath()
        {
            if (path == null)
                return;
            if (path.status == NavMeshPathStatus.PathInvalid)
                return;

            nextCorner = FindClosestCorner();

            if ((transform.position - path.corners[nextCorner]).magnitude <= cornerCheckTolerance)
            {
                nextCorner++;
            }

            Vector3 target = path.corners[nextCorner];
            transform.position = Vector3.SmoothDamp(transform.position, target, ref velocity, smoothTime, config.moveSpeed);
        }

        private int FindClosestCorner()
        {
            int closestCorner = path.corners.Length - 1;
            float closestDistance = (path.corners[closestCorner] - transform.position).magnitude;

            for (int i = path.corners.Length - 1; i > 0; i--)
            {
                float distance = (path.corners[i] - transform.position).magnitude;

                if (distance < closestDistance)
                {
                    closestCorner = i;
                    closestDistance = distance;
                }
            }

            return closestCorner;
        }

        private void Die()
        {
            scoreService.AddPoints(config.pointsForKill);
            Destroy(gameObject);
        }
    }
}