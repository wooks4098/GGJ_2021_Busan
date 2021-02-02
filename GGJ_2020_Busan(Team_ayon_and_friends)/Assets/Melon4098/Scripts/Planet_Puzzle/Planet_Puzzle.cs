using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet_Puzzle : MonoBehaviour
{
    public GameObject Player;
    public GameObject woodFence;
    public bool Planet1 = false;
    public bool Planet2 = false;
    public bool Planet3 = false;
    public bool Planet4 = false;

        
    void Win()
    {
        if(Planet1 == true && Planet2 == true && Planet3 == true && Planet4 == true)
        {
            woodFence.SetActive(false);
            gameObject.SetActive(false);
        }
    }
    private void Update()
    {
        //gameObject.transform.position = Player.transform.position;
    }

    public void Change_Planet1(bool state)
    {
        Planet1 = state;
        Win();
    }
    public void Change_Planet2(bool state)
    {
        Planet2 = state;
        Win();
    }
    public void Change_Planet3(bool state)
    {
        Planet3 = state;
        Win();
    }
    public void Change_Planet4(bool state)
    {
        Planet4 = state;
        Win();
    }
}
