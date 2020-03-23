using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemDatabase : MonoBehaviour
{
    
    [SerializeField]
    private List<Item> pickupItems = new List<Item>();
    
    /*
    [SerializeField]
    private List<Item> item = new List<Item>();
    */

    void Start()
    {
         Dictionary<int, Item> itemDict = new Dictionary<int, Item>();
     


    List<Pickup> pickups = FindObjectsOfType<Pickup>().ToList();
        
       

        foreach (Pickup pickup in pickups)
        {
            Item item = pickup.GetItem();
            Debug.Log(item);
            if (!itemDict.ContainsKey(item.GetHashCode()))
            {
                itemDict.Add(item.GetHashCode(), item);

            }
        }

        pickupItems = itemDict.Values.ToList();
        /*
        items.Add(new Item("Water", 0));
        items.Add(new Item("Fire", 1));
        items.Add(new Item("ice_cream", 2));
        items.Add(new Item("Banana", 3));
        items.Add(new Item("Cupcake", 4));
        */
    }

    public List<Item> GetItems()
    {
        return pickupItems;
    }



}

