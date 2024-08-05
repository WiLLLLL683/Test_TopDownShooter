using UnityEngine;

namespace TopDownShooter
{
    public class EnemyFactory
    {
        private readonly Vector3 leftDownLevelCorner;
        private readonly Vector3 rightUpLevelCorner;
        private readonly CameraController camera;
        private readonly BulletFactory bulletFactory;
        private readonly ScoreService scoreService;
        private readonly Transform target;

        private const int MAX_ITERATIONS = 1000;

        public EnemyFactory(Vector3 leftDownLevelCorner, Vector3 rightUpLevelCorner, CameraController camera, BulletFactory bulletFactory, ScoreService scoreService, Transform target)
        {
            this.leftDownLevelCorner = leftDownLevelCorner;
            this.rightUpLevelCorner = rightUpLevelCorner;
            this.camera = camera;
            this.bulletFactory = bulletFactory;
            this.scoreService = scoreService;
            this.target = target;
        }

        public Enemy Create(EnemyConfig config)
        {
            for (int i = 0; i < MAX_ITERATIONS; i++)
            {
                Vector3 point = GetRandomPointOnLevel();
                if (!camera.IsInsideOuterRect(point))
                {
                    return Instatntiate(config, point);
                }
            }

            Debug.LogError("Cant find point inside level and outside camera view");
            return null;
        }

        private Enemy Instatntiate(EnemyConfig config, Vector3 position)
        {
            Enemy enemy = Object.Instantiate(config.prefab, position, Quaternion.identity);
            enemy.Init(config, target, scoreService);
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