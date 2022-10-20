using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TakeDrug : MonoBehaviour
{
    public GameObject buttens;
    public GameObject LeaveFade;
    public Text panelText;

    private void Start()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().StopInvoke();
    }

    public void TakeDrugYes()
    {
        buttens.SetActive(false);
        panelText.text = "You take the drug and feel good. This drug is potent. Everything returns to normal. You go back to the ward to ask the priest something. ";
        State.Instance.takeDrug1 = true;
        State.Instance.health = 200;
        HealthBar.HealthCurrent = HealthBar.HealthMax;
        Invoke("FadeOut", 2.5f);
        this.GetComponent<ToNextLevel>().Invoke("NextLevel", 4f);
    }

    public void TakeDrugNo()
    {
        buttens.SetActive(false);
        panelText.text = "You decide not to take the drug. The headache is still there but not so terrible. You go back to the ward to ask the priest something.";
        State.Instance.takeDrug1 = false;
        State.Instance.health = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().health;
        Invoke("FadeOut", 2.5f);
        this.GetComponent<ToNextLevel>().Invoke("NextLevel", 4f);
    }

    public void FadeOut()
    {
        LeaveFade.SetActive(true);
    }
}
