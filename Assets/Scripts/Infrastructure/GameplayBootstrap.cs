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

        private PlayerFactory playerFactory;
        private EnemyFactory enemyFactory;
        private BulletFactory bulletFactory;
        private Input input;

        private void Awake()
        {
            input = new();
            bulletFactory = new(prefabConfig.bullet);
            playerFactory = new(prefabConfig.player, playerSpawnPoint, input, bulletFactory);
            enemyFactory = new(prefabConfig.enemy, leftDownLevelCorner.position, rightUpLevelCorner.position, cameraController, bulletFactory);

            input.Enable();
            Player player = playerFactory.Create();
            cameraController.Init(player.transform);
        }

        private void Start()
        {
            for (int i = 0; i < 100; i++)
            {
                enemyFactory.Create();
            }
        }

        private void Update()
        {
            input.Update();
        }
    }
}