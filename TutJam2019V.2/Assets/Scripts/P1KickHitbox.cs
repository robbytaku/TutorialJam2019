using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P1KickHitbox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player2Block")
        {
            FindObjectOfType<Player2Controller>().KickP2();
        }
    }
}
