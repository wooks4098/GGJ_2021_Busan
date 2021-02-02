using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingScene : MonoBehaviour
{
    public float time = 0;


    void Update()
    {
        time += Time.deltaTime;
        if (time >= 9)
        {
            if (SceneManager.GetActiveScene().name == "EndingScene")
            {
                // Mouse Lock

                Cursor.lockState = CursorLockMode.None;
                //BgmManager.instance.Play(0);
                SceneManager.LoadScene("Credit");

                // Cursor visible
            }

        }
    }
}
