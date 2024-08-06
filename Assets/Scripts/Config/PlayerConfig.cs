using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "GameConfig/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        public Player prefab;
    }
}