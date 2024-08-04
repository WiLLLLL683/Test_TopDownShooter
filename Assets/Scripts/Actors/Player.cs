using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class Player : MonoBehaviour
    {
        [Header("Components")]
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

            weapon.Init(bulletFactory);

            input.OnInputMove += Move;
            input.OnInputShoot += Attack;
            input.OnPointerWorldPos += Aim;
        }

        private void OnDestroy()
        {
            input.OnInputMove -= Move;
            input.OnInputShoot -= Attack;
            input.OnPointerWorldPos -= Aim;
        }

        private void Move(Vector2 inputDirection) => movement.Move(new Vector3(inputDirection.x, 0, inputDirection.y));
        private void Attack() => weapon.Attack();
        private void Aim(Vector3 targetPosition) => aim.SetLookTarget(targetPosition);
    }
}