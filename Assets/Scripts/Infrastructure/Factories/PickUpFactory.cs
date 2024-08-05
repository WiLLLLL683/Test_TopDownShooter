using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class PickUpFactory
    {
        private readonly CameraController camera;

        public PickUpFactory(CameraController camera)
        {
            this.camera = camera;
        }

        public PickUpItem Create(PickUpItem prefab, ItemData item)
        {
            Vector3 position = GetRandomPointInsideCamera();
            PickUpItem pickUp = GameObject.Instantiate(prefab, position, Quaternion.identity);
            pickUp.Init(item);
            return pickUp;
        }

        private Vector3 GetRandomPointInsideCamera()
        {
            float x = Random.Range(camera.InnerRect.LeftDownCorner.HitPos.x, camera.InnerRect.RightUpCorner.HitPos.x);
            float z = Random.Range(camera.InnerRect.LeftDownCorner.HitPos.z, camera.InnerRect.RightUpCorner.HitPos.z);

            return new(x, 0, z);
        }
    }
}