using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TakeInjection : MonoBehaviour
{
    public GameObject buttens;
    public GameObject LeaveFade;
    public Text panelText;

    [Header("End Panel")] 
    public GameObject SuccessN1;
    public GameObject SuccessN2;
    public GameObject FailPanel;

    private void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().StopInvoke();
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerBox>().enabled = false;
        GameObject.Find("GiveUpText").SetActive(false);
    }

    public void TakeInjectionYes()
    {
        buttens.SetActive(false);
        State.Instance.inject2 = true;
        State.Instance.health = 200;

        FailPanel.SetActive(true);

        //Invoke("FadeOut", 2.5f);
        gameObject.SetActive(false);
    }

    public void TakeInjectionNo()
    {
        buttens.SetActive(false);
        State.Instance.inject2 = false;

        if (State.Instance.takeDrug1)
        {
            SuccessN2.SetActive(true);
        }
        else
        {
            SuccessN1.SetActive(true);
        }

        //Invoke("FadeOut", 2.5f);
        gameObject.SetActive(false);
    }

    public void FadeOut()
    {
        LeaveFade.SetActive(true);
    }
}