using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorgiTools.Core
{
    public class NPCInventory : StorageInventory
    {
        // [SerializeField] private int _maxCapacity;
        // [SerializeField] private Billboard InventoryUI;

        // public delegate void InventoryChangedHandler();
        // public event InventoryChangedHandler OnInventoryChanged;
        // void Start()
        // {
        //     InitializeInventory();
        //     SetmaxCapacity(_maxCapacity);
        // }

        // private void OnEnable()
        // {
        //     OnInventoryChanged += InventoryChanged;
        // }
        // private void OnDisable()
        // {
        //     OnInventoryChanged -= InventoryChanged;
        // }
        // public void SetmaxCapacity(int capacity)
        // {
        //     MaxCapacity = capacity;
        // }

        // public void SetUI(Billboard b)
        // {
        //     InventoryUI = b;
        // }

        // public override void AddResource(ResourceType r, int amount)
        // {
        //     int amountInInventory = CheckInventoryCount();
        //     if (amountInInventory + amount > MaxCapacity)
        //     {
        //         int amountCanAdd = MaxCapacity - amountInInventory;
        //         Inventory.Dictionary[r] += amountCanAdd;
        //     }
        //     else
        //     {
        //         Inventory.Dictionary[r] += amount;
        //     }
        //     OnInventoryChanged?.Invoke();
        // }

        // public void RemoveAllResource()
        // {
        //     List<ResourceType> types = new List<ResourceType>();
        //     foreach (ResourceType r in Inventory.Dictionary.Keys)
        //     {
        //         types.Add(r);
        //     }
        //     foreach (ResourceType r in types)
        //     {
        //         Inventory.Dictionary[r] = 0;
        //     }
        //     OnInventoryChanged?.Invoke();
        // }

        // public void InventoryChanged()
        // {
        //     InventoryUI.UpdateInventoryText(Inventory.Dictionary[ResourceType.wood], Inventory.Dictionary[ResourceType.stone], Inventory.Dictionary[ResourceType.food]);
        // }
    }


}