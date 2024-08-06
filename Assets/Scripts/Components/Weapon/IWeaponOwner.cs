using System;

namespace TopDownShooter
{
    public interface IWeaponOwner
    {
        public event Action<string> OnWeaponChanged;
        void AddWeapon(WeaponConfig config);
    }
}