using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    Item item;

    [SerializeField]
    private new string name;
    [SerializeField]
    private int id;

    void Awake()
    {
        item = new Item(name);
    }
    

    public Item GetItem()
    {
        return item;
    }
}
