using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2PunchHitBox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "player1")
        {
            FindObjectOfType<GameManager>().HurtP1();
        }
    }
}
