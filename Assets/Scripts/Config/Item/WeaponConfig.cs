using UnityEngine;

namespace TopDownShooter
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "GameConfig/WeaponConfig")]
    public class WeaponConfig : ItemConfig
    {
        [Header("Weapon")]
        public WeaponBase weaponPrefab;
        public Bullet bulletPrefab;
        public float bulletSpeed;
        public int damage;
        [Tooltip("Bullets per second"), Min(0.01f)]
        public float shootRate;

        public override void OnPickUp(GameObject newOwner)
        {
            if(newOwner.TryGetComponent(out IWeaponOwner weaponOwner))
            {
                weaponOwner.AddWeapon(this);
            }
        }
    }
}