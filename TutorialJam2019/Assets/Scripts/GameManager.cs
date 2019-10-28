using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject[] p1Hearts;
    public GameObject[] p2Hearts;
    public Image p1Wins0;
    public Image p1Wins1;
    public Image p1Wins2;
    public Image p1Wins3;
    public Image p2Wins0;
    public Image p2Wins1;
    public Image p2Wins2;
    public Image p2Wins3;

    static public int p1Wins;
    static public int p2Wins;
    public int P1Life;
    public int P2Life;
    bool P1Won;
    bool P2Won;

    void Desert()
    {
        SceneManager.LoadScene("Level2");
    }

    private void Start()
    {
        if (p1Wins == 0)
        {
            p1Wins0.enabled = true;
            p1Wins1.enabled = false;
            p1Wins2.enabled = false;
            p1Wins3.enabled = false;
            P1Won = false;
            P2Won = false;
        }

        else if (p1Wins == 1)
        {
            p1Wins0.enabled = false;
            p1Wins1.enabled = true;
            p1Wins2.enabled = false;
            p1Wins3.enabled = false;
            P1Won = false;
            P2Won = false;
        }
        else if (p1Wins == 2)
        {
            p1Wins0.enabled = false;
            p1Wins1.enabled = false;
            p1Wins2.enabled = true;
            p1Wins3.enabled = false;
            P1Won = false;
            P2Won = false;
        }
        else if (p1Wins == 3)
        {

        }

        if (p2Wins == 0)
        {
            p2Wins0.enabled = true;
            p2Wins1.enabled = false;
            p2Wins2.enabled = false;
            p2Wins3.enabled = false;
            P1Won = false;
            P2Won = false;
        }
        else if (p2Wins == 1)
        {
            p2Wins0.enabled = false;
            p2Wins1.enabled = true;
            p2Wins2.enabled = false;
            p2Wins3.enabled = false;
            P1Won = false;
            P2Won = false;
        }
        else if (p1Wins == 2)
        {
            p2Wins0.enabled = false;
            p2Wins1.enabled = false;
            p2Wins2.enabled = true;
            p2Wins3.enabled = false;
            P1Won = false;
            P2Won = false;
        }
        else if (p1Wins == 3)
        {

        }
    }

    void Update()
    {
        if(P1Life <= 0)
        {
            player1.SetActive(false);
        }
        if (p1Wins == 1)
        {
            p1Wins0.enabled = false;
            p1Wins1.enabled = true;
        } 
        else if (p1Wins == 2)
        {
            p1Wins1.enabled = false;
            p1Wins2.enabled = true;
        }
        else if (p1Wins == 3)
        {
            p1Wins2.enabled = false;
            p1Wins3.enabled = true;
        }
        if (P2Life <= 0)
        {
            player2.SetActive(false);
        }
        if (p2Wins == 1)
        {
            p2Wins0.enabled = false;
            p2Wins1.enabled = true;
        }
        else if (p2Wins == 2)
        {
            p2Wins1.enabled = false;
            p2Wins2.enabled = true;
        }
        else if (p2Wins == 3)
        {
            p2Wins2.enabled = false;
            p2Wins3.enabled = true;
        }
    }

    IEnumerator RoundReset()
    {
        yield return new WaitForSeconds(3);
        RoundEnd();
    }

    public void HurtP1()
    {
        P1Life -= 1;
        for(int i = 0; i < p1Hearts.Length; i++)
        {
            if(P1Life > i)
            {
                p1Hearts[i].SetActive(true);
            }
            else
            {
                p1Hearts[i].SetActive(false);
            }
            if (P1Life == 0 && P2Won != true)
            {
                P2Won = true;
                p2Wins ++;
                StartCoroutine(RoundReset());
            }
        }
    }

    public void HurtP2()
    {
        P2Life -= 1;
        for (int i = 0; i < p2Hearts.Length; i++)
        {
            if (P2Life > i)
            {
                p2Hearts[i].SetActive(true);
            }
            else
            {
                p2Hearts[i].SetActive(false);
            }
            if (P2Life == 0 && P1Won != true)
            {
                P1Won = true;
                p1Wins++;
                StartCoroutine(RoundReset());
            }
        }
    }

    public void RoundEnd()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
