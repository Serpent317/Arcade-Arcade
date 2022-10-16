using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public Text creditsTitle, creditsText;
    public GameObject artButton, musicButton;

    private void Start()
    {
        
    }

    public void Title()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void MusicCredits()
    {
        creditsTitle.text = "Music Credits";
        creditsText.text = "Hostiles Inbound: Miguel Johnson\r\nAggressive Gaming Sport: Alex-Productions" +
            "\r\n";
        musicButton.SetActive(false);
        artButton.SetActive(true);
    }

    public void ArtCredits()
    {
        creditsTitle.text = "Art Credits";
        creditsText.text = "Background art: Adobe Stock\r\nOriginal arches: Heritage: Newfoundland " +
            "\r\n\tand Labrador\r\nFaces in arches: Freepik\r\nBoss: Britannica Kids";
        musicButton.SetActive(true);
        artButton.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
