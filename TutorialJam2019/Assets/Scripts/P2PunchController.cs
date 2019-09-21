using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2PunchController : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player1")
        {
            FindObjectOfType<GameManager>().HurtP1();
        }
    }
}
