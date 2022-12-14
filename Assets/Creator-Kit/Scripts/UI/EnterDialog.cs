using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterDialog : MonoBehaviour
{
    public GameObject enterDialogKey;
    public GameObject talkUI;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (this.name.Equals("DoorEnter"))
            {
                Debug.Log(State.Instance.canEnterPlatform);
                if (State.Instance.canEnterPlatform)
                {
                    enterDialogKey.SetActive(true);
                }
            }
            else
                enterDialogKey.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            enterDialogKey.SetActive(false);
        }
    }

    private void Update()
    {
        if(enterDialogKey.activeSelf && Input.GetKeyDown(KeyCode.E)&& talkUI)
        {
            talkUI.SetActive(true);
        }
    }


}
