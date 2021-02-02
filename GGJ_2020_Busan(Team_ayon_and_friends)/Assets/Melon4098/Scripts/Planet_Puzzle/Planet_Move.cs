using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_Move : MonoBehaviour
{
    public Planet_Puzzle puzzle;
    bool isBeingHeld = false;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity);
            if (hit.collider.tag == "Planet1")
            {
                isBeingHeld = true;
               
            }
        }

        if(Input.GetMouseButtonUp(0))
           {
            isBeingHeld = false;
        }

        if(isBeingHeld)
        {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            this.gameObject.transform.position = new Vector3(mousePos.x, mousePos.y);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Point4")
        {
            puzzle.Change_Planet1(true);

        }
        else if(collision.tag == "Point1" && collision.tag == "Point2" && collision.tag == "Point3")
        {
            puzzle.Change_Planet1(false);

        }
    }

 

}
