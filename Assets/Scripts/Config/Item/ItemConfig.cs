using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public abstract class ItemConfig : ScriptableObject
    {
        [Header("Item")]
        public string id;
        public PickUp itemPrefab;
        public float destroyTime;

        public abstract bool TryPickUp(GameObject newOwner);
    }
}