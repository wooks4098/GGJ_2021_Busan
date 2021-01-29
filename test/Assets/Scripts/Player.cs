using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;

    Animator anim;
    Rigidbody2D rigid;

    void Start()
    {
        anim = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

   
    void Update()
    {
        if ((rigid.velocity.y == 0 && rigid.velocity.x == 0))
        {
            anim.SetBool("IsWalk", false);
        }
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            anim.SetBool("IsWalk", true);
        }
        if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position += Vector3.right * Speed * Time.deltaTime;
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
            anim.SetBool("IsWalk", true);
        }
        if (Input.GetKey(KeyCode.W))
        {
            gameObject.transform.position += Vector3.up * Speed * Time.deltaTime;
            anim.SetBool("IsWalk", true);
        }
        if (Input.GetKey(KeyCode.S))
        {
            gameObject.transform.position += Vector3.down * Speed * Time.deltaTime;
            anim.SetBool("IsWalk", true);
        }
    }
}
