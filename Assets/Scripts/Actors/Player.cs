using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TopDownShooter
{
    public class Player : MonoBehaviour
    {
        [Header("Components")]
        [SerializeField] private Transform gunPoint;
        [SerializeField] private MovementBase movement;
        [SerializeField] private AimBase aim;
        [SerializeField] private InventoryBase inventory;

        [SerializeField] private int damage;
        [SerializeField] private int bulletSpeed;

        private IInput input;
        private BulletFactory bulletFactory;

        public void Init(IInput input, BulletFactory bulletFactory)
        {
            this.input = input;
            this.bulletFactory = bulletFactory;

            input.OnInputMove += Move;
            input.OnInputShoot += Shoot;
            input.OnPointerWorldPos += aim.SetLookTarget;
        }

        private void OnDestroy()
        {
            input.OnInputMove -= Move;
            input.OnInputShoot -= Shoot;
            input.OnPointerWorldPos -= aim.SetLookTarget;
        }

        private void Move(Vector2 inputDirection) => movement.Move(new Vector3(inputDirection.x, 0, inputDirection.y));

        private void Shoot()
        {
            bulletFactory.Create(gunPoint.position, gunPoint.forward, damage, bulletSpeed);
        }
    }
}