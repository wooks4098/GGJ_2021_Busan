using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Credit : MonoBehaviour
{
    public float time = 0f;
    public float timer;
    public float Speed;
    private void Update()
    {
        time += Time.deltaTime;
        gameObject.transform.position += Vector3.up * Speed * Time.deltaTime;
        if (time >= 70)
        {
            BgmManager.instance.Play(0);
            SceneManager.LoadScene("Title");

        }
    }
}
