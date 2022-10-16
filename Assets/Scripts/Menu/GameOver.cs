using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text resultText, scoreText, highScoreText;
    public GameObject enemyArt1, enemyArt2;

    private void Start()
    {
        if (PlayerPrefs.GetString("Result").CompareTo("Win") == 0)
        {
            resultText.text = "Congratulations! You Win!";
            enemyArt1.SetActive(false);
            enemyArt2.SetActive(false);
        }
        else if (PlayerPrefs.GetString("Result").CompareTo("Lose") == 0)
        {
            resultText.text = "You Lost! Please try again!";
            enemyArt1.SetActive(true);
            enemyArt2.SetActive(true);
        }

        scoreText.text = PlayerPrefs.GetInt("Score").ToString();
        //highScoreText.text = PlayerPrefs.GetInt("HighScore").ToString();
        
    }

    public void Title()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
