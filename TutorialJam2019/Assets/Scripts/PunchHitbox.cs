using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PunchHitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "player1")
        {
            FindObjectOfType<GameManager>().HurtP1();
        }

        if(other.tag == "player2")
        {
            FindObjectOfType<GameManager>().HurtP2();
        }
    }
}
