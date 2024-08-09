using System;

namespace TopDownShooter
{
    public interface IWeaponOwner: ICanPickUp
    {
        public event Action<string> OnWeaponChanged;
        void AddWeapon(WeaponConfig config);
    }
}