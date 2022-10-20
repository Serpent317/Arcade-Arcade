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
        GameObject[] titleMusic = GameObject.FindGameObjectsWithTag("Music");
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMusic();
        DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Music"));

        PlayerPrefs.SetInt("Difficulty", 2); // Medium difficulty by default
        PlayerPrefs.SetInt("ScoreMultiplier", 2);
        PlayerPrefs.SetInt("Score", 0);
    }

    public void StartGame()
    {
        Destroy(GameObject.FindGameObjectWithTag("Music"));
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
