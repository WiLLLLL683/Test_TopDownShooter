using System;
using System.Collections;
using UnityEngine;

namespace TopDownShooter
{
    public abstract class BonusBase : ScriptableObject
    {
        [Header("Bonus")]
        public string id;
        public PickUp pickUpPrefab;
        public float destroyTime = 5f;

        public abstract void OnAdd(GameObject owner, BonusInventoryBase inventory);
        public abstract void OnRepeatAdd();
        public abstract void OnUpdate();
        public abstract void OnRemove();
    }
}