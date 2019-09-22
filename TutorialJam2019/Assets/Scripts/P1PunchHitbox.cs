using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1PunchHitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "player2")
        {
            FindObjectOfType<GameManager>().HurtP2();
        }
    }
}
