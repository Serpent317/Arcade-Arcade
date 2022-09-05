using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManagerArcade : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetInt("NumEnemies", 7);
    }

    public void EndGame()
    {
        PlayerPrefs.SetString("Result", "Lose");
        SceneManager.LoadScene("GameOver");
    }

    public void Win()
    {
        PlayerPrefs.SetString("Result", "Win");
        SceneManager.LoadScene("GameOver");
    }
}
