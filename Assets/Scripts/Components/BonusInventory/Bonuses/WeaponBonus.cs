using System;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "WeaponBonus", menuName = "GameConfig/WeaponBonus")]
    public class WeaponBonus : BonusBase
    {
        [Header("Weapon")]
        public WeaponBase weaponPrefab;
        public BulletBase bulletPrefab;
        public float bulletSpeed;
        public int damage;
        [Tooltip("Bullets per second"), Min(0.01f)]
        public float shootRate;

        private IWeaponOwner weaponOwner;

        public override void OnAdd(GameObject owner)
        {
            if (owner.TryGetComponent(out IWeaponOwner weaponOwner))
            {
                this.weaponOwner = weaponOwner;
                weaponOwner.AddWeapon(this);
            }
        }

        public override void OnRepeatAdd()
        {

        }

        public override void OnUpdate()
        {

        }

        public override void OnRemove()
        {
            weaponOwner?.RemoveWeapon();
        }
    }
}