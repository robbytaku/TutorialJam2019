using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player1;

    public int P1Life;

    void Start()
    {
        
    }

    void Update()
    {
        if(P1Life <= 0)
        {
            player1.SetActive(false);
        }
    }

    public void HurtP1()
    {
        P1Life -= 1; 
    }
}
