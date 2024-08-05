using System;
using System.Collections;
using UnityEngine;

namespace TopDownShooter
{
    public class GameplayBootstrap : MonoBehaviour
    {
        [Header("Level")]
        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private Transform leftDownLevelCorner;
        [SerializeField] private Transform rightUpLevelCorner;
        [SerializeField] private CameraController cameraController;
        [Header("UI")]
        [SerializeField] private HudUI hudUI;
        [Header("Config")]
        [SerializeField] private PrefabConfig prefabConfig;
        [SerializeField] private EnemySetConfig enemySetConfig;

        private PlayerFactory playerFactory;
        private EnemyFactory enemyFactory;
        private BulletFactory bulletFactory;
        private Input input;
        private EnemySpawner enemySpawner;
        private ScoreService scoreService;

        private void Awake()
        {
            //input
            input = new();
            input.Enable();

            //player independent services
            scoreService = new(0); //TODO загрузка очков
            bulletFactory = new(prefabConfig.bullet);
            playerFactory = new(prefabConfig.player, playerSpawnPoint, input, bulletFactory);

            //player spawn
            Player player = playerFactory.Create();

            //player dependent services
            enemyFactory = new(leftDownLevelCorner.position, rightUpLevelCorner.position, cameraController, bulletFactory, scoreService, player.transform);
            enemySpawner = new(enemySetConfig, enemyFactory);
            cameraController.Init(player.transform);

            //UI init
            hudUI.Init(scoreService);
        }

        private void Update()
        {
            input.Update();
            enemySpawner.Update();
        }
    }
}