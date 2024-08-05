using System;
using UnityEngine;

namespace TopDownShooter
{
    public abstract class HealthBase : MonoBehaviour, IDamageable
    {
        public abstract bool IsDead { get; protected set; }

        public abstract event Action OnDeath;
        public abstract event Action<(int amount, int currentHealth, int maxHealth)> OnDamageTaken;

        public abstract void Init(int maxHealth);
        public abstract void TakeDamage(int amount);
    }
}