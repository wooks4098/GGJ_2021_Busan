using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Player;
    void Start()
    {
        
    }

    void Update()
    {
        Vector3 vec= new Vector3(Player.transform.position.x, Player.transform.position.y,-10);
        gameObject.transform.position = vec;

    }
}
