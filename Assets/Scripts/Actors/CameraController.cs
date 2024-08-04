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

        private CameraCorner leftDownCorner;
        private CameraCorner rightDownCorner;
        private CameraCorner leftUpCorner;
        private CameraCorner rightUpCorner;
        private Transform target;
        private Vector3 targetPos;

        public void Init(Transform target)
        {
            this.target = target;
            leftDownCorner = new(cam, wallLayer);
            rightDownCorner = new(cam, wallLayer);
            leftUpCorner = new(cam, wallLayer);
            rightUpCorner = new(cam, wallLayer);
        }

        private void FixedUpdate()
        {
            UpdateCameraCorners();
            CheckForWalls();
        }

        private void Update()
        {
            FollowTarget();
        }

        private void UpdateCameraCorners()
        {
            leftDownCorner?.Update(new Vector3(0, 0));
            rightDownCorner?.Update(new Vector3(cam.pixelWidth - 1, 0));
            leftUpCorner?.Update(new Vector3(0, cam.pixelHeight - 1));
            rightUpCorner?.Update(new Vector3(cam.pixelWidth - 1, cam.pixelHeight - 1));
        }

        private void CheckForWalls()
        {
            targetPos = target.position;

            //clamp left
            if (leftDownCorner.HasWallHit && leftUpCorner.HasWallHit)
            {
                targetPos.x = Mathf.Clamp(targetPos.x, transform.position.x, float.PositiveInfinity);
            }

            //clamp right
            if (rightDownCorner.HasWallHit && rightUpCorner.HasWallHit)
            {
                targetPos.x = Mathf.Clamp(targetPos.x, float.NegativeInfinity, transform.position.x);
            }

            //clamp down
            if (leftDownCorner.HasWallHit && rightDownCorner.HasWallHit)
            {
                targetPos.z = Mathf.Clamp(targetPos.z, transform.position.z, float.PositiveInfinity);
            }

            //clamp up
            if (leftUpCorner.HasWallHit && rightUpCorner.HasWallHit)
            {
                targetPos.z = Mathf.Clamp(targetPos.z, float.NegativeInfinity, transform.position.z);
            }
        }

        private void FollowTarget()
        {
            if (target == null)
                return;

            transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
            //Vector3 direction = (target.position - transform.position).normalized;
            //movement.Move(direction);
        }
    }

    public class CameraCorner
    {
        public Vector3 WorldPos { get; private set; }
        public bool HasWallHit { get; private set; }
        public RaycastHit HitInfo => hitInfo;

        private RaycastHit hitInfo;
        private Camera cam;
        private LayerMask wallLayer;

        public CameraCorner(Camera cam, LayerMask wallLayer)
        {
            this.cam = cam;
            this.wallLayer = wallLayer;
        }

        public void Update(Vector3 screenPos)
        {
            WorldPos = cam.ScreenToWorldPoint(screenPos);
            HasWallHit = Physics.Raycast(WorldPos, cam.transform.forward, out hitInfo, cam.farClipPlane, wallLayer);
        }
    }
}