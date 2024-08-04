using System;
using System.Collections;
using UnityEngine;

namespace TopDownShooter
{
    public class GameplayBootstrap : MonoBehaviour
    {
        [SerializeField] private Transform playerSpawnPoint;
        [SerializeField] private CameraController cameraController;
        [SerializeField] private PrefabConfig prefabConfig;

        private PlayerFactory playerFactory;
        private BulletFactory bulletFactory;
        private Input input;

        private void Awake()
        {
            input = new();
            bulletFactory = new(prefabConfig.bullet);
            playerFactory = new(prefabConfig.player, playerSpawnPoint, input, bulletFactory);

            input.Enable();
            Player player = playerFactory.Create();
            cameraController.Init(player.transform);
        }

        private void Update()
        {
            input.Update();
        }
    }
}