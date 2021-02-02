using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    public static UiController instance { get; private set; }
    public GameObject[] bagObjects;
    private bool isLightOn;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        if (SceneManager.GetActiveScene().name == "Stage2")
            BgmManager.instance.Play(3);
        if (SceneManager.GetActiveScene().name == "Stage3")
            BgmManager.instance.Play(4);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
            BagControl();
        if (Input.GetMouseButtonDown(1))
        {
            isLightOn = !isLightOn;
            Cursor.visible = isLightOn;
        }

        if(Input.GetKey(KeyCode.R))
            UnityEngine.SceneManagement.SceneManager.LoadScene(gameObject.scene.name);
    }

    public void BagControl()
    {
        UIController(bagObjects);
    }

    private void UIController(GameObject[] objs)
    {
        if (objs[0].activeSelf)
        {
            objs[0].SetActive(false);
            objs[1].SetActive(true);
        }
        else
        {
            objs[1].SetActive(false);
            objs[0].SetActive(true);
        }
    }
}
