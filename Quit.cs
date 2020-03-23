using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quit : MonoBehaviour
{
    LoadGame playerPosData;

    void Start()
    {
        playerPosData = FindObjectOfType<LoadGame>();
    }

    public void QuitGame()
    {
        playerPosData.PlayerPosSave();
        SceneManager.LoadScene("MainMenu");
    }
}
