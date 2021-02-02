using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemObject : MonoBehaviour, IDragHandler
{
    Vector2 mousePos;
    [HideInInspector] public int roomCnt;
    public bool isActivated;
    public int stage;
    public int id;
    [HideInInspector] public GameObject targetInven;

    public void OnDrag(PointerEventData eventData)
    {/*
        if (isActivated)
        {
            BagManager.isOjectGripped = true;
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = mousePos;
        }
        Debug.Log(isActivated);*/
    }

    void Start()
    {
        isActivated = false;
    }

    void Update()
    {
        if (targetInven != null)
        {
            transform.position = Vector3.Lerp(transform.position, targetInven.transform.position, Time.deltaTime * 5f);
            if (transform.position.y < targetInven.transform.position.y + 0.1f)
            {
                transform.position = targetInven.transform.position;
                targetInven = null;
            }
        }
    }
}
