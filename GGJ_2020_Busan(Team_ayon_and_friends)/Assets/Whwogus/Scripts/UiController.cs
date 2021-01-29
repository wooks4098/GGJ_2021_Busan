using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiController : MonoBehaviour
{
    public static UiController instance { get; private set; }
    public GameObject[] bagObjects;

    private void Awake()
    {
        if (instance == null)
            instance = this;
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
