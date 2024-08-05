using System;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class PickUpSpawner
    {
        private readonly PickUpFactory pickUpFactory;
        private readonly ItemSetConfig weaponSet;
        private readonly ItemSetConfig bonusSet;

        private float weaponTimer;
        private float bonusTimer;

        public PickUpSpawner(PickUpFactory pickUpFactory, ItemSetConfig weaponSet, ItemSetConfig bonusSet)
        {
            this.pickUpFactory = pickUpFactory;
            this.weaponSet = weaponSet;
            this.bonusSet = bonusSet;
        }

        public void Update()
        {
            weaponTimer -= Time.deltaTime;
            bonusTimer -= Time.deltaTime;

            if (weaponTimer <= 0)
            {
                SpawnWeapon();
            }

            if (bonusTimer <= 0)
            {
                SpawnBonus();
            }
        }

        private void SpawnWeapon()
        {
            ItemConfig config = weaponSet.GetRandom();
            ItemData item = new(){ Id = config.id, Amount = 1 };
            pickUpFactory.Create(config.prefab, item);

            weaponTimer = weaponSet.spawnDelay;
        }

        private void SpawnBonus()
        {
            ItemConfig config = weaponSet.GetRandom();
            ItemData item = new() { Id = config.id, Amount = 1 };
            pickUpFactory.Create(config.prefab, item);

            bonusTimer = bonusSet.spawnDelay;
        }
    }
}