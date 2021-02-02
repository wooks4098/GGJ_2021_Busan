using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Opening_Ending : MonoBehaviour
{
    public float time = 0;
    private void Awake()
    {
        


        BgmManager.instance.Play(1);
    }

    void Update()
    {
        time += Time.deltaTime;
        if(time >= 9)
        {
            if (SceneManager.GetActiveScene().name == "Opening")
                SceneManager.LoadScene("Stage1");
        }
    }
}
