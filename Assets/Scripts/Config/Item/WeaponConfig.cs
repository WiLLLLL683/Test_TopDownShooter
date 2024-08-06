using UnityEngine;

namespace TopDownShooter
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "WeaponConfig", menuName = "GameConfig/WeaponConfig")]
    public class WeaponConfig : ItemConfig
    {
        public WeaponBase weaponPrefab;

        public override void OnPickUp(GameObject newOwner)
        {
            if(newOwner.TryGetComponent(out IWeaponOwner weaponOwner))
            {
                weaponOwner.AddWeapon(this);
            }
        }
    }
}