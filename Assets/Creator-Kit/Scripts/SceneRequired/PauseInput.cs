using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGM.Gameplay;

public class PauseInput : MonoBehaviour
{
    // Start is called before the first frame update
    public void PauseInp()
    {
        GameObject character = GameObject.FindGameObjectWithTag("Player");
        character.GetComponent<CharacterController2D>().enabled = false;
        character.GetComponent<Animator>().enabled = false;
        character.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
    }
}
