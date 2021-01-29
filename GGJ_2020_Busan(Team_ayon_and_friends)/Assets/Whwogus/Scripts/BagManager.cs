using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BagManager : MonoBehaviour
{
    public static bool isOjectGripped;
    public static BagManager instance { get; private set; }
    public GameObject bag;

    private GameObject grippedObj;
    private float itemClickedTime = 0.3f;
    private bool isItemClicked;
    private bool isOjectHighlighted;

    private GameObject highlightObj;
    private Color color1;

    RaycastHit2D rayHit;

    void Start()
    {
        if (instance == null)
            instance = this;
    }

    private void SetPos(GameObject obj, Vector2 pos)
    {
        obj.transform.position = pos;
    }

    void Update()
    {
        if (isItemClicked)
        {
            OnItemClicked();
        }
        if (IsItemTargeted("item", "Item"))
        {
            if (!rayHit.collider.gameObject.GetComponent<ItemObject>().isActivated)
            {
                if (!isOjectHighlighted)
                {
                    highlightObj = rayHit.collider.gameObject;
                    color1 = new Color(rayHit.collider.gameObject.GetComponent<Image>().color.r, rayHit.collider.gameObject.GetComponent<Image>().color.g, rayHit.collider.gameObject.GetComponent<Image>().color.b);
                    rayHit.collider.gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f);
                }
                isOjectHighlighted = true;
            }
        }
        else if (isOjectHighlighted)
        {
            isOjectHighlighted = false;
            highlightObj.GetComponent<Image>().color = color1;
        }
        if (Input.GetMouseButtonDown(0))
        {
            if (IsItemTargeted("item", "Item"))
            {
                grippedObj = rayHit.collider.gameObject;
                grippedObj.transform.SetParent(GameObject.Find("items").transform);
                if (isItemClicked && !grippedObj.GetComponent<ItemObject>().isActivated)
                    OnItemdDoubledClicked(); //double click
                isItemClicked = true;
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            if (IsItemTargeted("inventory", "Bag"))
            {
                if (rayHit.collider.gameObject.transform.childCount < 1)
                {
                    SetItemToRoom(grippedObj, rayHit.collider.gameObject);
                }
                else
                {
                    GameObject tempGO = bag.transform.GetChild(grippedObj.GetComponent<ItemObject>().roomCnt).gameObject;
                    GameObject tempCO = rayHit.collider.gameObject.GetComponentInChildren<ItemObject>().gameObject;
                    SetItemToRoom(grippedObj, rayHit.collider.gameObject);
                    SetItemToRoom(tempCO, tempGO);
                }
            }
            else if (IsItemTargeted("item", "StoryObject"))
            {
                Destroy(grippedObj);
            }
            else
            {
                if (grippedObj.GetComponent<ItemObject>().targetInven == null)
                    SetItemOriginPosition();
            }
        }
    }

    private void SetItemToRoom(GameObject item, GameObject room)
    {
        item.transform.SetParent(room.transform);
        SetPos(item, room.transform.position);
        item.GetComponent<ItemObject>().roomCnt = room.transform.GetSiblingIndex();
    }

    private bool IsItemTargeted(string tag, string layer)
    {
        bool value = false;
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rayHit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity, 1 << LayerMask.NameToLayer(layer));
        if (rayHit.collider != null)
        {
            if (rayHit.collider.tag == tag)
            {
                value = true;
            }
        }
        return value;
    }

    private void SetItemOriginPosition()
    {
        if (grippedObj.GetComponent<ItemObject>().isActivated)
        {
            int itemRoomCnt = grippedObj.GetComponent<ItemObject>().roomCnt;
            grippedObj.transform.position = bag.transform.GetChild(itemRoomCnt).transform.position;
            grippedObj.transform.SetParent(bag.transform.GetChild(itemRoomCnt).transform);
            grippedObj.transform.localPosition = Vector2.zero;
        }
    }

    private void OnItemClicked()
    {
        itemClickedTime -= Time.deltaTime;
        if (itemClickedTime <= 0) //reset
        {
            itemClickedTime = 0.3f;
            isItemClicked = false;
        }
    }

    private void OnItemdDoubledClicked()
    {
        for (int i = 0; i < bag.transform.childCount; i++)
        {
            if (bag.transform.GetChild(i).transform.childCount < 1)
            {
                if (UiController.instance.bagObjects[0].activeSelf)
                    UiController.instance.BagControl();
                grippedObj.transform.SetParent(bag.transform.GetChild(i).transform);
                grippedObj.GetComponent<ItemObject>().isActivated = true;
                grippedObj.GetComponent<ItemObject>().roomCnt = i;
                grippedObj.GetComponent<ItemObject>().targetInven = bag.transform.GetChild(i).gameObject;
                break;
            }
        }
    }

    private void SetItemHighlighted()
    {

    }
}
