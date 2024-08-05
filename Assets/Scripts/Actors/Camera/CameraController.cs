using System;
using System.Collections;
using UnityEngine;

namespace TopDownShooter
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Camera cam;
        [SerializeField] private float moveSpeed;
        [SerializeField] private LayerMask wallLayer;
        [SerializeField] private float innerMargin;
        [SerializeField] private float outerMargin;

        public CameraRect InnerRect { get; private set; }
        public CameraRect OuterRect { get; private set; }

        private Transform target;
        private Vector3 targetPos;

        public void Init(Transform target)
        {
            this.target = target;
            InnerRect = new(cam, wallLayer, innerMargin);
            OuterRect = new(cam, wallLayer, outerMargin);

            InnerRect.UpdateCameraCorners();
            OuterRect.UpdateCameraCorners();
            ClampMovement();
        }

        private void FixedUpdate()
        {
            InnerRect.UpdateCameraCorners();
            OuterRect.UpdateCameraCorners();
            ClampMovement();
        }

        private void Update()
        {
            FollowTarget();
        }

        public bool IsInsideOuterRect(Vector3 point)
        {
            bool isInsideX = OuterRect.LeftDownCorner.HitPos.x <= point.x && point.x <= OuterRect.RightUpCorner.HitPos.x;
            bool isInsideZ = OuterRect.LeftDownCorner.HitPos.z <= point.z && point.z <= OuterRect.RightUpCorner.HitPos.z;

            return isInsideX && isInsideZ;
        }

        public bool IsInsideInnerRect(Vector3 point)
        {
            bool isInsideX = InnerRect.LeftDownCorner.HitPos.x <= point.x && point.x <= InnerRect.RightUpCorner.HitPos.x;
            bool isInsideZ = InnerRect.LeftDownCorner.HitPos.z <= point.z && point.z <= InnerRect.RightUpCorner.HitPos.z;

            return isInsideX && isInsideZ;
        }

        private void ClampMovement()
        {
            targetPos = target.position;

            //clamp left
            if (InnerRect.LeftDownCorner.HasWallHit && InnerRect.LeftUpCorner.HasWallHit)
            {
                targetPos.x = Mathf.Clamp(targetPos.x, transform.position.x, float.PositiveInfinity);
            }

            //clamp right
            if (InnerRect.RightDownCorner.HasWallHit && InnerRect.RightUpCorner.HasWallHit)
            {
                targetPos.x = Mathf.Clamp(targetPos.x, float.NegativeInfinity, transform.position.x);
            }

            //clamp down
            if (InnerRect.LeftDownCorner.HasWallHit && InnerRect.RightDownCorner.HasWallHit)
            {
                targetPos.z = Mathf.Clamp(targetPos.z, transform.position.z, float.PositiveInfinity);
            }

            //clamp up
            if (InnerRect.LeftUpCorner.HasWallHit && InnerRect.RightUpCorner.HasWallHit)
            {
                targetPos.z = Mathf.Clamp(targetPos.z, float.NegativeInfinity, transform.position.z);
            }
        }

        private void FollowTarget()
        {
            if (target == null)
                return;

            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
        }

        //private void OnDrawGizmosSelected()
        //{
        //    Gizmos.color = Color.red;
        //    Gizmos.DrawSphere(LeftDownCorner.HitInfo.point, 1);
        //    Gizmos.DrawSphere(RightDownCorner.HitInfo.point, 1);
        //    Gizmos.DrawSphere(LeftUpCorner.HitInfo.point, 1);
        //    Gizmos.DrawSphere(RightUpCorner.HitInfo.point, 1);
        //}
    }
}