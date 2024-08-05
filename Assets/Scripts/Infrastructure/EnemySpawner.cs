using System;
using System.Collections;
using UnityEngine;

namespace TopDownShooter
{
    public class EnemySpawner
    {
        private readonly EnemySetConfig config;
        private readonly EnemyFactory factory;

        private float spawnDelay;
        private float spawnDelayDecreaseTimer;
        private float enemySpawnTimer;

        public EnemySpawner(EnemySetConfig config, EnemyFactory factory)
        {
            this.config = config;
            this.factory = factory;

            spawnDelay = config.maxSpawnDelay;
        }

        public void Update()
        {
            spawnDelayDecreaseTimer -= Time.deltaTime;
            enemySpawnTimer -= Time.deltaTime;

            if (spawnDelayDecreaseTimer <= 0)
            {
                DecreaseSpawnDelay();
            }

            if (enemySpawnTimer <= 0)
            {
                SpawnEnemy();
            }
        }

        private void SpawnEnemy()
        {
            EnemyConfig enemy = config.GetRandomEnemy();
            factory.Create(enemy);
            enemySpawnTimer = spawnDelay;
        }

        private void DecreaseSpawnDelay()
        {
            spawnDelay -= config.spawnDelayDecrease;
            spawnDelay = Mathf.Max(spawnDelay, config.minSpawnDelay);
            spawnDelayDecreaseTimer = config.spawnDelayDecreaseRate;
        }
    }
}