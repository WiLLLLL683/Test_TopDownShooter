using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class Inventory : InventoryBase
    {
        [SerializeField] private List<ItemData> initialItems;

        public override event Action OnItemPickUp;

        private Dictionary<string, ItemData> items = new();

        public override void Init()
        {
            for (int i = 0; i < initialItems.Count; i++)
            {
                AddItem(initialItems[i]);
            }
        }

        public override void AddItem(ItemData item)
        {
            if (items.TryGetValue(item.Id, out ItemData itemInInventory))
            {
                itemInInventory.Amount += item.Amount;
            }
            else
            {
                items.Add(item.Id, item);
            }
            OnItemPickUp?.Invoke();
        }

        public override bool TryGetItem(string id, out ItemData item)
        {
            if (!items.ContainsKey(id))
            {
                item = null;
                return false;
            }

            item = items[id];
            return true;
        }
    }
}
