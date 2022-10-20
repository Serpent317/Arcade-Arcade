using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Start()
    {
        if (GameObject.FindGameObjectWithTag("WinMusic") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("WinMusic"));
        }
        if (GameObject.FindGameObjectWithTag("LoseMusic") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("LoseMusic"));
        }
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMusic();
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Music"));

        if (!PlayerPrefs.HasKey("Difficulty"))
        {
            PlayerPrefs.SetInt("Difficulty", 2); // Medium difficulty by default
            PlayerPrefs.SetInt("ScoreMultiplier", 2);
            PlayerPrefs.SetInt("Lives", 5);

            PlayerPrefs.SetFloat("EnemySpeed", 6f);
            PlayerPrefs.SetFloat("EnemyBulletSpeed", -6f);
            PlayerPrefs.SetFloat("BulletDelayLow", 1.5f);
            PlayerPrefs.SetFloat("BulletDelayHigh", 3f);
        }
        PlayerPrefs.SetInt("Score", 0);
    }

    public void StartGame()
    {
        // Seems to fix the issue?
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().StopMusic();

        SceneManager.LoadScene("Level 1");
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Help()
    {
        SceneManager.LoadScene("Help");
    }

    public void Options()
    {
        SceneManager.LoadScene("ChooseOptions");
    }
}
