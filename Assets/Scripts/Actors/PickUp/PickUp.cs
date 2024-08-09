using System;
using System.Collections;
using UnityEngine;

namespace TopDownShooter
{
    public class PickUp : MonoBehaviour
    {
        [SerializeField] private ItemConfig config;
        [SerializeField] private float timer;

        public void Init(ItemConfig config)
        {
            this.config = config;

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
            if (!collision.gameObject.TryGetComponent(out ICanPickUp _))
                return;

            if (config.TryPickUp(collision.gameObject))
            {
                Destroy(gameObject);
            }
        }
    }
}