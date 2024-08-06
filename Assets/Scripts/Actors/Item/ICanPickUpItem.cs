using System;

namespace TopDownShooter
{
    public interface ICanPickUpItem
    {
        public void PickUp(ItemConfig item);
    }
}