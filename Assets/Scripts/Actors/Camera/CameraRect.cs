using System;
using UnityEngine;

namespace TopDownShooter
{
    public class CameraRect
    {
        public CameraCorner LeftDownCorner { get; private set; }
        public CameraCorner RightDownCorner { get; private set; }
        public CameraCorner LeftUpCorner { get; private set; }
        public CameraCorner RightUpCorner { get; private set; }

        public CameraRect(Camera cam, LayerMask layerMask, LayerMask wallLayer, float margin)
        {
            LeftDownCorner = new(cam, layerMask, wallLayer, new Vector3(0, 0) + new Vector3(margin, margin));
            RightDownCorner = new(cam, layerMask, wallLayer, new Vector3(cam.pixelWidth - 1, 0) + new Vector3(-margin, margin));
            LeftUpCorner = new(cam, layerMask, wallLayer, new Vector3(0, cam.pixelHeight - 1) + new Vector3(margin, -margin));
            RightUpCorner = new(cam, layerMask, wallLayer, new Vector3(cam.pixelWidth - 1, cam.pixelHeight - 1) + new Vector3(-margin, -margin));
        }

        public void UpdateCameraCorners()
        {
            LeftDownCorner?.Update();
            RightDownCorner?.Update();
            LeftUpCorner?.Update();
            RightUpCorner?.Update();
        }
    }
}