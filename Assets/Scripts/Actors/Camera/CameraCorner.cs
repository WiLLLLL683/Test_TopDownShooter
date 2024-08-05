using System;
using UnityEngine;

namespace TopDownShooter
{
    public class CameraCorner
    {
        public bool HasHit { get; private set; }
        public bool HasWallHit { get; private set; }
        public Vector3 HitPos { get; private set; }
        public RaycastHit HitInfo => hitInfo;

        private RaycastHit hitInfo;
        private Camera cam;
        private LayerMask wallLayer;
        private readonly Vector3 screenPos;
        private readonly Vector3 worldPos;

        public CameraCorner(Camera cam, LayerMask wallLayer, Vector3 screenPos)
        {
            this.cam = cam;
            this.wallLayer = wallLayer;
            this.screenPos = screenPos;
        }

        public void Update()
        {
            HitPos = cam.ScreenToWorldPoint(screenPos);
            HasHit = Physics.Raycast(HitPos, cam.transform.forward, out hitInfo, cam.farClipPlane);

            if (HasHit)
            {
                HasWallHit = wallLayer.Contains(hitInfo.collider.gameObject.layer);
                HitPos = HitInfo.point;
            }
        }
    }
}