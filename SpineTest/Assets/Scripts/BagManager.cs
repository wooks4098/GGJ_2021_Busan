using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagManager : MonoBehaviour
{
    public List<ItemObject> objectsInMyBag = new List<ItemObject>();
    public static bool isOjectGripped;
    public Collider col;

    Ray2D ray;
    RaycastHit2D rayHit;

    // Start is called before the first frame update
    void Start()
    {
        isOjectGripped = true;
    }

    void Update()
    {
        if (isOjectGripped)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                rayHit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, 1 << LayerMask.NameToLayer("UILayer"));
                if (rayHit.collider == col)
                {
                    Debug.Log("obj");
                }
            }
        }
    }
}
