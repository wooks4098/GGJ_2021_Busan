using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Stage1Route : MonoBehaviour
{
    public GameObject player;
    public GameObject handLight;
    public GameObject shovel;
    public GameObject lever;
    public GameObject box;
    public GameObject board;

    public GameObject boxZoomedIn;
    public Sprite openedBox;

    public Player myPlayer;
    public PetAnim dog;
    public DogCollisionFinder dogGoal;
    public Image fadeOut;

    private bool isStage1End;
    private float fadeOutImageAlpha = 0;

    void Start()
    {
        isStage1End = false;
    }

    void Update()
    {
        if (isStage1End)
        {
            if (fadeOutImageAlpha < 1)
                fadeOutImageAlpha += Time.deltaTime / 4;
            else
                fadeOutImageAlpha = 1;
            fadeOut.color = new Color(0f, 0f, 0f, fadeOutImageAlpha);
        }
    }

    public void RunStage1(string key)
    {
        switch (key)
        {
            case "glassBall":
                PushGlassBallToBox();
                break;
            case "shovel":
                GetLever();
                break;
            case "lever":
                EndStage1();
                break;
        }
    }

    public void RunObstacle(string key)
    {
        switch (key)
        {
            case "box":
                OnBoxClick();
                break;
            case "flash":
                LightOn();
                Destroy(BagManager.instance.grippedObj);
                break;
        }
    }

    private void EndStage1()
    {
        fadeOut.gameObject.SetActive(true);
        board.SetActive(false);
        isStage1End = true;
        StartCoroutine(NextScene());
    }

    IEnumerator NextScene()
    {
        yield return new WaitForSeconds(4f);
        SceneManager.LoadScene("Stage2");
    }

    private void LightOn()
    {
        Cursor.visible = false;
        handLight.SetActive(true);
        myPlayer.PlayerSkinChange();
    }

    private void PushGlassBallToBox()
    {
        shovel.SetActive(true);
        boxZoomedIn.SetActive(false);
        box.GetComponent<SpriteRenderer>().sprite = openedBox;
        player.SetActive(true);
    }

    private void GetLever()
    {
        lever.SetActive(true);
        dog.isBarking = false;
        dogGoal.petGoal.target = myPlayer.transform;
    }

    //=================================================================================== UI ON/OFF =========================================================================
    public void OnBoxClick()
    {
        player.SetActive(false);
        boxZoomedIn.SetActive(true);
    }

    public void BoxClose()
    {
        player.SetActive(true);
        boxZoomedIn.SetActive(false);
    }
}
