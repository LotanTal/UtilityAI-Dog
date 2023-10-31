using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorgiTools.Core
{
    public class Storage : StorageInventory
    {
        [SerializeField] private int maxCapacityPerType;

        private void Start()
        {
            InitializeInventory();
            MaxCapacity = maxCapacityPerType * Inventory.Count;
        }

        public void SetMaxCapacityPerType(int capacity)
        {
            maxCapacityPerType = capacity;
        }

        public override void AddResource(ResourceType r, int amount)
        {
            int amountInInventory = Inventory.Dictionary[r];
            if (amountInInventory + amount > maxCapacityPerType)
            {
                int amountCanAdd = maxCapacityPerType - amountInInventory;
                Inventory.Dictionary[r] += amountCanAdd;
            }
            else
            {
                Inventory.Dictionary[r] += amount;
            }
        }

        public override void RemoveResource(ResourceType r, int amount)
        {
            if (Inventory.Dictionary[r] - amount < 0)
            {
                Inventory.Dictionary[r] = 0;
            }
            else
            {
                Inventory.Dictionary[r] -= amount;
            }
        }
    }
}
