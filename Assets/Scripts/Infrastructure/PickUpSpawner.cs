﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class PickUpSpawner : IDisposable
    {
        private readonly IWeaponOwner player;
        private readonly PickUpFactory pickUpFactory;
        private readonly BonusSetConfig weaponSet;
        private readonly BonusSetConfig bonusSet;

        private const int MAX_ITERATIONS = 100;

        private float weaponTimer;
        private float bonusTimer;
        private string excludedWeapon;

        public PickUpSpawner(IWeaponOwner player, PickUpFactory pickUpFactory, BonusSetConfig weaponSet, BonusSetConfig bonusSet)
        {
            this.player = player;
            this.pickUpFactory = pickUpFactory;
            this.weaponSet = weaponSet;
            this.bonusSet = bonusSet;

            player.OnWeaponChanged += ExcludeWeapon;
        }

        public void Dispose()
        {
            player.OnWeaponChanged -= ExcludeWeapon;
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
            BonusBase config = null;

            for (int i = 0; i < MAX_ITERATIONS; i++)
            {
                config = weaponSet.GetRandom();

                if (config.id != excludedWeapon)
                    break;
            }

            pickUpFactory.Create(config);

            weaponTimer = weaponSet.spawnDelay;
        }

        private void SpawnBonus()
        {
            BonusBase config = weaponSet.GetRandom();
            pickUpFactory.Create(config);

            bonusTimer = bonusSet.spawnDelay;
        }

        private void ExcludeWeapon(string weaponId) => excludedWeapon = weaponId;
    }
}