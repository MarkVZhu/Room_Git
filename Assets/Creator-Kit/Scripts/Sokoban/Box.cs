using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Box : MonoBehaviour
{
    public Color finishColor;
    public float hitOffset = 0.5f;
    [Header("\nTilemap&Tile\n")] public Tilemap wallTilemap;
    public Tilemap groundTilemap;
    public TileBase tileBaseChangeWall;
    public TileBase tileBaseGround;
    public TileBase tileBaseWall;
    Color originColor;

    private void Start()
    {
        originColor = GetComponent<SpriteRenderer>().color;
    }

    public bool CanMoveToDir(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position + (Vector3)dir * hitOffset, dir, hitOffset);

        if (!hit)
        {
            transform.Translate(dir);
            return true;
        }

        else if (hit.collider.tag == "WallNoPass" || hit.collider.tag == "Box")
        {
            return false;
        }

        Vector3Int v3 = new Vector3Int((int)((transform.position + (Vector3)dir).x - 0.5), (int)((transform.position + (Vector3)dir).y - 0.5), 0);
        wallTilemap.SetTile(v3, tileBaseChangeWall);
        groundTilemap.SetTile(v3, tileBaseGround);
        transform.Translate(dir);
        return true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Target"))
        {
            int angleNum = -1;
            
            switch (other.name)
            {
                case ("TargetU"): 
                    angleNum = 0;
                    break;
                case ("TargetD"): 
                    angleNum = 1;    
                    break;
                case ("TargetL"): 
                    angleNum = 2;     
                    break;
                case ("TargetR"): 
                    angleNum = 3;    
                    break;
                default: 
                    print("No Entrance"); 
                    break;
            }

            FindObjectOfType<GameManager>().EnterNextLayer(angleNum, gameObject);
            GetComponent<SpriteRenderer>().color = finishColor;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Target"))
        {
            GetComponent<SpriteRenderer>().color = originColor;
        }
    }
}
