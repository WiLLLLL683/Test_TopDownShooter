using System;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class Health : HealthBase
    {
        public override bool IsDead { get; protected set; }

        public override event Action OnDeath;
        public override event Action<(int amount, int currentHealth, int maxHealth)> OnDamageTaken;

        [SerializeField] private int currentHealth;
        [SerializeField] private int maxHealth;

        public override void Init(int maxHealth)
        {
            this.maxHealth = maxHealth;
            this.currentHealth = maxHealth;
        }

        public override void TakeDamage(int amount)
        {
            if (amount <= 0)
                return;
            if (IsDead)
                return;

            currentHealth -= amount;
            OnDamageTaken?.Invoke((amount, currentHealth, maxHealth));

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            currentHealth = 0;
            IsDead = true;
            OnDeath?.Invoke();
        }
    }
}