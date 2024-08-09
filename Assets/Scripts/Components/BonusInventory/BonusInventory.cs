using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class BonusInventory : BonusInventoryBase
    {
        [SerializeReference] private List<BonusBase> initialBonuses;

        private Dictionary<string, BonusBase> bonuses = new();

        public override void Init()
        {
            for (int i = 0; i < initialBonuses.Count; i++)
            {
                AddBonus(initialBonuses[i]);
            }
        }

        private void Update()
        {
            foreach (var bonus in bonuses.Values)
            {
                bonus.OnUpdate();
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
                bonus.OnAdd(gameObject);
                bonuses.Add(bonus.id, bonus);
            }
        }

        public override void RemoveBonus(string id)
        {
            bonuses[id].OnRemove();
            bonuses.Remove(id);
        }
    }
}