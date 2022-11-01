using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State : MonoBehaviour
{
    public static State Instance;
    public bool canEnterPlatform = false;
    public bool takeDrug1 = false;
    public bool inject2 = false;
    public int health = 200;
    public bool helpReturn = false;

    private void Awake()
    {
        Application.targetFrameRate = 60;
        if (Instance == null)
        {
            Instance = this;
            //takeDrug1 = true;
            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    public void ResetState()
    {
        canEnterPlatform = false;
        takeDrug1 = false;
        inject2 = false;
        health = 200;
        helpReturn = false;
}
}
