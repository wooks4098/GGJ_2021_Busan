using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatCollision3 : MonoBehaviour
{
    public Stage3Route stage3;
    public CatAnim catAnim;
    private bool collisionSwitch = false;

    private void Start()
    {
        StartCoroutine(catAnimCoroutine());
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "inCircle")
        {
            stage3.CatAnimStart();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!collisionSwitch)
        {
            if (collision.tag == "inCircle")
            {
                collisionSwitch = true;
                stage3.CatAnimStart();
            }
        }
    }

    IEnumerator catAnimCoroutine()
    {
        yield return new WaitForSeconds(1f);
        catAnim.isEatten = true;
    }
}
