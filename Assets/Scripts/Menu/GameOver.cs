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

        if (GameObject.FindGameObjectWithTag("Music") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("Music"));
        }

        if (PlayerPrefs.GetString("Result").CompareTo("Win") == 0)
        {
            GameObject.FindGameObjectWithTag("WinMusic").GetComponent<Music>().PlayMusic();
            resultText.text = "Congratulations! You Win!";
            if (PlayerPrefs.GetInt("Difficulty") == 10)
            {
                resultText.text = "How the-?! I mean\r\nCongratulations! You Win!";
            }
            enemyArt1.SetActive(false);
            enemyArt2.SetActive(false);

        }
        else if (PlayerPrefs.GetString("Result").CompareTo("Lose") == 0)
        {
            GameObject.FindGameObjectWithTag("LoseMusic").GetComponent<Music>().PlayMusic();
            resultText.text = "You Lost! Please try again!";
            if (PlayerPrefs.GetInt("Difficulty") == 10)
            {
                resultText.text = "\"Cheaters never prosper\"\r\n- Marmelstein";
            }
            enemyArt1.SetActive(true);
            enemyArt2.SetActive(true);
        }

        scoreText.text = PlayerPrefs.GetInt("Score").ToString();
    }

    public void Title()
    {
        if (GameObject.FindGameObjectWithTag("WinMusic") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("WinMusic"));
        }
        if (GameObject.FindGameObjectWithTag("LoseMusic") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("LoseMusic"));
        }
        SceneManager.LoadScene("MainMenu");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Quit()
    {
        Application.Quit();
    }
}
