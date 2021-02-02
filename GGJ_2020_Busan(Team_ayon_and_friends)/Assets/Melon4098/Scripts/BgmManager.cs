using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmManager : MonoBehaviour
{
    public static BgmManager instance;
    private AudioSource source;

    //public float BGMVolum;
    public AudioClip[] Audio;

    private WaitForSeconds watiTime = new WaitForSeconds(0.01f);

    private void Awake()
    {

        source = GetComponent<AudioSource>();
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
            instance = this;
        }
        Play(0);
        //BGMVolum = source.volume;
    }
    //public void ChangeVolum(float volum)
    //{
    //    BGMVolum = volum;
    //    source.volume = volum;
    //}

    public void Play(int MusicTrack)
    {
        source.clip = Audio[MusicTrack];
        source.Play();
    }
    public void Stop()
    {
        source.Stop();
    }

    //void BGM_Play()
    //{
    //    switch (SceneManager.GetActiveScene().name)
    //    {
    //        case "Title":
    //            BgmManager.instance.Play(0);
    //            break;
    //        case "Opening":
    //            BgmManager.instance.Play(1);
    //            break;
    //        case "1Stage":
    //            BgmManager.instance.Play(2);

    //            break;

    //        case "2Stage":
    //            BgmManager.instance.Play(3);

    //            break;
    //        case "31Stage":
    //            BgmManager.instance.Play(4);


    //            break;
    //        case "Ending"
    //            BgmManager.instance.Play(5);

    //            break;
    //    }
    //}
}
