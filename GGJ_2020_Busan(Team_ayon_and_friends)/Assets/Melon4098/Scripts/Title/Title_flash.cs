using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Title_flash : MonoBehaviour
{
    public GameObject Light;

    public float timer = 5f;
    public float curtime = 2;

    private void Update()
    {
        curtime += Time.deltaTime;
        if(curtime >= timer)
        {
            StartCoroutine(LightOn());
            curtime = 0;
        }

    }
    IEnumerator LightOn()
    {

        SoundManager.instance.SoundPlay("Lamp_On");

        for (int i = 0; i < 6; i++)
        {
            if (i == 0 || i == 2)
                Light.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().intensity = 0.5f;
            else
                Light.GetComponent<UnityEngine.Experimental.Rendering.Universal.Light2D>().intensity = 1f;
            Light.SetActive(true);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
