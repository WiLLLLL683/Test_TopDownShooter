using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public abstract class ItemConfig : ScriptableObject
    {
        public string id;
        public Item itemPrefab;
        public float destroyTime;

        public abstract void OnPickUp(GameObject newOwner);
    }
}