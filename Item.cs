using System.Collections;
using UnityEngine;




[System.Serializable]
public class Item
{


    public string itemName;
    public int itemID;
    public Texture2D itemIcon;

    public string ObjectSlug { get; set; }


  




public Item(string name)
    {
        itemName = name;
        itemID = GetHashCode();
        itemIcon = Resources.Load<Texture2D>("Icons/" + name);
     
    }

    public Item()
    {

    }


    public override int GetHashCode()
    {
        return itemName.GetHashCode() * 13;
    }
}
