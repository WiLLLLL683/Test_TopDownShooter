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
        [SerializeField] private ItemSetConfig weaponSetConfig;
        [SerializeField] private ItemSetConfig bonusSetConfig;

        private PlayerFactory playerFactory;
        private EnemyFactory enemyFactory;
        private BulletFactory bulletFactory;
        private WeaponFactory weaponFactory;
        private PickUpFactory pickUpFactory;
        private Input input;
        private EnemySpawner enemySpawner;
        private PickUpSpawner pickUpSpawner;
        private ScoreService scoreService;

        private void Awake()
        {
            //input
            input = new();
            input.Enable();

            //player independent services
            scoreService = new(0); //TODO загрузка очков
            bulletFactory = new(prefabConfig.bullet);
            weaponFactory = new(bulletFactory);
            playerFactory = new(prefabConfig.player, playerSpawnPoint, input, weaponFactory, bulletFactory);

            //player spawn
            Player player = playerFactory.Create();

            //player dependent services
            enemyFactory = new(leftDownLevelCorner.position, rightUpLevelCorner.position, cameraController, bulletFactory, scoreService, player.transform);
            enemySpawner = new(enemySetConfig, enemyFactory);
            cameraController.Init(player.transform);
            pickUpFactory = new(cameraController);
            pickUpSpawner = new(pickUpFactory, weaponSetConfig, bonusSetConfig);

            //UI init
            hudUI.Init(scoreService);
        }

        private void Update()
        {
            input.Update();
            enemySpawner.Update();
            pickUpSpawner.Update();
        }
    }
}