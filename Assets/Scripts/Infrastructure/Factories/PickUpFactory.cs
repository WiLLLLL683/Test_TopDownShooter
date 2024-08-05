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

        public PickUpItem Create(ItemConfig config, int amount)
        {
            Vector3 position = GetRandomPointInsideCamera();
            PickUpItem pickUp = GameObject.Instantiate(config.prefab, position, Quaternion.identity);
            pickUp.Init(config, amount);
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