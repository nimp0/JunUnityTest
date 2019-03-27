using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public static bool isGameOver;
    public GameObject panel;
    
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start ()
    {
        panel.SetActive(false);
        isGameOver = false;
	}	

    public void ShowLoseMessage()
    {       
        panel.SetActive(true);
    }

    public void RestartGame()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void QuitTheGame()
    {
        Application.Quit();
    }
}
