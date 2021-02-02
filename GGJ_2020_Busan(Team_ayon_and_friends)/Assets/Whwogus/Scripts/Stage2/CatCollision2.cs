using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class CatCollision2 : MonoBehaviour
{
    public GameObject cat;
    public GameObject catTreeObj;
    public GameObject catJumpAnim;
    public GameObject camera1;
    public GameObject cinemachineCam;
    public GameObject smallKey2;
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "inCircle")
        {
            smallKey2.SetActive(false);
            catJumpAnim.SetActive(true);
            cinemachineCam.SetActive(false);
            camera1.transform.position = catTreeObj.transform.position + new Vector3(0, 2f, 0);
            cat.transform.position = catTreeObj.transform.position + new Vector3(-5f, 0, 0);
            catTreeObj.gameObject.SetActive(false);
            cat.SetActive(false);
        }
    }
}
