using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_4_Shadow : MonoBehaviour
{
    public Tree_Puzzle Puzzle;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity);
            if (hit.collider.tag == "Shadow4")
            {
                Puzzle.Change_Tree_Shadow(4);
            }
        }
    }
}
