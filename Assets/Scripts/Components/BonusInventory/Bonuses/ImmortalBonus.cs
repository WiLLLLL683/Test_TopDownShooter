using System;
using UnityEngine;

namespace TopDownShooter
{
    [Serializable]
    [CreateAssetMenu(fileName = "ImmortalBonus", menuName = "GameConfig/ImmortalBonus")]
    public class ImmortalBonus : BonusBase
    {
        [Header("Immortal")]
        public float duration;

        private BonusInventoryBase inventory;
        private HealthBase health;
        private float timer;

        public override void OnAdd(GameObject owner, BonusInventoryBase inventory)
        {
            if (!owner.TryGetComponent(out HealthBase health))
            {
                inventory.RemoveBonus(this.id);
                return;
            }

            this.inventory = inventory;
            this.health = health;
            health.SetImmortal(true);
            timer = duration;
        }

        public override void OnRepeatAdd()
        {
            timer = duration;
        }

        public override void OnUpdate()
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                inventory.RemoveBonus(this.id);
            }
        }

        public override void OnRemove()
        {
            health?.SetImmortal(false);
        }
    }
}