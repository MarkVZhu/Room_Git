using System.Collections;
using System.Collections.Generic;
using RPGM.Gameplay;
using UnityEngine;
using UnityEngine.UI;

public class DialogSystem : MonoBehaviour
{
    [Header("UI Component")]
    public Text textLable;
    public GameObject face01, face02;

    [Header("TXT File")]
    public TextAsset textFile; // Can be .txt, .html, .htm, .xml ...
    public int index; // The index of line in the .txt content
    public float textSpeed;


    bool lineFinished;

    List<string> textList = new List<string>();

    void Awake()
    {
        GetTextFromFile(textFile);
        index = 0;
    }

    private void OnEnable()
    {
        //textLable.text = textList[index];
        //index++;
        lineFinished = true;
        FilpCanInput(GameObject.FindGameObjectWithTag("Player"), false);
        StartCoroutine(SetTextUI());
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && index == textList.Count)
        {
            gameObject.SetActive(false);
            FilpCanInput(GameObject.FindGameObjectWithTag("Player"), true);
            index = 0;
            return;
        }

        if (Input.GetKeyDown(KeyCode.E) && lineFinished)
        {
            //textLable.text = textList[index];
            //index++;
            StartCoroutine(SetTextUI());
        }
    }

    void GetTextFromFile(TextAsset file)
    {
        textList.Clear();
        index = 0;

        var lineDate = file.text.Split('\n');

        foreach (var line in lineDate)
        {
            textList.Add(line);
        }
    }

    IEnumerator SetTextUI()
    {
        lineFinished = false;
        textLable.text = "";

        if (face01 && face02)
        {
            switch (textList[index].Trim().ToString())
            {
                case "A":
                    face02.SetActive(false);
                    face01.SetActive(true);
                    index++;
                    break;
                case "B":
                    face01.SetActive(false);
                    face02.SetActive(true);
                    index++;
                    break;
            }
        }

        for (int i = 0; i < textList[index].Length; i++)
        {
            textLable.text += textList[index][i];

            yield return new WaitForSeconds(textSpeed);
        }

        lineFinished = true;
        index++;
    }

    void FilpCanInput(GameObject character, bool tf)
    {
        character.GetComponent<CharacterController2D>().enabled = tf;
        character.GetComponent<Animator>().enabled = tf;

        if (!tf)
        {
            character.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        }
        else
        {
            character.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
            character.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            if (this.name.Equals("PriestPanel"))
            {
                State.Instance.canEnterPlatform = true;
            }
        }

    }
}
