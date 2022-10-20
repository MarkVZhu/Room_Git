using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainmenuChoice : MonoBehaviour
{
    public GameObject deactivateText;
    public GameObject activateTextY;
    public GameObject timelineY;
    public GameObject activateTextN;
    public GameObject timelineN;
    public GameObject YButton;
    public GameObject NButton;
    public GameObject LeavePanel;

    public void YChoice()
    {
        deactivateText.SetActive(false);
        activateTextY.SetActive(true);
        timelineY.SetActive(true);
        State.Instance.ResetState();
        Invoke("StartGame", 3f);
        DeactivateSelf();
    }

    public void NChoice()
    {
        deactivateText.SetActive(false);
        activateTextN.SetActive(true);
        timelineN.SetActive(true);
        if (State.Instance.helpReturn)
        {
            Invoke("ActivateLeavePanel", 2f);
            Invoke("QuitGame", 5f);
        }
        else
        {
            Invoke("QuitGame", 1.5f);
        }

        DeactivateSelf();
    }

    void DeactivateSelf()
    {
        YButton.SetActive(false);
        NButton.SetActive(false);
        gameObject.GetComponent<Image>().enabled = false;
    }

    void QuitGame()
    {
        Debug.Log("quit");
        Application.Quit();
    }

    void StartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void ActivateLeavePanel()
    {
        LeavePanel.SetActive(true);
    }
}
