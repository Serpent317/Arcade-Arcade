using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int numEnemies;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Music") != null)
        {
            DontDestroyOnLoad(GameObject.FindGameObjectWithTag("Music"));
        }
    }

    public void EnemyDied()
    {
        // Game manager should be the one to handle numEnemies, not Player
        // Also, enemies can call this through public Game manager method
        numEnemies--;
        if (numEnemies == 0)
        {
            //StartCoroutine(PauseAMoment());
            Win();
        }
    }

    public void EndGame()
    {
        if (GameObject.FindGameObjectWithTag("Music") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("Music"));
            GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().StopMusic();
        }
        PlayerPrefs.SetString("Result", "Lose");
        SceneManager.LoadScene("GameOver");
    }

    public void Win()
    {
        if (GameObject.FindGameObjectWithTag("Music") != null)
        {
            Destroy(GameObject.FindGameObjectWithTag("Music"));
            GameObject.FindGameObjectWithTag("Music").GetComponent<Music>().StopMusic();
        }
        PlayerPrefs.SetString("Result", "Win");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // For dramatic effect, player can take a breather before starting the next level
    // Might be unnecessary, enemies alreay pause a moment after dying
    IEnumerator PauseAMoment()
    {
        yield return new WaitForSeconds(1f);
        Win();
    }
}
