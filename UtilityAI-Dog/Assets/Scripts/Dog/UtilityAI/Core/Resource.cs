using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CorgiTools.Core
{
    public enum ResourceType
    {
        food,
        stone,
        wood
    }
    public class Resource : MonoBehaviour
    {
        // [SerializeField] private ResourceType resourceType;
        // public ResourceType ResourceType
        // {
        //     get { return resourceType; }
        //     set { resourceType = value; }
        // }

        // [SerializeField] private int initialAmount;
        // public int InitialAmount
        // {
        //     get { return initialAmount; }
        //     set { initialAmount = value; }
        // }

        // [SerializeField] private int amountAvailable;
        // public int AmountAvailable
        // {
        //     get { return amountAvailable; }
        //     set { amountAvailable = value; }
        // }

        // public delegate void ResourceExhausted();
        // public event ResourceExhausted OnResourceExhausted;

        // void Start()
        // {
        //     amountAvailable = initialAmount;
        // }

        // public void RemoveAmount(int amountToRemove, NPCController npc)
        // {
        //     if (amountToRemove <= AmountAvailable)
        //     {
        //         AmountAvailable -= amountToRemove;
        //         npc.Inventory.AddResource(resourceType, amountToRemove);
        //     }
        //     else
        //     {
        //         npc.Inventory.AddResource(resourceType, AmountAvailable);
        //         AmountAvailable = 0;
        //     }

        //     if (AmountAvailable <= 0)
        //     {
        //         OnResourceExhausted?.Invoke();
        //         Destroy(gameObject);
        //     }
        // }



    }
}
