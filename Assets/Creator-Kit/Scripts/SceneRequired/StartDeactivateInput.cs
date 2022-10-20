using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RPGM.UI;
using RPGM.Gameplay;

public class StartDeactivateInput : MonoBehaviour
{
    public float deTime = 9f;
    public Sprite idle;
    private GameObject character;
    // Start is called before the first frame update
    void Start()
    {
        character = GameObject.Find("Character");

        character.GetComponent<Animator>().enabled = false;
        character.GetComponent<SpriteRenderer>().sprite = idle;
        this.GetComponent<InputController>().enabled = false;
        character.GetComponent<CharacterController2D>().enabled = false;
        character.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        Invoke("ActivateInput", deTime);
    }
    void ActivateInput()
    {
        this.GetComponent<InputController>().enabled = true;
        character.GetComponent<CharacterController2D>().enabled = true;
        character.GetComponent<Animator>().enabled = true;
        character.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        character.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
