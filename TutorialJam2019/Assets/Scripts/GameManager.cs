using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject[] p1Hearts;
    public GameObject[] p2Hearts;

    public int P1Life;
    public int P2Life;

    void Update()
    {
        if(P1Life <= 0)
        {
            player1.SetActive(false);
        }

        if (P2Life <= 0)
        {
            player2.SetActive(false);
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
            if (P1Life == 0)
            {
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
            if (P2Life == 0)
            {
                StartCoroutine(RoundReset());
            }
        }
    }

    public void RoundEnd()
    {
     
    }
}
