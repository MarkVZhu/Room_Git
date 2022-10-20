using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPGM.UI;

public class ActivateTimeline : MonoBehaviour
{
    public GameObject timeline;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && timeline)
        {
            timeline.SetActive(true);
            GameObject.Find("Controllers").GetComponent<StartDeactivateInput>().enabled = true;
        }
    }
}
