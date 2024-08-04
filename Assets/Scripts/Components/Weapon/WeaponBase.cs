using System;
using UnityEngine;

namespace TopDownShooter
{
    public abstract class WeaponBase: MonoBehaviour
    {
        public abstract event Action OnShoot;

        public abstract void Init(BulletFactory bulletFactory);
        public abstract void Attack();
    }
}