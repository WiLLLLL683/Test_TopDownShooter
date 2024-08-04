using System;
using UnityEngine;

namespace TopDownShooter
{
    [System.Serializable]
    public class ItemData
    {
        public string Id;
        public int Amount
        {
            get { return amount; }
            set
            {
                amount = value;
                OnAmountChange?.Invoke(amount);
            }
        }

        [SerializeField] private int amount;

        [field: NonSerialized] public event Action<int> OnAmountChange;
    }
}