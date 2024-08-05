using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "GameConfig/EnemyConfig")]
    public class EnemyConfig : ScriptableObject
    {
        public Enemy prefab;
        public int health;
        [Tooltip("units per second")]
        public float moveSpeed;
        public int pointsForKill;
        public float spawnChance;
    }
}