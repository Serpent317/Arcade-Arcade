using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Options : MonoBehaviour
{
    public Text difficulty;

    void Start()
    {
        if (PlayerPrefs.HasKey("Description"))
        {
            difficulty.text = PlayerPrefs.GetString("Description");
        }
    }

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
        PlayerPrefs.SetInt("Lives", 6);

        PlayerPrefs.SetFloat("EnemySpeed", 4f);
        PlayerPrefs.SetFloat("EnemyBulletSpeed", -5f);
        PlayerPrefs.SetFloat("BulletDelayLow", 2f);
        PlayerPrefs.SetFloat("BulletDelayHigh", 3.5f);

        PlayerPrefs.SetString("Description", "Difficulty:\r\nCurrently\r\nEasy");
        difficulty.text = PlayerPrefs.GetString("Description");
    }

    public void Medium()
    {
        PlayerPrefs.SetInt("Difficulty", 2);
        PlayerPrefs.SetInt("ScoreMultiplier", 2);
        PlayerPrefs.SetInt("Lives", 5);

        PlayerPrefs.SetFloat("EnemySpeed", 6f);
        PlayerPrefs.SetFloat("EnemyBulletSpeed", -6f);
        PlayerPrefs.SetFloat("BulletDelayLow", 1.5f);
        PlayerPrefs.SetFloat("BulletDelayHigh", 3f);

        PlayerPrefs.SetString("Description", "Difficulty:\r\nCurrently\r\nMedium");
        difficulty.text = PlayerPrefs.GetString("Description");
    }

    public void Hard()
    {
        PlayerPrefs.SetInt("Difficulty", 3);
        PlayerPrefs.SetInt("ScoreMultiplier", 5);
        PlayerPrefs.SetInt("Lives", 4);

        PlayerPrefs.SetFloat("EnemySpeed", 7f);
        PlayerPrefs.SetFloat("EnemyBulletSpeed", -7f);
        PlayerPrefs.SetFloat("BulletDelayLow", 1f);
        PlayerPrefs.SetFloat("BulletDelayHigh", 2.5f);

        PlayerPrefs.SetString("Description", "Difficulty:\r\nCurrently\r\nHard");
        difficulty.text = PlayerPrefs.GetString("Description");
    }

    public void Cheats()
    {
        PlayerPrefs.SetInt("Difficulty", 10);
        PlayerPrefs.SetInt("ScoreMultiplier", -10);
        PlayerPrefs.SetInt("Lives", 1);

        PlayerPrefs.SetFloat("EnemySpeed", 10f);
        PlayerPrefs.SetFloat("EnemyBulletSpeed", -20f);
        PlayerPrefs.SetFloat("BulletDelayLow", 0.5f);
        PlayerPrefs.SetFloat("BulletDelayHigh", 1f);

        PlayerPrefs.SetString("Description", "Difficulty:\r\nCurrently\r\nDeath");
        difficulty.text = PlayerPrefs.GetString("Description");

        PlayerPrefs.SetInt("Score", -100);
        SceneManager.LoadScene("Level 1");
    }
}
