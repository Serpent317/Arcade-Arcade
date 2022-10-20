using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public Text difficulty;

    public void StartGame()
    {
        Destroy(GameObject.FindGameObjectWithTag("Music"));
        PlayerPrefs.SetInt("Score", 0);
        SceneManager.LoadScene("Level 1");
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Easy()
    {
        PlayerPrefs.SetInt("Difficulty", 1);
        PlayerPrefs.SetInt("ScoreMultiplier", 1);
        difficulty.text = "Difficulty:\r\nCurrently\r\nEasy";
    }

    public void Medium()
    {
        PlayerPrefs.SetInt("Difficulty", 2);
        PlayerPrefs.SetInt("ScoreMultiplier", 2);
        difficulty.text = "Difficulty:\r\nCurrently\r\nMedium";
    }

    public void Hard()
    {
        PlayerPrefs.SetInt("Difficulty", 3);
        PlayerPrefs.SetInt("ScoreMultiplier", 5);
        difficulty.text = "Difficulty:\r\nCurrently\r\nHard";
    }

    public void Cheats()
    {
        PlayerPrefs.SetInt("Difficulty", 10);
        PlayerPrefs.SetInt("ScoreMultiplier", -10);
        PlayerPrefs.SetInt("Score", -100);
        SceneManager.LoadScene("Level 1");
    }
}
