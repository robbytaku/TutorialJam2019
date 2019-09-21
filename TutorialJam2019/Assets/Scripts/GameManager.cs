using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;

    public int P1Life;
    public int P2Life;

    void Start()
    {
        
    }

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

    public void HurtP1()
    {
        P1Life -= 1;
    }

    public void HurtP2()
    {
        P2Life -= 1;
    }
}
