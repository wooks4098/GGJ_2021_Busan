using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BagManager : MonoBehaviour
{
    public static bool isOjectGripped;
    public static BagManager instance { get; private set; }
    public GameObject bag;
    public SceneItemManager sceneItem;
    public StageCnt stage;

    [HideInInspector]public GameObject grippedObj;
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

        if (SceneManager.GetActiveScene().name == "Stage1")
            stage = StageCnt.stage1;
        else if (SceneManager.GetActiveScene().name == "Stage2")
            stage = StageCnt.stage2;
        else if (SceneManager.GetActiveScene().name == "Stage3")
            stage = StageCnt.stage3;
    }

    public enum StageCnt
    {
        stage1,
        stage2,
        stage3,
    }

    private void SetPos(GameObject obj, Vector2 pos)
    {
        obj.transform.position = pos;
    }

    private void ObstacleRunMethod(StageCnt a)
    {
        if (a == StageCnt.stage1)
        {
            grippedObj = rayHit.collider.gameObject;
            if (sceneItem.stage1List[grippedObj.GetComponent<ItemObject>().id].type == ItemObjectInformation.ItemType.obstacle)
                sceneItem.stage1System.RunObstacle(sceneItem.stage1List[grippedObj.GetComponent<ItemObject>().id].itemName);
        }
        else if (a == StageCnt.stage2)
        {
            grippedObj = rayHit.collider.gameObject;
            if (sceneItem.stage2List[grippedObj.GetComponent<ItemObject>().id].type == ItemObjectInformation.ItemType.obstacle)
                sceneItem.stage2System.RunObstacle(sceneItem.stage2List[grippedObj.GetComponent<ItemObject>().id].itemName);
        }
        else if (a == StageCnt.stage3)
        {
            grippedObj = rayHit.collider.gameObject;
            if (sceneItem.stage3List[grippedObj.GetComponent<ItemObject>().id].type == ItemObjectInformation.ItemType.obstacle)
                sceneItem.stage3System.RunObstacle(sceneItem.stage3List[grippedObj.GetComponent<ItemObject>().id].itemName);
        }
    }

    private void KeyRunMethod(StageCnt a)
    {
        if (a == StageCnt.stage1)
        {
            if (sceneItem.stage1List[grippedObj.GetComponent<ItemObject>().id].targetId != -1)
            {
                int targetObstacle = sceneItem.stage1List[grippedObj.GetComponent<ItemObject>().id].targetId;
                if (targetObstacle == rayHit.collider.gameObject.GetComponent<ItemObject>().id)
                {
                    Destroy(grippedObj);
                    Debug.Log(sceneItem.stage1List[grippedObj.GetComponent<ItemObject>().id].itemName);
                    sceneItem.stage1System.RunStage1(sceneItem.stage1List[grippedObj.GetComponent<ItemObject>().id].itemName);
                }
                else
                {
                    if (grippedObj.GetComponent<ItemObject>().targetInven == null)
                        SetItemOriginPosition();
                }
            }
        }
        else if (a == StageCnt.stage2)
        {
            if (sceneItem.stage2List[grippedObj.GetComponent<ItemObject>().id].targetId != -1)
            {
                int targetObstacle = sceneItem.stage2List[grippedObj.GetComponent<ItemObject>().id].targetId;
                if (targetObstacle == rayHit.collider.gameObject.GetComponent<ItemObject>().id)
                {
                    Destroy(grippedObj);
                    Debug.Log(sceneItem.stage2List[grippedObj.GetComponent<ItemObject>().id].itemName);
                    sceneItem.stage2System.RunStage2(sceneItem.stage2List[grippedObj.GetComponent<ItemObject>().id].itemName);
                }
                else
                {
                    if (grippedObj.GetComponent<ItemObject>().targetInven == null)
                        SetItemOriginPosition();
                }
            }
        }
        else if (a == StageCnt.stage3)
        {
            if (sceneItem.stage3List[grippedObj.GetComponent<ItemObject>().id].targetId != -1)
            {
                int targetObstacle = sceneItem.stage3List[grippedObj.GetComponent<ItemObject>().id].targetId;
                if (targetObstacle == rayHit.collider.gameObject.GetComponent<ItemObject>().id)
                {
                    Destroy(grippedObj);
                    Debug.Log(sceneItem.stage3List[grippedObj.GetComponent<ItemObject>().id].itemName);
                    sceneItem.stage3System.RunStage3(sceneItem.stage3List[grippedObj.GetComponent<ItemObject>().id].itemName);
                }
                else
                {
                    if (grippedObj.GetComponent<ItemObject>().targetInven == null)
                        SetItemOriginPosition();
                }
            }
        }
    }

    void Update()
    {
        if (isItemClicked)
        {
            OnItemClicked();
        }

        if (IsItemTargeted("item", "Item"))
        {
            OnItemHightlight();
        }
        else if (isOjectHighlighted)
        {
            isOjectHighlighted = false;
            //highlightObj.GetComponent<Image>().color = color1;
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
            else if (IsItemTargeted("obstacle", "StoryObject"))
            {
                ObstacleRunMethod(stage);
            }
        }
        if (grippedObj != null)
        {
            if (Input.GetMouseButton(0))
            {
                if (grippedObj.GetComponent<ItemObject>().isActivated)
                {
                    isOjectGripped = true;
                    Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                    grippedObj.GetComponent<ItemObject>().transform.position = mousePos;
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (isOjectGripped)
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
                        RunStageClue();
                    }
                    else
                    {
                        if (grippedObj.GetComponent<ItemObject>().targetInven == null)
                            SetItemOriginPosition();
                    }
                    isOjectGripped = false;
                    grippedObj = null;
                }
            }
        }
    }

    private void OnItemHightlight()
    {
        if (!rayHit.collider.gameObject.GetComponent<ItemObject>().isActivated)
        {
            if (!isOjectHighlighted)
            {
                highlightObj = rayHit.collider.gameObject;
                //color1 = new Color(rayHit.collider.gameObject.GetComponent<Image>().color.r, rayHit.collider.gameObject.GetComponent<Image>().color.g, rayHit.collider.gameObject.GetComponent<Image>().color.b);
                //rayHit.collider.gameObject.GetComponent<Image>().color = new Color(1f, 1f, 1f);
            }
            isOjectHighlighted = true;
        }
    }

    private void RunStageClue()
    {
        KeyRunMethod(stage);
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
                grippedObj.GetComponent<SpriteRenderer>().sortingOrder = 11;
                break;
            }
        }
    }

    private void SetItemHighlighted()
    {

    }
}
