using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P2KickHitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player1Block")
        {
            FindObjectOfType<PlayerController>().KickP1();
        }
    }
}
