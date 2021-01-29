using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float Speed;
    private Vector2 vector;

    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

    }
    private void FixedUpdate()
    {

       
    }
    void Update()
    {
        Move();
    }

    void Move()
    {
        if (Input.GetKey(KeyCode.A))
            gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        if (Input.GetKey(KeyCode.D))
            gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        vector.x = Input.GetAxisRaw("Horizontal");
        vector.y = Input.GetAxisRaw("Vertical");

        rigid.velocity = vector.normalized * Speed;



        //if (Input.GetKey(KeyCode.A))
        //{
        //    gameObject.transform.position += Vector3.left * Speed * Time.deltaTime;
        //    gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
        //}
        //if (Input.GetKey(KeyCode.D))
        //{
        //    gameObject.transform.position += Vector3.right * Speed * Time.deltaTime;
        //    gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
        //}
        //if (Input.GetKey(KeyCode.W))
        //{
        //    gameObject.transform.position += Vector3.up * Speed * Time.deltaTime;
        //}
        //if (Input.GetKey(KeyCode.S))
        //{
        //    gameObject.transform.position += Vector3.down * Speed * Time.deltaTime;
        //}
    }
}
