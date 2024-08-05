using System;
using System.Collections;
using UnityEngine;

namespace TopDownShooter
{
    public class PickUpItem : MonoBehaviour
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
            if(collision.gameObject.TryGetComponent(out InventoryBase inventory))
            {
                ItemData item = new() { Id = config.id, Amount = amount };
                inventory.AddItem(item);
            }

            Destroy(gameObject);
        }
    }
}