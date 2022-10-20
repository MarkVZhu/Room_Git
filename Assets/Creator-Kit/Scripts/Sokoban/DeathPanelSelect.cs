using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPanelSelect : MonoBehaviour
{
    public GameObject deathPanelP;
    public GameObject deathPanelN;

    // Start is called before the first frame update
    void Start()
    {
        if (State.Instance.takeDrug1)
        {
            deathPanelN.SetActive(true);
        }
        else
        {
            deathPanelP.SetActive(true);
            State.Instance.helpReturn = true;
        }
    }
}
