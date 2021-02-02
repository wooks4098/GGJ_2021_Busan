using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : MonoBehaviour
{
    public Sprite ChangeSprite;

    public void Change_Sprite()
    {
        this.gameObject.GetComponent<SpriteRenderer>().sprite = ChangeSprite;
    }
}
