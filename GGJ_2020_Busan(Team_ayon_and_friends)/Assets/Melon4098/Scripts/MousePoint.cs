using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePoint : MonoBehaviour
{
    public GameObject Mouse_Light;


    private float initialZPos = 0f;

    /*void Awake()
    {
    initialZPos = followingCube.transform.position.y;
    }*/

    void Update()
    {
        Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z));
        Mouse_Light.transform.position = new Vector3(newPosition.x, newPosition.y, 0);

        print("X : " + newPosition.x + ", Y : " + newPosition.y + ", Z : " + 0);

    }
}
