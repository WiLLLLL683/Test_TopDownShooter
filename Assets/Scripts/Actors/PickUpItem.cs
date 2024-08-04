using System;
using System.Collections;
using UnityEngine;

namespace TopDownShooter
{
    public class PickUpItem : MonoBehaviour
    {
        [SerializeField] private ItemData item;

        public void Init(ItemData item)
        {
            this.item = item;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if(collision.gameObject.TryGetComponent(out InventoryBase inventory))
            {
                inventory.AddItem(item);
            }

            Destroy(gameObject);
        }
    }
}