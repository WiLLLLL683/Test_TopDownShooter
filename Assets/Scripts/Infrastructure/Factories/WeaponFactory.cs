using System;
using UnityEngine;

namespace TopDownShooter
{
    public class WeaponFactory
    {
        private readonly BulletFactory bulletFactory;

        public WeaponFactory(BulletFactory bulletFactory)
        {
            this.bulletFactory = bulletFactory;
        }

        public WeaponBase Create(WeaponConfig config, Transform parent)
        {
            WeaponBase weapon = UnityEngine.Object.Instantiate(config.weaponPrefab, parent);
            weapon.Init(bulletFactory);
            return weapon;
        }
    }
}