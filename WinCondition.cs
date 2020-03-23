using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCondition : MonoBehaviour
{
    private static int itemCount = 0;


    public static void CollectItem()
    {
        itemCount++;
        Debug.Log(itemCount);
        Debug.Log(FindObjectOfType<ItemDatabase>().GetItems().Count);
        if (itemCount >= FindObjectOfType<ItemDatabase>().GetItems().Count)
        {
            SceneManager.LoadScene("Winscreen");
           
        }
    }
}
