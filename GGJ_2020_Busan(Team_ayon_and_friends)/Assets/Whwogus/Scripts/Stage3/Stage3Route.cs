using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Pathfinding;

public class Stage3Route : MonoBehaviour
{
    public GameObject telescope;
    public GameObject telescopeOnTree;
    public GameObject catTreeAnim;
    public Image fadeOut;
    public Tree_Puzzle treePuzzle;
    public Tree catTree;
    public GameObject equiptedScope;
    public GameObject prop;
    public GameObject stars;
    public GameObject planetGame;
    public GameObject lastGame;
    public AIDestinationSetter catPath;
    public GameObject jumpPos;

    private bool isStage3End;
    private float fadeOutImageAlpha;

    void Start()
    {
        isStage3End = false;
    }

    void Update()
    {
        if (isStage3End)
        {
            if (fadeOutImageAlpha < 1)
                fadeOutImageAlpha += Time.deltaTime / 4;
            else
                fadeOutImageAlpha = 1;
            fadeOut.color = new Color(0f, 0f, 0f, fadeOutImageAlpha);
        }
    }
    public void EndScene()
    {
        fadeOut.gameObject.SetActive(true);
        isStage3End = true;
        StartCoroutine(NextScene());
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("EndingScene");
    }

    public void RunStage3(string key)
    {
        switch (key)
        {
            case "scissors":
                OnTreeCut();
                break;
            case "telescope":
                UseTelescope();
                break;
        }
    }

    public void PuzzleOnOff()
    {
        if (planetGame.activeSelf)
            planetGame.SetActive(false);
        else
            planetGame.SetActive(true);
    }

    public void RunObstacle(string key)
    {
        switch (key)
        {
            case "equipedProp":
                TelescopeEquip();
                break;
            case "woodBoard":
                PuzzleOnOff();
                break;
            case "exitFence":
                LastGameOnOff();
                break;
        }
    }

    public void LastGameOnOff()
    {
        if (lastGame.activeSelf)
        {
            lastGame.SetActive(false);
        }
        else
        {
            lastGame.SetActive(true);
        }
    }

    private void TelescopeEquip()
    {
        OnClickStars();
    }

    private void UseTelescope()
    {
        equiptedScope.SetActive(true);
        prop.GetComponent<ItemObject>().id = 4;
        prop.tag = "obstacle";
        prop.layer = 10;
    }

    private void OnTreeCut()
    {
        catTree.Change_Sprite();
        jumpPos.tag = "inCircle";
        catPath.target = jumpPos.transform;
    }

    public void CatAnimStart()
    {
        StartCoroutine(CatTreeAnimStarter());
    }

    IEnumerator CatTreeAnimStarter()
    {
        yield return new WaitForSeconds(1f);
        telescope.SetActive(true);
        telescopeOnTree.SetActive(false);
        catTreeAnim.SetActive(true);
        yield return new WaitForSeconds(4f);
        catTreeAnim.SetActive(false);
    }

    public void OnClickStars()
    {
        if (stars.activeSelf)
            stars.SetActive(false);
        else
            stars.SetActive(true);
    }
}
