using System.Collections;
using System.Collections.Generic;
using SerializableDictionary.Scripts;
using UnityEngine;

namespace CorgiTools.Core
{
    public abstract class StorageInventory : MonoBehaviour
    {
        public SerializableDictionary<ResourceType, int> Inventory = new SerializableDictionary<ResourceType, int>();
        protected int MaxCapacity;

        public virtual void InitializeInventory()
        {

            Inventory.Dictionary[ResourceType.wood] = 0;
            Inventory.Dictionary[ResourceType.stone] = 0;
            Inventory.Dictionary[ResourceType.food] = 0;
        }

        public int CheckInventoryCount()
        {
            int count = 0;
            foreach (int amount in Inventory.Dictionary.Values)
            {
                count += amount;
            }
            return count;
        }

        public virtual float HowFullIsMyInventory()
        {
            int currentTotal = CheckInventoryCount();
            if (MaxCapacity == 0)
            {
                return 0f;
            }
            float fullness = (float)currentTotal / (float)MaxCapacity * 100f;
            return fullness;
        }


        public virtual void AddResource(ResourceType r, int amount)
        {
            Debug.Log("AddResource");
        }
        public virtual void RemoveResource(ResourceType r, int amount)
        {
            Debug.Log("RemoveResource");
        }
    }
}