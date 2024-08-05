using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "EnemySetConfig", menuName = "GameConfig/EnemySetConfig")]
    public class EnemySetConfig : ScriptableObject
    {
        public float maxSpawnDelay;
        public float minSpawnDelay;
        public float spawnDelayDecrease;
        public float spawnDelayDecreaseRate;

        [SerializeField] private List<EnemyConfig> enemies = new();
        [SerializeField] private EnemyConfig defaultEnemy;

        public EnemyConfig GetRandomEnemy()
        {
            float currentWeight = 0;
            float totalWeight = CalculateTotalWeight();
            float random = Random.Range(0, totalWeight);

            for (int i = 0; i < enemies.Count; i++)
            {
                if (random <= currentWeight)
                {
                    return enemies[i];
                }

                currentWeight += enemies[i].spawnChance;
            }

            return defaultEnemy;
        }

        private float CalculateTotalWeight()
        {
            float totalWeight = 0;

            for (int i = 0; i < enemies.Count; i++)
            {
                totalWeight += enemies[i].spawnChance;
            }

            return totalWeight;
        }
    }
}