using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource musik;

    private void Start()
    {
        Invoke("blsF", 2f);
    }

    void blsF()
    {
        musik.Play();
    }

    void LevelTransition()
    {
        SceneManager.LoadScene("Level1");
    }

    void CreditsTransition()
    {
        SceneManager.LoadScene("Credits");
    }

    void QuitGame()
    {
        Application.Quit();
    }

    void MMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void StartGame()
    {
        Invoke("LevelTransition", 1f);
    }

    public void PressQuitGame()
    {
        Invoke("QuitGame", 1f);
    }

    public void PressCredits()
    {
        Invoke("CreditsTransition", 1f);
    }
    
    public void PressBack()
    {
        Invoke("MMenu", 1f);
    }

}