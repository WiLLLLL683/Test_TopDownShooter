using System;
using System.Collections;
using UnityEngine;

namespace TopDownShooter
{
    public class GameplayBootstrap : MonoBehaviour
    {
        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private Transform leftDownLevelCorner;
        [SerializeField] private Transform rightUpLevelCorner;
        [SerializeField] private CameraController cameraController;
        [SerializeField] private PrefabConfig prefabConfig;
        [SerializeField] private EnemySetConfig enemySetConfig;

        private PlayerFactory playerFactory;
        private EnemyFactory enemyFactory;
        private BulletFactory bulletFactory;
        private Input input;
        private EnemySpawner enemySpawner;

        private void Awake()
        {
            input = new();
            bulletFactory = new(prefabConfig.bullet);
            playerFactory = new(prefabConfig.player, playerSpawnPoint, input, bulletFactory);
            enemyFactory = new(leftDownLevelCorner.position, rightUpLevelCorner.position, cameraController, bulletFactory);
            enemySpawner = new(enemySetConfig, enemyFactory);

            input.Enable();
            Player player = playerFactory.Create();
            cameraController.Init(player.transform);
        }

        private void Update()
        {
            input.Update();
            enemySpawner.Update();
        }
    }
}