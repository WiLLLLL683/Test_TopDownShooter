using System;
using System.Collections;
using UnityEngine;

namespace TopDownShooter
{
    public class PickUp : MonoBehaviour
    {
        [SerializeField] private BonusBase bonus;
        [SerializeField] private float timer;

        public void Init(BonusBase config)
        {
            this.bonus = config;

            timer = config.destroyTime;
        }

        public void Update()
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                Destroy(gameObject);
            }
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.gameObject.TryGetComponent(out BonusInventoryBase bonusInventory))
            {
                bonusInventory.AddBonus(bonus);
                Destroy(gameObject);
            }
        }
    }
}