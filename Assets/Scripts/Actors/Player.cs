using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class Player : MonoBehaviour, IWeaponOwner
    {
        [Header("Components")]
        [SerializeField] private HealthBase health;
        [SerializeField] private MovementBase movement;
        [SerializeField] private AimBase aim;
        [SerializeField] private InventoryBase inventory;
        [SerializeField] private Transform weaponSlot;
        [Header("Setup")]
        [SerializeField] private WeaponConfig initialWeapon;

        public event Action<string> OnWeaponChanged;

        private IInput input;
        private WeaponFactory weaponFactory;
        private WeaponBase weapon;
        private Vector3 targetPosition;

        public void Init(IInput input, WeaponFactory weaponFactory)
        {
            this.input = input;
            this.weaponFactory = weaponFactory;

            //TODO health.Init();
            //TODO movement.Init();
            //TODO aim.Init();
            inventory.Init();

            if (initialWeapon != null)
            {
                AddWeapon(initialWeapon);
            }

            input.OnInputMove += Move;
            input.OnInputShoot += Attack;
            input.OnPointerWorldPos += Aim;
            health.OnDeath += Die;
        }

        private void OnDestroy() => Disable();

        public void Disable()
        {
            input.OnInputMove -= Move;
            input.OnInputShoot -= Attack;
            input.OnPointerWorldPos -= Aim;
            health.OnDeath -= Die;
        }

        public void AddWeapon(WeaponConfig config)
        {
            if (weapon != null)
            {
                Destroy(weapon.gameObject);
                weapon = null;
            }
            weapon = weaponFactory.Create(config, weaponSlot);
            OnWeaponChanged?.Invoke(config.id);
        }

        private void Move(Vector2 inputDirection) => movement.Move(new Vector3(inputDirection.x, 0, inputDirection.y));
        private void Attack() => weapon?.Attack(targetPosition);
        private void Aim(Vector3 targetPosition)
        {
            this.targetPosition = targetPosition;
            aim.SetLookTarget(targetPosition);
        }
        private void Die()
        {
            Disable();
        }
    }
}