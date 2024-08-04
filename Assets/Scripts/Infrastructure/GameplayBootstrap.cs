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
        private Input input;

        private void Awake()
        {
            input = new();
            playerFactory = new(prefabConfig.playerPrefab, playerSpawnPoint, input);

            input.Enable();
            playerFactory.Create();
        }

        private void Update()
        {
            input.Update();
        }
    }
}