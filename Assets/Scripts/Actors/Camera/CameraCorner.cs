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

        private readonly Camera cam;
        private readonly LayerMask layerMask;
        private readonly LayerMask wallLayer;
        private readonly Vector3 screenPos;
        private Vector3 worldPos;
        private RaycastHit hitInfo;

        public CameraCorner(Camera cam, LayerMask layerMask, LayerMask wallLayer, Vector3 screenPos)
        {
            this.cam = cam;
            this.layerMask = layerMask;
            this.wallLayer = wallLayer;
            this.screenPos = screenPos;
        }

        public void Update()
        {
            worldPos = cam.ScreenToWorldPoint(screenPos);
            HasHit = Physics.Raycast(worldPos, cam.transform.forward, out hitInfo, cam.farClipPlane, layerMask);

            if (HasHit)
            {
                HasWallHit = wallLayer.Contains(hitInfo.collider.gameObject.layer);
                HitPos = HitInfo.point;
            }
        }
    }
}