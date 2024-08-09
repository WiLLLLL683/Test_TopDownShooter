using System;
using System.Collections;
using UnityEngine;

namespace TopDownShooter
{
    public abstract class BonusBase : ScriptableObject
    {
        public string id;
        public PickUp itemPrefab;
        public float destroyTime;

        public abstract void OnAdd(GameObject owner);
        public abstract void OnRepeatAdd();
        public abstract void OnUpdate();
        public abstract void OnRemove();
    }
}