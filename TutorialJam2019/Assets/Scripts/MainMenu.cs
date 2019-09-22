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

    void QuitGame()
    {
        Application.Quit();
    }

    public void StartGame()
    {
        Invoke("LevelTransition", 1f);
    }

    public void PressQuitGame()
    {
        Invoke("QuitGame", 1f);
    }

}