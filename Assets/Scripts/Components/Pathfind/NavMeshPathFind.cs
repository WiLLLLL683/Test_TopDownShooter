using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace TopDownShooter
{
    public class NavMeshPathFind : PathFindBase
    {
        [SerializeField] private float cornerCheckTolerance = 0.6f;
        [SerializeField] private float delay = 1f;

        private Transform target; //can be null
        private NavMeshPath path;
        private int nextCorner;
        private float timer;

        private void Update()
        {
            timer -= Time.deltaTime;
        }

        public override void SetTarget(Transform target)
        {
            this.target = target;
        }

        public override bool TryFindPath(out Vector3 nextCornerPosition)
        {
            //no path if no target
            if (target == null)
            {
                nextCornerPosition = Vector3.zero;
                return false;
            }

            if (timer <= 0)
            {
                CalculatePath();
            }

            //second try to calculate path
            if (path == null || path.corners.Length == 0)
            {
                CalculatePath();
            }

            if (path == null || path.corners.Length == 0)
            {
                nextCornerPosition = Vector3.zero;
                return false;
            }

            CheckCornerReached();
            nextCornerPosition = path.corners[nextCorner];
            return true;
        }

        private bool CalculatePath()
        {
            timer = delay;
            nextCorner = 0;
            path = new();
            return NavMesh.CalculatePath(transform.position, target.position, NavMesh.AllAreas, path);
        }

        private void CheckCornerReached()
        {
            //chose next corner if current is already reached
            if ((transform.position - path.corners[nextCorner]).magnitude <= cornerCheckTolerance)
            {
                nextCorner = Mathf.Min(nextCorner + 1, path.corners.Length - 1);
            }
        }
    }
}