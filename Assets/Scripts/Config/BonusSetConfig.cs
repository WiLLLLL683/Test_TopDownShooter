using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "ItemSetConfig", menuName = "GameConfig/ItemSetConfig")]
    public class BonusSetConfig : ScriptableObject
    {
        public float spawnDelay;
        [SerializeField] private List<BonusBase> items = new();

        public bool TryGetItemConfig(string id, out BonusBase item)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].id == id)
                {
                    item = items[i];
                    return true;
                }
            }

            item = null;
            return false;
        }

        public BonusBase GetRandom()
        {
            int random = Random.Range(0, items.Count);
            return items[random];
        }
    }
}