using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxGiveUp : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            player.GetComponent<PlayerHealth>().DamagePlayer(200);
        }
    }
}
