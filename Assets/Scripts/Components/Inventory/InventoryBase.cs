using System;
using UnityEngine;

namespace TopDownShooter
{
    public abstract class InventoryBase : MonoBehaviour
    {
        public abstract event Action OnItemPickUp;
        public abstract void Init();
        public abstract void AddItem(ItemData item);
        public abstract bool TryGetItem(string name, out ItemData item);
    }
}