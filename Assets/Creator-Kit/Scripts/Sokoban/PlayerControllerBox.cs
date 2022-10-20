using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBox : MonoBehaviour
{
    Vector2 moveDir;
    public float hitOffset = 1.3f;
    public LayerMask detectLayer;
    public bool canInput;

    private void Start()
    {
        canInput = true;
    }

    void Update()
    {
        if (canInput)
        {
            if (Input.GetKeyDown(KeyCode.D))
                moveDir = Vector2.right;

            if (Input.GetKeyDown(KeyCode.A))
                moveDir = Vector2.left;

            if (Input.GetKeyDown(KeyCode.W))
                moveDir = Vector2.up;

            if (Input.GetKeyDown(KeyCode.S))
                moveDir = Vector2.down;

            if (moveDir != Vector2.zero)
            {
                if (CanMoveToDir(moveDir))
                {
                    Move(moveDir);
                }
            }
        }

        moveDir = Vector2.zero;
    }

    bool CanMoveToDir(Vector2 dir)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, dir, hitOffset, detectLayer);

        if (!hit)
            return true;
        else
        {
            if (hit.collider.GetComponent<Box>() != null)
            {
                return hit.collider.GetComponent<Box>().CanMoveToDir(dir);
            }
        }

        return false;
    }

    void Move(Vector2 dir)
    {
        transform.Translate(dir);
    }
}
