using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUIController : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;
    public Button creditsButton;

    private void Start()
    {
        playButton.onClick.AddListener(PlayGame);
        exitButton.onClick.AddListener(ExitGame);
        creditsButton.onClick.AddListener(Credits);
    }

    private void PlayGame()
    {
        SceneManager.LoadScene("MainScene");
    }

    private void Credits()
    {
        SceneManager.LoadScene("CreditsScene");
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
