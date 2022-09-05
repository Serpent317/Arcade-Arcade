using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
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
