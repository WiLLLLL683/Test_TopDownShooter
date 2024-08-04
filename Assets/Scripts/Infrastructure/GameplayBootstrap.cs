using System;
using System.Collections;
using UnityEngine;

namespace TopDownShooter
{
    public class GameplayBootstrap : MonoBehaviour
    {
        [SerializeField] private Transform playerSpawnPoint;
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
            playerFactory.Create();
        }

        private void Update()
        {
            input.Update();
        }
    }
}