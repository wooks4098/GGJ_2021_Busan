using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage2Route : MonoBehaviour
{
    public GameObject oneHandSaw;
    public GameObject oneHandShovel;
    public GameObject woodPuzzleBox;
    public GameObject firstBox;
    public GameObject brokenFence;
    public GameObject tunaCan;
    public GameObject pot;
    public GameObject dirt;
    public Sprite openedBox;
    public Sprite openedFence;
    public Sprite filledPot;
    public Sprite openedJeweryBox;
    public Sprite openedWoodFence;
    public GameObject catTree;
    public GameObject woodPuzzle;
    public AIDestinationSetter catDestination;
    public CatAnim cat;
    public CatCollision2 catAnim;
    public GameObject catClone;
    public GameObject oneHandSaw2;
    public GameObject oneHandShovel2;
    public GameObject oneHandSaw3;
    public GameObject oneHandShovel3;
    public GameObject jewery;
    public GameObject smallKey;

    public GameObject exitFence;
    public GameObject jeweryBox;
    public GameObject treeZoomedImage;
    public CatAnim cloneCatAnim;
    public Image fadeOut;

    private bool isStage2End = false;
    private float fadeOutImageAlpha = 0;
    private int stack1 = 0;
    private int stack2 = 0;

    void Start()
    {

    }

    void Update()
    {
        if (isStage2End)
        {
            if (fadeOutImageAlpha < 1)
                fadeOutImageAlpha += Time.deltaTime / 4;
            else
                fadeOutImageAlpha = 1;
            fadeOut.color = new Color(0f, 0f, 0f, fadeOutImageAlpha);
        }
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Stage3");
    }

    public void RunStage2(string key)
    {
        switch (key)
        {
            case "oneHandSaw":
                UseOneHandSaw();
                break;
            case "oneHandShovel":
                UseOneHandShovel();
                break;
            case "tunaCan":
                UseTunaCan();
                break;
            case "oneHandSaw2":
                UseOneHandSaw2();
                break;
            case "oneHandShovel2":
                UseOneHandShovel2();
                break;
            case "jewerly":
                UseJewery();
                break;
            case "smallKey":
                UseSmallKey();
                break;
        }
    }

    public void RunObstacle(string key)
    {
        switch (key)
        {
            case "brokenWood":
                OnTouchCarvedTree();
                break;
            case "clueTree":
                OnTreeClicked();
                break;
        }
    }

    private void UseOneHandSaw()
    {
        ChangeSprite(brokenFence, openedFence);
        oneHandSaw2.SetActive(true);
        oneHandShovel.tag = "item";
    }

    private void UseOneHandShovel()
    {
        dirt.SetActive(false);
        tunaCan.SetActive(true);
        oneHandShovel2.SetActive(true);
        ChangeSprite(pot, filledPot);
    }

    private void UseTunaCan()
    {
        StartCoroutine(EndCatJumpAnimation());
        catDestination.target = catTree.transform;
        cat.isEatten = true;
    }


    //=================================================================================== UI ON/OFF =========================================================================

    private void UseOneHandShovel2()
    {
        stack1 += 1;
        oneHandShovel3.SetActive(true);
        if (stack1 >= 2)
        {
            ShowJewery();
        }
    }

    private void UseOneHandSaw2()
    {
        stack1 += 1;
        oneHandSaw3.SetActive(true);
        if (stack1 >= 2)
        {
            ShowJewery();
        }
    }

    private void UseJewery()
    {
        stack2 += 1;
        if (stack2 >= 2)
        {
            EndScene();
        }
    }

    private void UseSmallKey()
    {
        stack2 += 1;
        if (stack2 >= 2)
        {
            EndScene();
        }
    }

    private void EndScene()
    {
        ChangeSprite(exitFence, openedFence);
        fadeOut.gameObject.SetActive(true);
        isStage2End = true;
        StartCoroutine(NextScene());
    }

    private void ShowJewery()
    {
        jewery.SetActive(true);
        ChangeSprite(jeweryBox, openedJeweryBox);
    }

    private void OnTouchCarvedTree()
    {
        woodPuzzle.SetActive(true);
    }

    public void OnClearPuzzleBox()
    {
        ChangeSprite(woodPuzzleBox, openedBox);
        oneHandSaw.SetActive(true);
    }

    public void OnOpenFirstBox()
    {
        ChangeSprite(firstBox, openedBox);
        tunaCan.SetActive(true);
    }

    private void ChangeSprite(GameObject obj, Sprite img)
    {
        obj.GetComponent<SpriteRenderer>().sprite = img;
    }

    IEnumerator EndCatJumpAnimation()
    {
        yield return new WaitForSeconds(10f);
        smallKey.SetActive(true);
        catAnim.cinemachineCam.SetActive(true);
        catAnim.catJumpAnim.SetActive(false);
        catClone.SetActive(true);
        yield return new WaitForSeconds(1f);
        cloneCatAnim.isEatten = true;
    }

    public void CloseWoodPuzzle()
    {
        woodPuzzle.SetActive(false);
    }

    public void OnTreeClicked()
    {
        treeZoomedImage.SetActive(true);
    }

    public void CloseTreeZoomed()
    {
        treeZoomedImage.SetActive(false);
    }
}
