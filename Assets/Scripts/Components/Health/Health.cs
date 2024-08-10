using System;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class Health : HealthBase
    {
        [SerializeField] private int currentHealth;
        [SerializeField] private int maxHealth;

        [field: SerializeField] public override bool IsDead { get; protected set; }
        [field: SerializeField] public override bool IsImmortal { get; protected set; }

        public override event Action OnDeath;
        public override event Action<(int amount, int currentHealth, int maxHealth)> OnDamageTaken;


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
            if (IsImmortal)
                return;

            currentHealth -= amount;
            OnDamageTaken?.Invoke((amount, currentHealth, maxHealth));

            if (currentHealth <= 0)
            {
                Die();
            }
        }

        public override void SetImmortal(bool isImmortal) => IsImmortal = isImmortal;

        private void Die()
        {
            currentHealth = 0;
            IsDead = true;
            OnDeath?.Invoke();
        }
    }
}