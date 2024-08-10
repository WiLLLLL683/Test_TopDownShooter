using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace TopDownShooter
{
    public class BonusInventory : BonusInventoryBase
    {
        [SerializeField] private List<BonusBase> initialBonuses;

        private Dictionary<string, BonusBase> bonuses = new();
        private List<string> bonusesToRemove = new();

        public override void Init()
        {
            for (int i = 0; i < initialBonuses.Count; i++)
            {
                AddBonus(initialBonuses[i]);
            }
        }

        private void Update()
        {
            foreach (BonusBase toUpdateItem in bonuses.Values)
            {
                toUpdateItem.OnUpdate();
            }
        }

        private void LateUpdate()
        {
            for (int i = 0; i < bonusesToRemove.Count; i++)
            {
                DestroyBonus(bonusesToRemove[i]);
            }
        }

        public override void AddBonus(BonusBase bonusOrigin)
        {
            if (bonuses.TryGetValue(bonusOrigin.id, out BonusBase bonusInInventory))
            {
                bonusInInventory.OnRepeatAdd();
            }
            else
            {
                BonusBase bonus = ScriptableObject.Instantiate(bonusOrigin);
                bonus.OnAdd(gameObject, this);
                bonuses.Add(bonus.id, bonus);
            }
        }

        public override void RemoveBonus(string id)
        {
            //cache bonus to remove it in lateUpdate
            bonusesToRemove.Add(id);
        }

        private void DestroyBonus(string id)
        {
            bonuses[id].OnRemove();
            bonuses.Remove(id);
            bonusesToRemove.Remove(id);
        }
    }
}