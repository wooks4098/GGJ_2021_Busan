using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_jam : MonoBehaviour
{
    bool isBig = false;
    private void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(pos, Vector2.zero, Mathf.Infinity);
            if(hit.collider != null)
            {
                if (hit.collider.tag == "titlejam")
                {
                    if(isBig)
                    {
                        gameObject.transform.localScale = new Vector3(0.2f, 0.2f, 1);
                        isBig = false;
                    }
                    else
                    {
                        SoundManager.instance.SoundPlay("Meow");
                        gameObject.transform.localScale = new Vector3(0.6f, 0.6f, 1);
                        isBig = true;
                    }
                }
            }

        }
    }
}
