using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMovement : MonoBehaviour
{
    public GameObject target;
    public GameObject originObj;

    void Update()
    {
        originObj.transform.position = new Vector2(target.transform.position.x, originObj.transform.position.y);
    }
}
