using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "PrefabConfig", menuName = "GameConfig/PrefabConfig")]
    public class PrefabConfig : ScriptableObject
    {
        public Player player;
        public Bullet bullet;
    }
}