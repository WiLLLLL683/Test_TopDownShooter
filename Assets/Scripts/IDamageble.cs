using System;
using System.Collections;
using UnityEngine;

namespace TopDownShooter
{
    public interface IDamageable
    {
        public void TakeDamage(int amount);
    }
}