using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Resume : MonoBehaviour
{
    public GameObject ResumePrompt;
    private bool canResume = false;
    public bool canBackToMainmenu = false;
    private bool tempM;
    public float delayTime = 2f;

    // Start is called before the first frame update
    void Start()
    {
        tempM = canBackToMainmenu;
        canBackToMainmenu = false;
        Invoke("ShowPrompt", delayTime);
    }

    private void OnEnable()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().StopInvoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (canResume && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        if (canBackToMainmenu && Input.GetKeyDown(KeyCode.E))
        {
            SceneManager.LoadScene(0);
        }
    }

    void ShowPrompt()
    {
        Debug.Log("Prompt");
        ResumePrompt.SetActive(true);
        if (!tempM)
        {
            canResume = true;
        }
        else
        {
            canBackToMainmenu = true;
        }
        CancelInvoke("ShowPrompt");
    }
}
