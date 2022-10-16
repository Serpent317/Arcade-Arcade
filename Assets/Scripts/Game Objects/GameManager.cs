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
        GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().PlayMusic();
        //PlayerPrefs.SetInt("NumEnemies", numEnemies);
        //Debug.Log("Num enemies is " + numEnemies);
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
