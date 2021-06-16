using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
   // private static GameManager instance;
    public GameObject gameOverScreen_Pref;
    

    public void Start()
    {
        //instance = new GameManager();
    }
    public void Update()
    {
        

    }
    public void ShowGameOverScreen()
    {
        
        gameOverScreen_Pref.SetActive(true);

    }
    public void GameOver()
    {
        ShowGameOverScreen();
    }
   
}
