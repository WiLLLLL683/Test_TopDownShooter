using System;
using UnityEngine;

namespace TopDownShooter
{
    public abstract class WeaponBase: MonoBehaviour
    {
        public abstract event Action OnAttack;

        public abstract void Init(WeaponConfig config, BulletFactory bulletFactory);
        public abstract void Attack(Vector3 targetPos);
    }
}