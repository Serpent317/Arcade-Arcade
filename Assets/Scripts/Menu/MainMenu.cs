using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Help()
    {
        SceneManager.LoadScene("HowToPlay");
    }
}
