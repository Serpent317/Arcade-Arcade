using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene("Gameplay");
    }

    public void Help()
    {
        SceneManager.LoadScene("HowToPlay");
    }
}
