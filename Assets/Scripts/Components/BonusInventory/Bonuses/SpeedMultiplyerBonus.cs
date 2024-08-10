using System;
using UnityEngine;

namespace TopDownShooter
{
    [Serializable]
    [CreateAssetMenu(fileName = "SpeedMultiplyerBonus", menuName = "GameConfig/SpeedMultiplyerBonus")]
    public class SpeedMultiplyerBonus : BonusBase
    {
        [Header("Speed Multiplyer")]
        public float multiplyer = 1.5f;
        public float duration = 10f;

        private BonusInventoryBase inventory;
        private MovementBase movement;
        private float initialSpeed;
        private float timer;

        public override void OnAdd(GameObject owner, BonusInventoryBase inventory)
        {
            if (!owner.TryGetComponent(out MovementBase movement))
            {
                inventory.RemoveBonus(id);
                return;
            }

            this.inventory = inventory;
            this.movement = movement;
            initialSpeed = movement.MoveSpeed;

            movement.SetSpeed(initialSpeed * multiplyer);
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
                inventory.RemoveBonus(id);
            }
        }

        public override void OnRemove()
        {
            movement?.SetSpeed(initialSpeed);
        }
    }
}