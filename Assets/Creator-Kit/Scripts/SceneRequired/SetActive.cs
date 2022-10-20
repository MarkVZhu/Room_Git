using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGM.UI;

public class SetActive : MonoBehaviour
{
    public GameObject go;
    public bool leaveDeactivate = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && go)
        {
            go.SetActive(true);
        }
        if (!leaveDeactivate && GameObject.Find("Controllers"))
        {
            GameObject.Find("Controllers").GetComponent<InputControllerPlatform>().enabled = false;
        }
    }
  
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && leaveDeactivate)
        {
            go.SetActive(false);
        }
    }
}
