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

        private Transform target;
        private CameraCorner leftDownCorner;
        private CameraCorner rightDownCorner;
        private CameraCorner leftUpCorner;
        private CameraCorner rightUpCorner;

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
            //if (leftDownCorner.HasWallHit && leftUpCorner.HasWallHit)
            //{
            //    ClampLeft();
            //}

            //if (rightDownCorner.HasWallHit && rightUpCorner.HasWallHit)
            //{
            //    ClampRight();
            //}

            //if (leftDownCorner.HasWallHit && rightDownCorner.HasWallHit)
            //{
            //    ClampDown();
            //}

            //if (leftUpCorner.HasWallHit && rightUpCorner.HasWallHit)
            //{
            //    ClampUp();
            //}
        }

        private void FollowTarget()
        {
            if (target == null)
                return;

            transform.position = Vector3.Lerp(transform.position, target.position, moveSpeed * Time.deltaTime);
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