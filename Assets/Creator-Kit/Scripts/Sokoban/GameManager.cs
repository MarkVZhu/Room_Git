using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;

public class GameManager : MonoBehaviour
{
    public GameObject prop;
    public Tilemap wallTailmap;
    public Sprite wallSprite;
    private Quaternion oQuaternion;
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        oQuaternion = new Quaternion(0, 0, 0, 0);

        if (!State.Instance.takeDrug1)
            player.GetComponent<PlayerHealth>().health = State.Instance.health;
    }

    /*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            ResetStage();
    }*/

    public void EnterNextLayer(int num, GameObject Ebox)
    {
        //Remove all boxes in the scene
        var boxes = GameObject.FindGameObjectsWithTag("Box");
        foreach (var b in boxes)
        {
            Destroy(b);
        }

        //Health reduce according to how many wall tails left
        player.GetComponent<PlayerHealth>().DamagePlayer((int)(GetTileAmountSprite(wallSprite)/3.5f));

        //Move character and box 
        switch (num)
        {
            case (0):
                player.transform.position = new Vector3(0.5f, 5.5f, 0f);
                enableComponent(GameObject.Instantiate(Ebox, new Vector3(0.5f, 4.5f, 0f), oQuaternion));

                break;
            case (1):
                player.transform.position = new Vector3(0.5f, -6.5f, 0f);
                enableComponent(GameObject.Instantiate(Ebox, new Vector3(0.5f, -5.5f, 0f), oQuaternion));
                break;
            case (2):
                player.transform.position = new Vector3(-5.5f, -0.5f, 0f);
                enableComponent(GameObject.Instantiate(Ebox, new Vector3(-4.5f, -0.5f, 0f), oQuaternion));
                break;
            case (3):
                player.transform.position = new Vector3(6.5f, -0.5f, 0f);
                enableComponent(GameObject.Instantiate(Ebox, new Vector3(5.5f, -0.5f, 0f), oQuaternion));
                break;
            default:
                Debug.Log("Can not enter");
                break;
        }

        enableComponent(GameObject.Instantiate(Ebox, new Vector3(0.5f, -0.5f, 0f), oQuaternion));

        //Check success
        if (!Ebox.GetComponent<Box>().wallTilemap.ContainsTile(Ebox.GetComponent<Box>().tileBaseWall))
        {
            boxes = GameObject.FindGameObjectsWithTag("Box");
            foreach (var b in boxes)
            {
                Destroy(b);
            }
            if (prop)
            {
                prop.SetActive(true);
            }
        }
    }

    void ResetStage()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
       
        HealthBar.HealthCurrent = 160;
    }

    void enableComponent(GameObject gameObject)
    {
        gameObject.GetComponent<Box>().enabled = true;
        gameObject.GetComponent < BoxCollider2D >().enabled= true;
    }

    /// <summary> Get the amount of tiles controlled by a player </summary> 
    public int GetTileAmountSprite(Sprite targetSprite)
    {
        int amount = 0;

        // loop through all of the tiles        
        BoundsInt bounds = wallTailmap.cellBounds;
        foreach (Vector3Int pos in bounds.allPositionsWithin)
        {
            Tile tile = wallTailmap.GetTile<Tile>(pos);
            if (tile != null)
            {
                if (tile.sprite == targetSprite)
                {
                    amount += 1;
                }
            }
        }

        Debug.Log(amount);
        return amount;
    }
}
