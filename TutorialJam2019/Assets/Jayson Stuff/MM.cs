using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MM : MonoBehaviour
{
    public void PlayGame ()
    {
        SceneManager.LoadScene("Level01");

    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

}
