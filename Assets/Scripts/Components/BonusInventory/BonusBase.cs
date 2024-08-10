using System;
using System.Collections;
using UnityEngine;

namespace TopDownShooter
{
    public abstract class BonusBase : ScriptableObject
    {
        [Header("Bonus")]
        public string id;
        public PickUp itemPrefab;
        public float destroyTime;

        public abstract void OnAdd(GameObject owner, BonusInventoryBase inventory);
        public abstract void OnRepeatAdd();
        public abstract void OnUpdate();
        public abstract void OnRemove();
    }
}