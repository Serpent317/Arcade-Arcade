using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Gameplay");
        PlayerPrefs.SetInt("Score", 0);
    }

    public void Help()
    {
        SceneManager.LoadScene("HowToPlay");
    }
}
