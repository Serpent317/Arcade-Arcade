using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public Text resultText;

    private void Start()
    {
        if (PlayerPrefs.GetString("Result").CompareTo("Win") == 0)
        {
            resultText.text = "Congratulations! You Win!";
        }
        else if (PlayerPrefs.GetString("Result").CompareTo("Lose") == 0)
        {
            resultText.text = "You Lost! Please try again!";
        }
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
