using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public int numEnemies;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Music") != null)
        {
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Music"));
        }
    }

    public void EndGame()
    {
        PlayerPrefs.SetString("Result", "Lose");
        SceneManager.LoadScene("GameOver");
    }

    public void Win()
    {
        PlayerPrefs.SetString("Result", "Win");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
