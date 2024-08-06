using System;
using System.Collections;
using UnityEngine;

namespace TopDownShooter
{
    public class Item : MonoBehaviour
    {
        [SerializeField] private ItemConfig config;
        [SerializeField] private int amount;
        [SerializeField] private float timer;

        public void Init(ItemConfig config, int amount)
        {
            this.config = config;
            this.amount = amount;

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

        private void OnCollisionEnter(Collision collision)
        {
            config.OnPickUp(collision.gameObject);
            Destroy(gameObject);
        }
    }
}