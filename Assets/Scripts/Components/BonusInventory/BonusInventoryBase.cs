using System;
using UnityEngine;

namespace TopDownShooter
{
    public abstract class BonusInventoryBase : MonoBehaviour
    {
        public abstract void Init();
        public abstract void AddBonus(BonusBase bonusOrigin);
        public abstract void RemoveBonus(string id);
    }
}