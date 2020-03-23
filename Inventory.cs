using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GUISkin skin;
    public int SlotsX, SlotsY;
    public List<Item> inventory = new List<Item>();
    public List<Item> slots = new List<Item>();
    private bool ShowInventory;
    private ItemDatabase database;
    
 

    public static int Count { get; private set; }

    public static Inventory instance;

    void Awake()
    {
        if(instance)
        {
            Destroy(instance);
        }
        instance = this;
    }

    void Start()
    {

        for (int i = 0; i < (SlotsX * SlotsY); i++)
        {
            slots.Add(new Item());
            inventory.Add(new Item());
        }


        database = FindObjectOfType<ItemDatabase>();

        /*
        AddItem(3);
        AddItem(1);
        AddItem(0);
        */

       
        
        


    }



    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            ShowInventory = !ShowInventory;

        }
    }

    


    void OnGUI()
    {
        GUI.skin = skin;

        if (ShowInventory)
        {
            DrawInventory();
        }
    }

    void DrawInventory()
    {
        int i = 0;
        for (int y = 0; y < SlotsX; y++)
        {
            for (int x = 0; x < SlotsY; x++)
            {
                Rect slotRect = new Rect(x * 80, y * 80, 70, 70);
                GUI.Box(slotRect, "", skin.GetStyle("Slot"));
                slots[i] = inventory[i];

                if (slots[i].itemName != null)
                {
                    GUI.DrawTexture(slotRect, slots[i].itemIcon);
                }

                i++;
            }
        }
    }

    public void AddItem(int id)
    {
        for (int i = 0; i < inventory.Count; i++)
        {
            if (inventory[i].itemName == null)
            {
                List<Item> items = database.GetItems();
                for (int j = 0; j < items.Count; j++)
                {
                    if (items[j].itemID == id)
                    {
                        inventory[i] = items[j];
                    }
                }

                break;
            }   
        }
    }

    bool InventoryContains(int id)
    {
        bool result = false;
        for(int i = 0; i<inventory.Count; i++)
        {
            result = inventory[i].itemID == id;
            if (result)
            {
                break;
            }
        }
        return result;
    }

   
}


  