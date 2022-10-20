using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterCheck : MonoBehaviour
{
    GameObject leaveCanvas;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (leaveCanvas)
            {
                leaveCanvas.SetActive(true);
            }
            Invoke("LoadNextScene", 1f);
        }
    }

    void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1) ;
    }
}
