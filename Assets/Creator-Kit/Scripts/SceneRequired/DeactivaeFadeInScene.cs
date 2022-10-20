using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeactivaeFadeInScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DeactivateInput", 2f);
    }

    void DeactivateInput()
    {
        gameObject.SetActive(false);
    }
}
