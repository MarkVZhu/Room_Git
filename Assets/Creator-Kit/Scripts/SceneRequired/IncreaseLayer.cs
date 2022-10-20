using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseLayer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<SpriteRenderer>().sortingOrder = 5;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
    }
}
