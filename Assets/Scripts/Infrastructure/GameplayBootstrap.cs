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
            input = new();
            scoreService = new(0); //TODO загрузка очков
            bulletFactory = new(prefabConfig.bullet);
            playerFactory = new(prefabConfig.player, playerSpawnPoint, input, bulletFactory);
            enemyFactory = new(leftDownLevelCorner.position, rightUpLevelCorner.position, cameraController, bulletFactory, scoreService);
            enemySpawner = new(enemySetConfig, enemyFactory);

            input.Enable();
            Player player = playerFactory.Create();
            cameraController.Init(player.transform);
            hudUI.Init(scoreService);
        }

        private void Update()
        {
            input.Update();
            enemySpawner.Update();
        }
    }
}