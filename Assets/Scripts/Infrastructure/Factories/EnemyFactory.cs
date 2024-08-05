using UnityEngine;

namespace TopDownShooter
{
    public class EnemyFactory
    {
        private readonly Enemy prefab;
        private readonly Vector3 leftDownLevelCorner;
        private readonly Vector3 rightUpLevelCorner;
        private readonly CameraController camera;
        private readonly BulletFactory bulletFactory;

        private const int MAX_ITERATIONS = 1000;

        public EnemyFactory(Enemy prefab, Vector3 leftDownLevelCorner, Vector3 rightUpLevelCorner, CameraController camera, BulletFactory bulletFactory)
        {
            this.prefab = prefab;
            this.leftDownLevelCorner = leftDownLevelCorner;
            this.rightUpLevelCorner = rightUpLevelCorner;
            this.camera = camera;
            this.bulletFactory = bulletFactory;
        }

        public Enemy Create()
        {
            for (int i = 0; i < MAX_ITERATIONS; i++)
            {
                Vector3 point = GetRandomPointOnLevel();
                if (!camera.IsInsideOuterRect(point))
                {
                    return Instatntiate(point);
                }
            }

            Debug.LogError("Cant find point inside level and outside camera view");
            return null;
        }

        private Enemy Instatntiate(Vector3 position)
        {
            Enemy enemy = Object.Instantiate(prefab, position, Quaternion.identity);
            enemy.Init();
            return enemy;
        }

        private Vector3 GetRandomPointOnLevel()
        {
            float x = Random.Range(leftDownLevelCorner.x, rightUpLevelCorner.x);
            float z = Random.Range(leftDownLevelCorner.z, rightUpLevelCorner.z);

            return new(x, 0, z);
        }
    }
}