using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class Player : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private HealthBase health;
        [SerializeField] private MovementBase movement;
        [SerializeField] private AimBase aim;
        [SerializeField] private WeaponBase weapon;
        [SerializeField] private InventoryBase inventory;

        private IInput input;
        private BulletFactory bulletFactory;

        public void Init(IInput input, BulletFactory bulletFactory)
        {
            this.input = input;
            this.bulletFactory = bulletFactory;

            //TODO health.Init();
            //TODO movement.Init();
            //TODO aim.Init();
            weapon.Init(bulletFactory);
            inventory.Init();

            input.OnInputMove += Move;
            input.OnInputShoot += Attack;
            input.OnPointerWorldPos += Aim;
            health.OnDeath += Die;
        }

        private void OnDestroy() => Disable();

        private void Disable()
        {
            input.OnInputMove -= Move;
            input.OnInputShoot -= Attack;
            input.OnPointerWorldPos -= Aim;
            health.OnDeath -= Die;
        }

        private void Move(Vector2 inputDirection) => movement.Move(new Vector3(inputDirection.x, 0, inputDirection.y));
        private void Attack() => weapon.Attack();
        private void Aim(Vector3 targetPosition) => aim.SetLookTarget(targetPosition);
        private void Die()
        {
            Disable();
        }
    }
}