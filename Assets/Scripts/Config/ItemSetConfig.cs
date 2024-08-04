using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "ItemSetConfig", menuName = "GameConfig/ItemSetConfig")]
    public class ItemSetConfig : ScriptableObject
    {
        [SerializeField] private List<ItemConfig> items = new();

        public bool TryGetItemConfig(string id, out ItemConfig item)
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
    }
}